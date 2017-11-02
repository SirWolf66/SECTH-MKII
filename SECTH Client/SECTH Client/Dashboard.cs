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
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            this.Hide();
            Settings settings = new Settings();
            settings.FormClosed += (s, args) => this.Close();
            settings.Show();
        }

        private void btnMarkTemp_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 mark = new Form1();
            mark.FormClosed += (s, args) => this.Close();
            mark.Show();
        }
    }
}
