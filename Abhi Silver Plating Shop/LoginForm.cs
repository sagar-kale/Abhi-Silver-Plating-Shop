using Abhi_Silver_Plating_Shop.Utils;
using System;
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
            Repository.BaseDao baseDao = new();

            bool isAuthenticated = baseDao.Authenticate(new Model.User { Username = username, Password = password });

            if (isAuthenticated)
            {
                this.Hide();
                ResetMyForm();
                MainForm mainForm = new();
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
        private void txtUsr_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToLower(e.KeyChar);
        }
    }
}
