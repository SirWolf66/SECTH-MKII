using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SECTH_Cliënt
{
    class BingSpeechToTextService
    {

        //https://github.com/maptz/maptz.speechtotext.tool
        //https://stackoverflow.com/questions/45492964/bing-speech-to-text-api-communicate-via-websocket-in-c-sharp

        // accesskeys speech api
        // b92b926bdef4432bb1c0ed79844b707e
        // 2346d467d4fc41b09bfada3f6cb91ae8

        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                var bingService = new BingSpeechToTextService();
                var audioFilePath = @"FILEPATH GOES HERE";
                var authenticationKey = @"b92b926bdef4432bb1c0ed79844b707e";
                await bingService.RegisterJob(audioFilePath, authenticationKey);
            }).Wait();
        }

        public class BingSpeechToTextService
        {
            #region Private Static Methods
            private static async Task Receiving(ClientWebSocket client)
            {
                var buffer = new byte[128];
                while (true)
                {
                    var result = await client.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    string res = Encoding.UTF8.GetString(buffer, 0, result.Count);

                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, result.Count));
                    }
                    else if (result.MessageType == WebSocketMessageType.Close)
                    {
                        Console.WriteLine($"Closing ... reason {client.CloseStatusDescription}");
                        var description = client.CloseStatusDescription;
                        //await client.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Other result");
                    }
                }
            }
        }
         #endregion Private Static Methods 

         #region Public Static Methods 
        public static UInt16 ReverseBytes(UInt16 value)
        {
            return (UInt16)((value & 0xFFU) << 8 | (value & 0xFF00U) >> 8);
        }
         #endregion Public Static Methods 

         #region Interface: 'Unscrypt.Bing.SpeechToText.Client.Api.IBingSpeechToTextJobService' Methods 
        public async Task<int?> RegisterJob(string audioFilePath, string authenticationKeyStr)
        {
            BingSocketAuthentication authenticationKey = new BingSocketAuthentication(authenticationKeyStr);
            string token = authenticationKey.GetAccessToken();

             #region Connect web socket 
            var cws = new ClientWebSocket();
            string connectionId = Guid.NewGuid().ToString("N");
            string lang = "en-US";
            cws.Options.SetRequestHeader("X-ConnectionId", connectionId);
            cws.Options.SetRequestHeader("Authorization", "Bearer " + token);
            Console.WriteLine("Connecting to web socket.");
            string url = $"wss://speech.platform.bing.com/speech/recognition/interactive/cognitiveservices/v1?format=simple&language={lang}";
            await cws.ConnectAsync(new Uri(url), new CancellationToken());
            Console.WriteLine("Connected.");
             #endregion

             #region Receiving 
            var receiving = Receiving(cws);
             #endregion

             #region Sending 
            var sending = Task.Run(async () =>
            {
                #region Send speech.config 
                dynamic speechConfig = new
            {
                context = new
                {
                    system = new
                    {
                        version = "1.0.00000"
                    },
                    os = new
                    {
                        platform = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Safari/537.36",
                        name = "Browser",
                        version = ""
                    },
                    device = new
                    {
                        manufacturer = "SpeechSample",
                        model = "SpeechSample",
                        version = "1.0.00000"
                    }
                }
            };

                var requestId = Guid.NewGuid().ToString("N");
                var speechConfigJson = JsonConvert.SerializeObject(speechConfig, Formatting.None);
                StringBuilder outputBuilder = new StringBuilder();
                outputBuilder.Append("path:speech.config\r\n"); //Should this be \r\n
                outputBuilder.Append($"x-timestamp:{DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffK")}\r\n");
                outputBuilder.Append($"content-type:application/json\r\n");
                outputBuilder.Append("\r\n\r\n");
                outputBuilder.Append(speechConfigJson);
                var strh = outputBuilder.ToString();

                var encoded = Encoding.UTF8.GetBytes(outputBuilder.ToString());
                var buffer = new ArraySegment<byte>(encoded, 0, encoded.Length);

                if (cws.State != WebSocketState.Open) return;
                Console.WriteLine("Sending speech.config");
                await cws.SendAsync(buffer, WebSocketMessageType.Text, true, new CancellationToken());
                Console.WriteLine("Sent.");
                 #endregion

                 #region Send audio parts.  
                var fileInfo = new FileInfo(audioFilePath);
                var streamReader = fileInfo.OpenRead();

                for (int cursor = 0; cursor < fileInfo.Length; cursor++)
                {

                    outputBuilder.Clear();
                    outputBuilder.Append("path:audio\r\n");
                    outputBuilder.Append($"x-requestid:{requestId}\r\n");
                    outputBuilder.Append($"x-timestamp:{DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffK")}\r\n");
                    outputBuilder.Append($"content-type:audio/x-wav");

                    var headerBytes = Encoding.ASCII.GetBytes(outputBuilder.ToString());
                    var headerbuffer = new ArraySegment<byte>(headerBytes, 0, headerBytes.Length);
                    var str = "0x" + (headerBytes.Length).ToString("X");
                    var headerHeadBytes = BitConverter.GetBytes((UInt16)headerBytes.Length);
                    var isBigEndian = !BitConverter.IsLittleEndian;
                    var headerHead = !isBigEndian ? new byte[] { headerHeadBytes[1], headerHeadBytes[0] } : new byte[] { headerHeadBytes[0], headerHeadBytes[1] };

                    //Audio should be pcm 16kHz, 16bps mono
                    var byteLen = 8192 - headerBytes.Length - 2;
                    var fbuff = new byte[byteLen];
                    streamReader.Read(fbuff, 0, byteLen);

                    var arr = headerHead.Concat(headerBytes).Concat(fbuff).ToArray();
                    var arrSeg = new ArraySegment<byte>(arr, 0, arr.Length);

                    Console.WriteLine($"Sending data from {cursor}");
                    if (cws.State != WebSocketState.Open) return;
                    cursor += byteLen;
                    var end = cursor >= fileInfo.Length;
                    await cws.SendAsync(arrSeg, WebSocketMessageType.Binary, true, new CancellationToken());
                    Console.WriteLine("Data sent");

                    var dt = Encoding.ASCII.GetString(arr);



                }
                await cws.SendAsync(new ArraySegment<byte>(), WebSocketMessageType.Binary, true, new CancellationToken());
                streamReader.Dispose();
                 #endregion

                {
                    var startWait = DateTime.UtcNow;
                    while ((DateTime.UtcNow - startWait).TotalSeconds < 30)
                    {
                        await Task.Delay(1);
                    }
                    if (cws.State != WebSocketState.Open) return;
                }
            });
             #endregion

             #region Wait for tasks to complete 
            await Task.WhenAll(sending, receiving);
            if (sending.IsFaulted)
            {
                var err = sending.Exception;
                throw err;
            }
            if (receiving.IsFaulted)
            {
                var err = receiving.Exception;
                throw err;
            }
             #endregion

            return null;

        }
         #endregion Interface: 'Unscrypt.Bing.SpeechToText.Client.Api.IBingSpeechToTextJobService' Methods 


        public class BingSocketAuthentication
        {
            public static readonly string FetchTokenUri = "https://api.cognitive.microsoft.com/sts/v1.0";
            private string subscriptionKey;
            private string token;
            private Timer accessTokenRenewer;

            //Access token expires every 10 minutes. Renew it every 9 minutes.
            private const int RefreshTokenDuration = 9;

            public BingSocketAuthentication(string subscriptionKey)
            {
                this.subscriptionKey = subscriptionKey;
                this.token = FetchToken(FetchTokenUri, subscriptionKey).Result;

                // renew the token on set duration.
                accessTokenRenewer = new Timer(new TimerCallback(OnTokenExpiredCallback),
                                               this,
                                               TimeSpan.FromMinutes(RefreshTokenDuration),
                                               TimeSpan.FromMilliseconds(-1));
            }

            public string GetAccessToken()
            {
                return this.token;
            }

            private void RenewAccessToken()
            {
                this.token = FetchToken(FetchTokenUri, this.subscriptionKey).Result;
                Console.WriteLine("Renewed token.");
            }

            private void OnTokenExpiredCallback(object stateInfo)
            {
                try
                {
                    RenewAccessToken();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("Failed renewing access token. Details: {0}", ex.Message));
                }
                finally
                {
                    try
                    {
                        accessTokenRenewer.Change(TimeSpan.FromMinutes(RefreshTokenDuration), TimeSpan.FromMilliseconds(-1));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(string.Format("Failed to reschedule the timer to renew access token. Details: {0}", ex.Message));
                    }
                }
            }

            private async Task<string> FetchToken(string fetchUri, string subscriptionKey)
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
                    UriBuilder uriBuilder = new UriBuilder(fetchUri);
                    uriBuilder.Path += "/issueToken";

                    var result = await client.PostAsync(uriBuilder.Uri.AbsoluteUri, null);
                    Console.WriteLine("Token Uri: {0}", uriBuilder.Uri.AbsoluteUri);
                    return await result.Content.ReadAsStringAsync();
                }
            }
        }
    }
}
