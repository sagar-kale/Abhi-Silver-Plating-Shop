using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abhi_Silver_Plating_Shop
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void txtUsr_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();

        }

        private void Login()
        {
            string username = txtUsr.Text;
            string password = txtPwd.Text;
            Repository.Connection connection = new Repository.Connection();

            Model.User user = connection.FetchUser(username, password);

            if (user != null && user.Username != null)
            {
                MessageBox.Show("Welcome " + user.Name);
                this.Hide();
                ResetMyForm();
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Incorrect username and password!!");
                ResetMyForm();
            }
        }

        public void ResetMyForm()
        {
            txtUsr.Text = "";
            txtPwd.Text = "";
            txtUsr.Focus();
        }

        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Login();
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                ResetMyForm();
            }
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            txtUsr.Text = "";
            txtPwd.Text = "";
        }

        private void ckbkShowPwd_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbkShowPwd.Checked == true)
            {
                txtPwd.Password = false;
            }
            else
            {
                txtPwd.Password = true;
            }
        }
    }
}
