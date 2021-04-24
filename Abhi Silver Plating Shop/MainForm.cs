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
        public MainForm()
        {
            InitializeComponent();
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
            populateData();
        }

        void populateData()
        {
            string query = "select * from user_auth";
            Repository.Connection connection = new Repository.Connection();
            DataTable dataTable = connection.PopulateDataSourceData(query);
            userGridView.DataSource = dataTable;
        }

        private void userGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void userGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            userGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void menuCustomer_Click(object sender, EventArgs e)
        {
            new CustomerForm().Show();
        }
    }
}
