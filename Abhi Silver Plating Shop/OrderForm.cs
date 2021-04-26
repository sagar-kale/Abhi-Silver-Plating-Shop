using Abhi_Silver_Plating_Shop.Service;
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
        private OrderService orderService = null;
        Model.Unit unit = null;
        public OrderForm()
        {
            InitializeComponent();
            orderService = new OrderService();
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
        void LoadLabour()
        {
            UnitService unitService = new UnitService();
            unit = unitService.FetchRate(new Model.Unit(null, "KG", 0));
            txtLabourRate.Text = unit.Rate.ToString();
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
            txtOrderId.Clear();
            txtFine.Text = "0";
            txtInWeight.Text = "0";
            txtOutWeight.Text = "0";
            dateTimePicker.Value = DateTime.Now;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOrderId.Text))
            {
                MessageBox.Show("Please Enter Order Name");
                ClearForm();
            }
            else
            {

                Model.Order order = new Model.Order(
                    null,
                    itemCombo.SelectedValue.ToString(),
                    customerCombo.SelectedValue.ToString(),
                    Double.Parse(txtInWeight.Text),
                    Double.Parse(txtOutWeight.Text),
                    Double.Parse(txtFine.Text),
                    Double.Parse(txtLabourRate.Text),
                    DateTime.Now,
                    DateTime.Now,
                    dateTimePicker.Value,
                    statusCombo.Text
                    );

                bool isAdded = orderService.AddOrder(order);
                if (isAdded)
                {
                    MessageBox.Show("Order Added !!");
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Order adding failed..");
                }
                PopulateOrderGrid();

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            LoadItems();
            LoadCustomers();
            LoadLabour();
            PopulateOrderGrid();
        }

        private void orderGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAdd.Enabled = false;
            btnEdit.Enabled = true;

            txtOrderId.Text = Utility.CellValueByIndex(0, orderGridView);
            customerCombo.Text = Utility.CellValueByIndex(1, orderGridView);
            itemCombo.Text = Utility.CellValueByIndex(2, orderGridView);
            txtInWeight.Text = Utility.GetCells(orderGridView).GetCellValueFromColumnHeader("in_weight");
            txtOutWeight.Text = Utility.GetCells(orderGridView).GetCellValueFromColumnHeader("out_weight");
            txtFine.Text = Utility.GetCells(orderGridView).GetCellValueFromColumnHeader("fine");
            txtLabourRate.Text = Utility.GetCells(orderGridView).GetCellValueFromColumnHeader("labour_rate");
            dateTimePicker.Text = Utility.GetCells(orderGridView).GetCellValueFromColumnHeader("date");
            statusCombo.Text = Utility.GetCells(orderGridView).GetCellValueFromColumnHeader("status");

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

        private void btnEdit_Click(object sender, EventArgs e)
        {
        }
    }
}
