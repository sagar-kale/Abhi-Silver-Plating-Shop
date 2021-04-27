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

        void LoadStats()
        {
            double totalAmt = orderService.FetchOrderByType(AppConstants.TOTAL_AMOUNT);
            double totalFine = orderService.FetchOrderByType(AppConstants.TOTAL_FINE);
            lblAmt.Text = "Rs. " + totalAmt;
            lblFine.Text = "Rs. " + totalFine;
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
            lblCount.Text = dataTable.Rows.Count.ToString();
            LoadStats();
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
            Model.Order order = new Model.Order(
                null,
                itemCombo.SelectedValue.ToString(),
                customerCombo.SelectedValue.ToString(),
                Convert.ToDouble(txtInWeight.Text.ZeroIfEmpty()),
                Convert.ToDouble(txtOutWeight.Text.ZeroIfEmpty()),
                Convert.ToDouble(txtFine.Text.ZeroIfEmpty()),
                Convert.ToDouble(txtTotalAmt.Text.ZeroIfEmpty()),
                Convert.ToDouble(txtLabourRate.Text.ZeroIfEmpty()),
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
            ClearForm();
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
            txtTotalAmt.Text = Utility.GetCells(orderGridView).GetCellValueFromColumnHeader("total_amount");

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
            if (!String.IsNullOrWhiteSpace(txtOrderId.Text))
            {

                Model.Order order = new Model.Order(
                txtOrderId.Text,
                itemCombo.SelectedValue.ToString(),
                customerCombo.SelectedValue.ToString(),
                Convert.ToDouble(txtInWeight.Text.ZeroIfEmpty()),
                Convert.ToDouble(txtOutWeight.Text.ZeroIfEmpty()),
                Convert.ToDouble(txtFine.Text.ZeroIfEmpty()),
                Convert.ToDouble(txtTotalAmt.Text.ZeroIfEmpty()),
                Convert.ToDouble(txtLabourRate.Text.ZeroIfEmpty()),
                DateTime.Now,
                DateTime.Now,
                dateTimePicker.Value,
                statusCombo.Text
                );

                orderService.UpdateOrder(order);
                MessageBox.Show("Order Updated Success.");
                PopulateOrderGrid();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Please select order from list in order to edit.");
            }
        }

        private void txtOutWeight_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtInWeight.Text) && !String.IsNullOrWhiteSpace(txtOutWeight.Text))
            {
                double fine;
                double inWeight = Convert.ToDouble(txtInWeight.Text);
                double outWeight = Convert.ToDouble(txtOutWeight.Text.ZeroIfEmpty());
                double labourRate = Convert.ToDouble(txtLabourRate.Text);

                if (outWeight != 0)
                    fine = outWeight - inWeight;
                else
                    fine = 0;

                fine = Math.Round(fine, 2);
                txtFine.Text = fine.ToString();
                double sum = outWeight * labourRate;
                sum = Math.Round(sum, 2);
                txtTotalAmt.Text = sum.ToString();
            }
            else
            {
                txtFine.Text = "0";
                txtTotalAmt.Text = "0";
            }
        }
    }
}
