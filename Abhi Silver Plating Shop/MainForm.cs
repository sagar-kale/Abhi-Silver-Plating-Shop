using Abhi_Silver_Plating_Shop.Utils;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Abhi_Silver_Plating_Shop
{
    public partial class MainForm : Form
    {
        readonly MaterialSkinManager manager;
        public MainForm()
        {
            InitializeComponent();
            manager = MaterialSkinManager.Instance;
            manager.Theme = MaterialSkinManager.Themes.LIGHT;
            manager.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue500,
                Primary.Blue500, Accent.Pink200,
                TextShade.WHITE
                );
            manager.EnforceBackcolorOnAllComponents = false;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void fileMenuClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Model.LoginInfo.UserRole == AppConstants.USER)
            {
                menuUser.Enabled = false;
            }
        }

        private void menuCustomer_Click(object sender, EventArgs e)
        {
            new CustomerForm().Show();
        }

        private void menuItem_Click(object sender, EventArgs e)
        {
            new ItemForm().Show();
        }

        private void menuRate_Click(object sender, EventArgs e)
        {
            new UnitForm().Show();
        }

        private void menuUser_Click(object sender, EventArgs e)
        {
            new UserForm().Show();
        }

        private void menuOrder_Click(object sender, EventArgs e)
        {
            new OrderForm().Show();
        }
    }
}
