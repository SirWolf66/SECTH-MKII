using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.SpeechRecognition;
using Microsoft.Bing.Speech;
using System.Speech;
using System.Speech.Recognition;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;

namespace SECTH_Cliënt
{
    class Speech
    {
        // https://github.com/MicrosoftTranslator/SpeechTranslator

        //https://developer.xamarin.com/guides/xamarin-forms/cloud-services/cognitive-services/speech-recognition/
        static string apiKey = "b92b926bdef4432bb1c0ed79844b707e";
        SpeechRecognitionEngine sre;

        string fetchUri = @"https://api.cognitive.microsoft.com/sts/v1.0/issueToken";

        async Task<string> FetchTokenAsync(string fetchUri, string apiKey)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);
                UriBuilder uriBuilder = new UriBuilder(fetchUri);
                uriBuilder.Path += "/issueToken";

                var result = await client.PostAsync(uriBuilder.Uri.AbsoluteUri, null);
                return await result.Content.ReadAsStringAsync();


                using (var httpClient = new HttpClient())
                {
                  //  httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                }
            }
        }

        /*
        public async Task<SpeechResult> RecognizeSpeechAsync(string filename)
        {

    // Read audio file to a stream
    var file = await PCLStorage.FileSystem.Current.LocalStorage.GetFileAsync(filename);
            var fileStream = await file.OpenAsync(PCLStorage.FileAccess.Read);

            // Send audio stream to Bing and deserialize the response
            string requestUri = GenerateRequestUri(Constants.SpeechRecognitionEndpoint);
            string accessToken = authenticationService.GetAccessToken();
            var response = await SendRequestAsync(fileStream, requestUri, accessToken, Constants.AudioContentType);
            var speechResults = JsonConvert.DeserializeObject<SpeechResults>(response);

            fileStream.Dispose();
            return speechResults.results.FirstOrDefault();
        }
        */
        string GenerateRequestUri(string speechEndpoint)
        {
            string requestUri = speechEndpoint;
            requestUri += @"?scenarios=ulm";                                    // websearch is the other option
            requestUri += @"&appid=D4D52672-91D7-4C74-8AD8-42B1D98141A5";       // You must use this ID
            requestUri += @"&locale=en-US";                                     // Other languages supported
            //requestUri += string.Format("&device.os={0}", operatingSystem);     // Open field
            requestUri += @"&version=3.0";                                      // Required value
            requestUri += @"&format=json";                                      // Required value
            requestUri += @"&instanceid=fe34a4de-7927-4e24-be60-f0629ce1d808";  // GUID for device making the request
            requestUri += @"&requestid=" + Guid.NewGuid().ToString();           // GUID for the request
            return requestUri;
        }

        async Task<string> SendRequestAsync(Stream fileStream, string url, string bearerToken, string contentType)
        {
            var content = new StreamContent(fileStream);
            content.Headers.TryAddWithoutValidation("Content-Type", contentType);

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                var response = await httpClient.PostAsync(url, content);

                return await response.Content.ReadAsStringAsync();
            }
        }

        /*
        /// <summary>
        /// Gets text from an audio stream.
        /// </summary>
        /// <param name="audiostream"></param>
        /// <returns>Transcribed text. </returns>
        public async Task<string> GetTextFromAudioAsync(Stream audiostream)
        {
            var requestUri = @"https://speech.platform.bing.com/recognize?scenarios=smd&appid=D4D52672-91D7-4C74-8AD8-42B1D98141A5&locale=en-US&device.os=bot&version=3.0&format=json&instanceid=565D69FF-E928-4B7E-87DA-9A750B96D9E3&requestid=" + Guid.NewGuid();

            using (var client = new HttpClient())
            {
                var token = Authentication.Instance.GetAccessToken();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.access_token);

                using (var binaryContent = new ByteArrayContent(StreamToBytes(audiostream)))
                {
                    binaryContent.Headers.TryAddWithoutValidation("content-type", "audio/wav; codec=\"audio/pcm\"; samplerate=16000");

                    var response = await client.PostAsync(requestUri, binaryContent);
                    var responseString = await response.Content.ReadAsStringAsync();
                    try
                    {
                        dynamic data = JsonConvert.DeserializeObject(responseString);
                        return data.header.name;
                    }
                    catch (JsonReaderException ex)
                    {
                        throw new Exception(responseString, ex);
                    }
                }
            }
        }
        */

        public Speech()
        {
            CultureInfo cultureInfo = new CultureInfo("en-US", true);

           // MicrosoftCognitiveSpeechService.GetTextFromAudioAsync();
            
            /*
            var audioAttachment = activity.Attachments?.FirstOrDefault(a => a.ContentType.Equals("audio/wav"));
            if (audioAttachment != null)
            {
                using (var client = new HttpClient())
                {
                    var stream = await client.GetStreamAsync(audioAttachment.ContentUrl);
                    var text = await this.speechService.GetTextFromAudioAsync(stream);
                    message = ProcessText(activity.Text, text);
                }
            }*/




            sre = new SpeechRecognitionEngine();

            //sre = new SpeechRecognitionEngine(cultureInfo);
        }

        private void Sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Speech recognized: " + e.Result.Text);
        }



        public void bfehjvfusdvlsabcuvsdfilvsdkz()
        {

            Choices colors = new Choices();
            colors.Add(new string[] { "red", "green", "blue" });

            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(colors);

            // Create the Grammar instance.
            Grammar g = new Grammar(gb);

            //sre.SetInputToWaveFile(@"c:\Test\Colors.wav");
            sre.SetInputToDefaultAudioDevice();
            sre.LoadGrammar(g);

        }

        public void vfycvdsub()
        {
            sre.Recognize();

        }



        // accesskeys speech api
        // b92b926bdef4432bb1c0ed79844b707e
        // 2346d467d4fc41b09bfada3f6cb91ae8


    }
}