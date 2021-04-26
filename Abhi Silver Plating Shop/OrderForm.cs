using Abhi_Silver_Plating_Shop.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Abhi_Silver_Plating_Shop
{
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
        }

        void LoadItems()
        {
            DataTable dataTable = new Repository.BaseDao().PopulateDataSourceData(Repository.Queries.ITEM_SELECT_QUERY);
            this.itemCombo.DataSource = dataTable;
            this.itemCombo.DisplayMember = "Name";
            this.itemCombo.ValueMember = "itemId";
        }

        void LoadCustomers()
        {
            DataTable dataTable = new Repository.BaseDao().PopulateDataSourceData(Repository.Queries.CUSTOMER_SELECT_QUERY);
            this.customerCombo.DataSource = dataTable;
            this.customerCombo.DisplayMember = "name";
            this.customerCombo.ValueMember = "customerId";
        }

        void PopulateOrderGrid()
        {
            DataTable dataTable = new Repository.BaseDao().PopulateDataSourceData(Repository.Queries.ORDER_SELECT_QUERY);
            orderGridView.DataSource = dataTable;
            orderGridView.Columns["orderId"].Visible = false;
            orderGridView.Columns["customerId"].Visible = false;
            orderGridView.Columns["itemId"].Visible = false;
            orderGridView.Columns["creation_date"].Visible = false;
            orderGridView.Columns["last_modified"].Visible = false;
        }

        void ClearForm()
        {
            btnEdit.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show(customerCombo.SelectedValue.ToString());
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            LoadItems();
            LoadCustomers();
            PopulateOrderGrid();
        }

        private void orderGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAdd.Enabled = false;
            btnEdit.Enabled = true;

            txtOrderId.Text = Utility.CellValueByIndex(0, orderGridView);
            customerCombo.SelectedText = Utility.CellValueByIndex(1, orderGridView);
            //customerCombo.SelectedValue = Utility.GetCells(orderGridView).GetCellValueFromColumnHeader("customerId");


        }

        private void orderGridView_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            (orderGridView.DataSource as DataTable).DefaultView.RowFilter = e.FilterString;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnAddCust_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CustomerForm().ShowDialog();
            LoadCustomers();
            this.Show();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ItemForm().ShowDialog();
            LoadItems();
            this.Show();
        }
    }
}
