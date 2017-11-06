using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SECTH_Cliënt
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string test = textBox1.Text;
            test = test.Replace("\r\n", "~~");
            CummunicationFile newMessage = new CummunicationFile("Gilbert", (test + Environment.NewLine) , "Nederlands", DateTime.Now);

            richTextBox1.AppendText((newMessage.WriteTime + ", " + newMessage.Language + ": " + newMessage.Author + ": " + newMessage.Message + Environment.NewLine));

            ClientCode clientCode = new ClientCode();
            //CummunicationFile cummunicationFile = new CummunicationFile("Eng", DateTime.Now, "Mark de Bruyn", richTextBox1.Text);
            //byte[] bb = cummunicationFile.ConvertToByteArray();
            clientCode.Test("10.77.128.145", newMessage.ConvertToByteArray());
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(listBox1.SelectedIndex == 0))
            {
                string userSearch = listBox1.SelectedItem.ToString();
                int startIndex = richTextBox1.Find(": " + userSearch + ": " );
                HighlightWords((": " + userSearch + ": "), richTextBox1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClientCode clientCode = new ClientCode();
            CummunicationFile cummunicationFile = new CummunicationFile("Eng", DateTime.Now, "Mark de Bruyn", richTextBox1.Text);
            //byte[] bb = cummunicationFile.ConvertToByteArray();
            clientCode.Test("10.77.128.145", cummunicationFile.ConvertToByteArray());
        }

        private void menuChatSettings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }

        private void menuChatQuitMain_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dash = new Dashboard();
            dash.FormClosed += (s, args) => this.Close();
            dash.Show();
        }

        private void menuChatExit_Click(object sender, EventArgs e)
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

        private void menuChatFont_Click(object sender, EventArgs e)
        {
            if(fontDialog1.ShowDialog() != DialogResult.Cancel)
            richTextBox1.Font = fontDialog1.Font;
            textBox1.Font = fontDialog1.Font;
            listBox1.Font = fontDialog1.Font;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
