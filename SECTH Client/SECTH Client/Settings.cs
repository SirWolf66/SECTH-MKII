using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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

        public Settings()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            autorName = textBox2.Text;
            language = comboBox1.Text;
            ipadress = textBox5.Text;
            this.Hide();
        }
    }

}