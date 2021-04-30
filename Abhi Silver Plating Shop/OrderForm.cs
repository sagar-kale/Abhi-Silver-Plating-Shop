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
        private const int ZERO = 0;
        private readonly OrderService orderService = null;
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
            unit = unitService.FetchRate(new Model.Unit(null, "KG", ZERO));
            txtLabourRate.Text = unit.Rate.ToString();
        }

        void LoadStats()
        {
            // double totalAmt = orderService.FetchOrderByType(AppConstants.TOTAL_AMOUNT);
            // double totalFine = orderService.FetchOrderByType(AppConstants.TOTAL_FINE);

            double totalOutWeight = ZERO, totalFine = ZERO, totalInWeight = ZERO, totalAmt = ZERO;
            for (int i = ZERO; i < orderGridView.RowCount; i++)
            {
                DataGridViewRow dataGridViewRow = orderGridView.Rows[i];
                string outWeightStr = dataGridViewRow.Cells["out_weight"].Value.ToString();
                string inWeightStr = dataGridViewRow.Cells["in_weight"].Value.ToString();
                string fineStr = dataGridViewRow.Cells["fine"].Value.ToString();
                string amtStr = dataGridViewRow.Cells["total_amount"].Value.ToString();
                double outWeight = outWeightStr.ConvertElseZero();
                double inWeight = inWeightStr.ConvertElseZero();
                double fine = fineStr.ConvertElseZero();
                double amt = amtStr.ConvertElseZero();

                totalOutWeight += outWeight;
                totalInWeight += inWeight;
                totalFine += fine;
                totalAmt += amt;
            }
            lblAmt.Text = "Rs. " + totalAmt;
            lblInWeight.Text = totalInWeight.ToString();
            lblOutWeight.Text = totalOutWeight.ToString();
            lblFine.Text = totalFine.ToString();

        }

        void PopulateOrderGrid()
        {
            DataTable dataTable = new Repository.BaseDao().PopulateDataSourceData(Repository.Queries.ORDER_SELECT_QUERY);
            orderGridView.DataSource = dataTable;
            orderGridView.Columns["date"].DefaultCellStyle.Format = "dd-MMM-yyyy";
            orderGridView.Columns["orderId"].Visible = false;
            orderGridView.Columns["customerId"].Visible = false;
            orderGridView.Columns["itemId"].Visible = false;
            orderGridView.Columns["creation_date"].Visible = false;
            orderGridView.Columns["last_modified"].Visible = false;

            LoadStats();
        }

        void ClearForm()
        {
            btnEdit.Enabled = false;
            btnAdd.Enabled = true;
            txtOrderId.Clear();
            txtFine.Clear();
            txtInWeight.Clear();
            txtOutWeight.Clear();
            dateTimePicker.Value = DateTime.Now;
            lblCreated.Text = "date";
            lblUpdate.Text = "date";

        }

        static bool CheckValidCustomerAndItem(Model.Order order)
        {
            bool valid = true;
            if (String.IsNullOrWhiteSpace(order.ItemId))
            {
                valid = false;
                MessageBox.Show("Item does not exists !", "Invalid Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return valid;
            }

            if (String.IsNullOrWhiteSpace(order.CustomerId))
            {
                valid = false;
                MessageBox.Show("Customer does not exists !", "Invalid Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return valid;
            }
            return valid;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Model.Order order = new(
                null,
                itemCombo.SelectedValue.ToString(),
                customerCombo.SelectedValue.ToString(),
                txtInWeight.Text.ConvertElseZero(),
                txtOutWeight.Text.ConvertElseZero(),
                txtFine.Text.ConvertElseZero(),
                txtTotalAmt.Text.ConvertElseZero(),
                txtLabourRate.Text.ConvertElseZero(),
                DateTime.Now,
                DateTime.Now,
                dateTimePicker.Value.Date,
                Utility.GetOrderStatus(txtOutWeight.Text.ConvertElseZero())
                );

            if (!CheckValidCustomerAndItem(order))
                return;

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
            label1.Text = Utility.appName;
        }

        private void orderGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAdd.Enabled = false;
            btnEdit.Enabled = true;

            txtOrderId.Text = Utility.CellValueByIndex(ZERO, orderGridView);
            customerCombo.Text = Utility.CellValueByIndex(1, orderGridView);
            itemCombo.Text = Utility.CellValueByIndex(2, orderGridView);
            txtInWeight.Text = Utility.GetCells(orderGridView).GetCellValueFromColumnHeader("in_weight");
            txtOutWeight.Text = Utility.GetCells(orderGridView).GetCellValueFromColumnHeader("out_weight");
            txtFine.Text = Utility.GetCells(orderGridView).GetCellValueFromColumnHeader("fine");
            txtLabourRate.Text = Utility.GetCells(orderGridView).GetCellValueFromColumnHeader("labour_rate");
            dateTimePicker.Value = ((DateTime)Utility.GetCells(orderGridView)["date"].Value);
            txtTotalAmt.Text = Utility.GetCells(orderGridView).GetCellValueFromColumnHeader("total_amount");

            DateTime creationDate = ((DateTime)Utility.GetCells(orderGridView)["creation_date"].Value);
            DateTime upadtedDate = ((DateTime)Utility.GetCells(orderGridView)["last_modified"].Value);

            lblCreated.Text = creationDate.TimeAgo();
            lblUpdate.Text = upadtedDate.TimeAgo();

        }

        private void orderGridView_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            (orderGridView.DataSource as DataTable).DefaultView.RowFilter = e.FilterString;
            LoadStats();
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
            PopulateOrderGrid();
            this.Show();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ItemForm().ShowDialog();
            LoadItems();
            PopulateOrderGrid();
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
                txtInWeight.Text.ConvertElseZero(),
                txtOutWeight.Text.ConvertElseZero(),
                txtFine.Text.ConvertElseZero(),
                txtTotalAmt.Text.ConvertElseZero(),
                txtLabourRate.Text.ConvertElseZero(),
                DateTime.Now,
                DateTime.Now,
                dateTimePicker.Value.Date,
                Utility.GetOrderStatus(txtOutWeight.Text.ConvertElseZero())
                );

                if (!CheckValidCustomerAndItem(order))
                    return;

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
            CalculateTotalAmtAndFine();
        }

        void CalculateTotalAmtAndFine()
        {

            double fine;
            double inWeight = txtInWeight.Text.ConvertElseZero();
            double outWeight = txtOutWeight.Text.ConvertElseZero();
            double labourRate = txtLabourRate.Text.ConvertElseZero();

            if (outWeight != ZERO)
                fine = outWeight - inWeight;
            else
                fine = ZERO;

            fine = Math.Round(fine, 2);
            txtFine.Text = fine.ToString();
            double sum = inWeight * (labourRate / 1000);
            sum = Math.Round(sum, 2);
            txtTotalAmt.Text = sum.ToString();

        }

        private void txtInWeight_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalAmtAndFine();
        }
    }
}
