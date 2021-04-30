using Abhi_Silver_Plating_Shop.Model;
using Abhi_Silver_Plating_Shop.Utils;
using Abhi_Silver_Plating_Shop.Validator;
using FluentValidation.Results;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abhi_Silver_Plating_Shop
{
    public partial class StartupSetupForm : MaterialForm
    {
        readonly MaterialSkinManager manager;
        bool isReadyToProceed = false;
        BindingList<string> errors = null;
        string connectionString;
        string shopName;
        public StartupSetupForm()
        {
            manager = MaterialSkinManager.Instance;
            manager.AddFormToManage(this);
            manager.Theme = MaterialSkinManager.Themes.LIGHT;
            manager.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue500,
                Primary.Blue500, Accent.Pink200,
                TextShade.WHITE
                );
            manager.EnforceBackcolorOnAllComponents = false;
            errors = new BindingList<string>();
            InitializeComponent();
        }
        void ResetForm()
        {
            btnProceed.Enabled = false;
            txtServer.Clear();
            txtDb.Clear();
            txtUser.Clear();
            txtPassword.Clear();
            errors.Clear();
            listBox1.BackColor = Color.White;
            listBox1.ForeColor = Color.Black;
        }
        private void StartupSetupForm_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = errors;
            ResetForm();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText("https://facebook.com/sgrkale143");
            MessageBox.Show("Url Copied !!");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText("9561609535");
            MessageBox.Show("Mobile Number Copied !!");

        }

        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            if (isReadyToProceed)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["isFirstTimeOpened"].Value = "false";
                config.AppSettings.Settings["AppName"].Value = shopName;
                config.ConnectionStrings.ConnectionStrings["defaultConnection"].ConnectionString = connectionString.Encrypt();
                config.Save();
                ConfigurationManager.RefreshSection("appSettings");
                ConfigurationManager.RefreshSection("connectionStrings");
                new LoginForm().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please test the connection first to proceed further...");
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            errors.Clear();
            listBox1.BackColor = Color.White;
            listBox1.ForeColor = Color.Black;
            isReadyToProceed = false;
            ConnectionModel connectionModel = new()
            {
                Server = txtServer.Text,
                Database = txtDb.Text,
                Username = txtUser.Text,
                Password = txtPassword.Text,
                ShopName = txtAppName.Text
            };

            ConnectionValidator validator = new();
            ValidationResult validationResult = validator.Validate(connectionModel);
            if (validationResult.IsValid == false)
            {
                foreach (ValidationFailure failure in validationResult.Errors)
                {
                    String msg = $"{failure.ErrorMessage}";
                    listBox1.BackColor = Color.Red;
                    listBox1.ForeColor = Color.White;
                    errors.Add(msg);
                }
            }
            else
            {
                // settting connection string so i can use it to set app config 

                connectionString = Utility.FormatConnectionString(
                connectionModel.Database,
                connectionModel.Username,
                connectionModel.Password,
                connectionModel.Server);

                // setting shop name at the startup so it will be used every where in components

                shopName = connectionModel.ShopName;

                if (Repository.BaseDao.TestConnection(connectionString) == true)
                {
                    isReadyToProceed = true;
                    MessageBox.Show("Connection Opened Successfully.", "Success");
                    btnTest.Enabled = false;
                    btnProceed.Enabled = true;

                }
                else
                {
                    isReadyToProceed = false;
                    btnTest.Enabled = true;
                    btnProceed.Enabled = false;
                    MessageBox.Show("Connection Failed... , Please check server details...", "Failed !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
