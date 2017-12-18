using System;
using System.Windows.Forms;

namespace SECTH_Cliënt
{
    public partial class Settings : Form
    {
        private string autorName;
        private string language;
        private string ipadress;

        public string AutorName { get => autorName;}
        public string Language { get => language;}
        public string Ipadress { get => ipadress;}

        public Settings(string _autor, string _lang, string _ip)
        {
            InitializeComponent();
            if (_autor != string.Empty)
            {
                autorName = _autor;
                autorBox.Text = _autor;
            }
            if (_lang != string.Empty)
            {
                language = _lang;
                languageBox.Text = language;
            }
            if (_ip != string.Empty)
            {
                ipadress = _ip;
                ipBox.Text = _ip;
            }      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (autorBox.Text != string.Empty && languageBox.Text != string.Empty && ipBox.Text != string.Empty)
            {
                autorName = autorBox.Text;
                language = languageBox.Text;
                ipadress = ipBox.Text;
                this.Hide();
            }
            else
            {
                MessageBox.Show("settings not saved");
            }

        }
    }

}