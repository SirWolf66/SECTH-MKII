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
namespace SECTH_Cliënt
{
    class Speech
    {


        SpeechRecognitionEngine sre;

        public Speech()
        {
            //CultureInfo cultureInfo = new CultureInfo("en-US");
            //sre = new SpeechRecognitionEngine(cultureInfo);
        }

        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
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
