using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml.Linq;

namespace WindowsFormsApp3
{


    // key 1: 57594cf0272d428cbd945e4978c8e70e
    // key 2: 5becb65e0c0f42f79bd0f6347f4bcca6
    class TextTranslationService
    {
        public List<CommunicationFile> Translate(CommunicationFile communicationFile)
        {
            List<CommunicationFile> communicationFileList = new List<CommunicationFile>();
            string[] languageList = { "en", "de", "nl", "ja", "es", "hi", "ar", "zh-CHS" };
            foreach (string lang in languageList)
            {
                string language;
                if (lang == "zh-CHS")
                {
                    language = "zh";
                }
                else
                {
                    language = lang;
                }
                CommunicationFile newCommunicationFile = new CommunicationFile(language, communicationFile.WriteTime, communicationFile.Author, Translate(lang, communicationFile.Message));
                communicationFileList.Add(newCommunicationFile);
            }
            return communicationFileList;
        }

        //static readonly string APIKEY = "57594cf0272d428cbd945e4978c8e70e";
        //static readonly string TRANSLATETO = "de";
        static string Translate(string language, string input)
        {
            string APIKEY = "9b5b0ae2d3ae4a1b83553567604cbb6d";
            string output = "";
            //string input = "Alstublieft meneer mr Gates sama vertaal deze tekst hier.";
            Task.Run(async () =>
            {
                string accessToken = await GetAuthenticationToken(APIKEY);
                output = await Translate(input, language, accessToken);
                Console.WriteLine(output);
            }).Wait();
            return (output);
        }
        static async Task<string> Translate(string textToTranslate, string language, string accessToken)
        {
            string url = "http://api.microsofttranslator.com/v2/Http.svc/Translate";
            string query = $"?text={System.Net.WebUtility.UrlEncode(textToTranslate)}&to={language}&contentType=text/plain";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var response = await client.GetAsync(url + query);
                var result = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                    return "ERROR: " + result;
                var translatedText = XElement.Parse(result).Value;
                return translatedText;
            }
        }
        static async Task<string> GetAuthenticationToken(string key)
        {
            string endpoint = "https://api.cognitive.microsoft.com/sts/v1.0/issueToken";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);
                var response = await client.PostAsync(endpoint, null);
                var token = await response.Content.ReadAsStringAsync();
                return token;
            }
        }
        
    }
}
