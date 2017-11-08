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
        string author;
        string language;
        ClientCode clientCode = new ClientCode("10.77.153.83");
        Speech speech = new Speech();

        public string Author { get => author; set => author = value; }
        public string Language { get => language; set => language = value; }

        public Form1()
        {
            Thread t = new Thread(new ThreadStart(MethodName));
            t.Start();
            author = "Mark de Bruijn";
            language = "Dutch";
            InitializeComponent();
        }

        private void MethodName()
        {
            while (clientCode.Connected)
            {
                CommunicationFile result = clientCode.RecieveMessage();
                if (result.Language != "ERROR")
                {
                    Invoke(new MethodInvoker(delegate () { richTextBox1.AppendText((result.WriteTime + ", " + result.Language + ": " + result.Author + ": " + result.Message + Environment.NewLine)); }));
                }
            }
        }

        /// <summary>
        /// send button, sends the text to server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            CommunicationFile newMessage = new CommunicationFile(language, DateTime.Now, author, textBox1.Text + Environment.NewLine);            
            clientCode.SendMessage(newMessage.ConvertToByteArray());
        }

        /// <summary>
        /// search box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            HighlightWords(textBox4.Text, richTextBox1);
        }

        /// <summary>
        /// should Highlight what you search, does not work properly
        /// </summary>
        /// <param name="word"></param>
        /// <param name="textbox"></param>       
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

        /// <summary>
        /// should hold all people whom are present in the Convernce,
        /// this list should be recieved from the server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(listBox1.SelectedIndex == 0))
            {
                string userSearch = listBox1.SelectedItem.ToString();
                int startIndex = richTextBox1.Find(": " + userSearch + ": " );
                HighlightWords((": " + userSearch + ": "), richTextBox1);
            }
        }

        /// <summary>
        /// this is the textbutton remove when done
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
    }
}
