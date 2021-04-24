using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Abhi_Silver_Plating_Shop
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void ItemForm_Load(object sender, EventArgs e)
        {
            string query = "Select name as Name,address as Address, email as Email, mobile as Mobile from customers";
            DataTable dataTable = new Repository.Connection().PopulateDataSourceData(query);
            customerGridView.DataSource = dataTable;
        }

        private void customerGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void materialButton3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
