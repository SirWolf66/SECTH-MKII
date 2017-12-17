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
    public partial class Login : Form
    {
        string kevin = "Kevin";
        string kevinPass = "Deketelaere";
        string mark = "Mark";
        string markPass = "qwerty12345";
        string gilbert = "Gilbert";
        string gilbertPass = "Ik ga wel vrolijk verder met star wars";
        string root = "Root";
        string rootPass = "R00t";

        public Login()
        {
            InitializeComponent();
        }

        private bool Passcheck(string user, string pass)
        {
            bool correctLogin = false;
            if (user == root && pass == rootPass)
            {
                correctLogin = true;
            }
            else if (user == gilbert && pass == gilbertPass)
            {
                correctLogin = true;
            }
            else if (user == kevin && pass == kevinPass)
            {
                correctLogin = true;
            }
            else if (user == mark && pass == markPass)
            {
                correctLogin = true;
            }
            return correctLogin;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Passcheck(Username.Text, Password.Text))
            {
                this.Hide();
                Dashboard dash = new Dashboard();
                dash.FormClosed += (s, args) => this.Close();
                dash.Show();
            }
            else
            {
                MessageBox.Show("Username or Password are incorrect");
            }

        }
    }
}
