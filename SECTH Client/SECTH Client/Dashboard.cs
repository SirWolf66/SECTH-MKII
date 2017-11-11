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
    public partial class Dashboard : Form
    {
        string ipadress = "192.168.56.5";
        string language = "nl";
        string author = "mark";

        public string Author { get => author;}
        public string Language { get => language;}
        public string Ipadress { get => ipadress;}

        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            using (Settings settings = new Settings())
            {
                if (settings.ShowDialog() == DialogResult.OK)
                {
                    ipadress = settings.Ipadress;
                    language = settings.Language;
                    author = settings.AutorName;
                }
            }
        }

        private void btnMarkTemp_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 mark = new Form1(Author,Language,Ipadress);
            mark.FormClosed += (s, args) => this.Close();
            mark.Show();
        }
    }
}
