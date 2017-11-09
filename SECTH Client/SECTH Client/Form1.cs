using SECTH_Cliënt.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SECTH_Cliënt
{
    public partial class Form1 : Form
    {
        ClientCode clientCode = new ClientCode("10.77.136.108");
        Speech speech = new Speech();

        public Form1()
        {
            Thread t = new Thread(new ThreadStart(MethodName));
            t.Start();
            InitializeComponent();
            //Testefgrf();

            //_show += new RecieveText();
            // work on recieving methode
            // also after recieve check for language ERROR (indicating a failed file)
            //clientCode.RecieveMessage();            
        }

        private void MethodName()
        {
            while (true)
            {
                CommunicationFile result = clientCode.RecieveMessage();
                if (result.Language != "ERROR")
                {
                    Invoke(new MethodInvoker(delegate () { richTextBox1.AppendText((result.WriteTime + ", " + result.Language + ": " + result.Author + ": " + result.Message + Environment.NewLine)); }));
                    // richTextBox1.Invoke(delegate() { richTextBox1.AppendText((result.WriteTime + ", " + result.Language + ": " + result.Author + ": " + result.Message + Environment.NewLine)); });
                    // this.Invoke(richTextBox1.AppendText((result.WriteTime + ", " + result.Language + ": " + result.Author + ": " + result.Message + Environment.NewLine)));

                    //  richTextBox1.AppendText((result.WriteTime + ", " + result.Language + ": " + result.Author + ": " + result.Message + Environment.NewLine));
                }
            }
        }

        public async Task MyMethodAsync()
        {
            Task<CommunicationFile> longRunningTask = LongRunningOperationAsync();
            // independent work which doesn't need the result of LongRunningOperationAsync can be done here

            //and now we call await on the task 
            CommunicationFile result = await longRunningTask;
            //use the result 
            if (result.Language != "ERROR")
            {
                richTextBox1.AppendText((result.WriteTime + ", " + result.Language + ": " + result.Author + ": " + result.Message + Environment.NewLine));
                
            }
            await MyMethodAsync();
        }

        public async Task<CommunicationFile> LongRunningOperationAsync() // assume we return an int from this long running operation 
        {
            CommunicationFile cummunicationFile = clientCode.RecieveMessage();
            await Task.Delay(1000); // 1 second delay
            return cummunicationFile;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string test = textBox1.Text;
            test = test + Environment.NewLine;
            CommunicationFile newMessage = new CommunicationFile("en" , DateTime.Now, "Gilbert", (test + Environment.NewLine));

            //richTextBox1.AppendText((newMessage.WriteTime + ", " + newMessage.Language + ": " + newMessage.Author + ": " + newMessage.Message + Environment.NewLine));

            
            CommunicationFile cummunicationFile = new CommunicationFile("en", DateTime.Now, "Mark de Bruyn", test);
            //byte[] bb = cummunicationFile.ConvertToByteArray();
            
            clientCode.SendMessage(cummunicationFile.ConvertToByteArray());
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            HighlightWords(textBox4.Text, richTextBox1);
        }


        private void HighlightWords(string word, RichTextBox textbox)
        {
                int startIndex = 0;
                while (startIndex < textbox.TextLength)
                {

                    int wordStartIndex = textbox.Find(word, startIndex, RichTextBoxFinds.None);
                if (wordStartIndex != -1)
                {
                    textbox.SelectionStart = wordStartIndex;
                    textbox.SelectionLength = word.Length;
                    textbox.SelectionBackColor = Color.Yellow;
                }
                else
                    break;
                    startIndex += wordStartIndex + word.Length;
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(listBox1.SelectedIndex == 0))
            {
                string userSearch = listBox1.SelectedItem.ToString();
                int startIndex = richTextBox1.Find(": " + userSearch + ": " );
                HighlightWords((": " + userSearch + ": "), richTextBox1);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            speech.bfehjvfusdvlsabcuvsdfilvsdkz();
            speech.vfycvdsub();
        }

        private void MenuChatSettings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }

        private void MenuChatQuitMain_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dash = new Dashboard();
            dash.FormClosed += (s, args) => this.Close();
            dash.Show();
        }

        private void MenuChatExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to quit?", "Are you sure?", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
        }

        private void MenuChatFont_Click(object sender, EventArgs e)
        {
            if(fontDialog1.ShowDialog() != DialogResult.Cancel)
            richTextBox1.Font = fontDialog1.Font;
            textBox1.Font = fontDialog1.Font;
            listBox1.Font = fontDialog1.Font;
        }

        private async void Testefgrf()
        {
            await MyMethodAsync();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
