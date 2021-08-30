using Abhi_Silver_Plating_Shop.Service;
using Abhi_Silver_Plating_Shop.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Abhi_Silver_Plating_Shop
{
    public partial class OrderForm : Form
    {
        private const int ZERO = 0;
        private readonly OrderService orderService = null;
        Model.Unit unit = null;
        private static Model.Stat statastics = null;
        private bool isPaymentDone = false;
        public OrderForm()
        {
            InitializeComponent();
            orderService = new OrderService();
            Cursor.Current = Cursors.Default;
        }

        void FillStat()
        {
            Model.CustomerAccount customerAccount = Repository
                    .DataAccess.Instance.LoadSingleData<Model.CustomerAccount, dynamic>(
               Repository.Queries.SELECT_AMT_INVENTORY_BY_CUSTOMER,
               new { statastics.CustomerId });

            int res = Utility.checkAccountTypeAndReturnValue(customerAccount.Type);
            statastics.DebitAmt = res == 1 ? customerAccount.Amount : 0;
            statastics.CreditAmt = res == 2 ? customerAccount.Amount : 0;
            statastics.GrandAmt = res == 3 ? "0" : customerAccount.Amount.ToString("F") + "-" + customerAccount.Type;
            statastics.RemainingFine = customerAccount.RemainingFine;
            statastics.TotalAmt = customerAccount.OrderTotalAmt;
            if (res == 0)
            {
                statastics.GrandAmt = txtTotalAmt.Text.ConvertElseZero().ToString("F");
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                if (statastics == null)
                {
                    MessageBox.Show("Please load data first");
                    return true;
                }
                if (statastics.OrderStatus == "In Progress")
                {
                    MessageBox.Show("Can not proceed to payment with in progress order!!");
                    return true;
                }
                this.Hide();
                using PaymentForm paymentForm = new();
                Dictionary<String, String> reportForm = new();
                reportForm.Add("customerId", statastics.CustomerId);
                reportForm.Add("fromDate", statastics.FromDate);
                reportForm.Add("toDate", statastics.ToDate);
                reportForm.Add("totalAmount", statastics.TotalAmt.ToString("F"));
                reportForm.Add("totalFine", statastics.TotalFine.ToString());
                reportForm.Add("routedFromOrder", "true");
                reportForm.Add("orderId", statastics.Orders[0].OrderId);

                paymentForm.SetValuesFromReport(reportForm);
                paymentForm.ShowDialog();
                if (paymentForm.DialogResult == DialogResult.OK)
                {
                    isPaymentDone = paymentForm.IsOrderPaymentCompleted;
                    statastics.PaidAmt = paymentForm.GetPaymentStat.PaidAmt;
                    statastics.PaidFine = paymentForm.GetPaymentStat.PaidFine;
                    statastics.TotalFine = paymentForm.GetPaymentStat.TotalFine;
                }

                FillStat(); //making db call to amount_inventory table and fetching data assinging to stat obj

                if (orderGridView.RowCount > 0 && isPaymentDone == true)
                {
                    // to-do print the payment receipt
                    Cursor.Current = Cursors.WaitCursor;
                    MessageBox.Show("printing ...");
                    Utility.GeneratePdf(statastics);
                    ClearForm();
                }
                this.Show();
                Cursor.Current = Cursors.Default;

                return true;
            }

            if (keyData == (Keys.F4)) // this key is used only to print the current order
            {
                if (statastics == null)
                {
                    MessageBox.Show("Please load data first");
                    return true;
                }

                FillStat(); //making db call to amount_inventory table and fetching data assinging to stat obj
                statastics.TotalFine = statastics.RemainingFine;
                MessageBox.Show("printing ...");
                Utility.GeneratePdf(statastics, "OTHER");
                ClearForm();
                return true;
            }

            if (keyData == (Keys.F8)) // this key is used only to print using ctrl+ p printer dialog
            {
                if (statastics == null)
                {
                    MessageBox.Show("Please load data first");
                    return true;
                }

                FillStat(); //making db call to amount_inventory table and fetching data assinging to stat obj
                statastics.TotalFine = statastics.RemainingFine;
                MessageBox.Show("printing ...");
                Utility.GeneratePdf(statastics, "OTHER", false);
                ClearForm();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
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
            UnitService unitService = new();
            unit = unitService.FetchRate(new Model.Unit(null, "KG", ZERO));
            txtLabourRate.Text = unit.Rate.ToString();
        }

        void LoadStats()
        {
            // double totalAmt = orderService.FetchOrderByType(AppConstants.TOTAL_AMOUNT);
            // double totalFine = orderService.FetchOrderByType(AppConstants.TOTAL_FINE);
            Model.Stat stat = CalculateStats();
            lblAmt.Text = "Rs. " + Math.Round(stat.TotalAmt, 2);
            lblInWeight.Text = stat.TotalInWeight.ToString();
            lblOutWeight.Text = stat.TotalOutWeight.ToString();
            lblFine.Text = stat.TotalFine.ToString();

        }

        Model.Stat CalculateStats()
        {
            Model.Stat stat = new();

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
            stat.TotalInWeight = totalInWeight;
            stat.TotalOutWeight = totalOutWeight;
            stat.TotalFine = totalFine;
            stat.TotalAmt = totalAmt;
            return stat;
        }

        void PopulateOrderGrid()
        {
            DataTable dataTable = new Repository.BaseDao().PopulateDataSourceData(Repository.Queries.ORDER_SELECT_QUERY);
            dataTable.DefaultView.Sort = "creation_date desc";
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
            dateTimePicker.Value = DateTime.Now.Date;
            lblCreated.Text = "date";
            lblUpdate.Text = "date";
            statastics = null;
            isPaymentDone = false;
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
            dateTimePicker.MaxDate = DateTime.Now.Date;
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
            string customerName = Utility.GetCells(orderGridView).GetCellValueFromColumnHeader("Customer Name");
            string itemName = Utility.GetCells(orderGridView).GetCellValueFromColumnHeader("Item Name");
            string status = Utility.GetCells(orderGridView).GetCellValueFromColumnHeader("status");

            DateTime creationDate = ((DateTime)Utility.GetCells(orderGridView)["creation_date"].Value);
            DateTime upadtedDate = ((DateTime)Utility.GetCells(orderGridView)["last_modified"].Value);

            lblCreated.Text = creationDate.TimeAgo();
            lblUpdate.Text = upadtedDate.TimeAgo();


            Model.Order order = new Model.Order
            {
                OrderId = txtOrderId.Text,
                InWeight = txtInWeight.Text.ConvertElseZero(),
                ItemId = itemCombo.SelectedValue.ToString(),
                ItemName = itemName,
                CustomerId = customerCombo.SelectedValue.ToString(),
                OutWeight = txtOutWeight.Text.ConvertElseZero(),
                Fine = txtFine.Text.ConvertElseZero(),
                TotalAmount = txtTotalAmt.Text.ConvertElseZero(),
                LabourRate = txtLabourRate.Text.ConvertElseZero(),
                Status = Utility.GetOrderStatus(txtOutWeight.Text.ConvertElseZero()),
                Date = dateTimePicker.Value,
                CreatedDate = creationDate
            };
            List<Model.Order> orders = new();
            orders.Add(order);
            statastics = new Model.Stat
            {
                CustomerId = customerCombo.SelectedValue.ToString(),
                CustomerName = customerName,
                TotalAmt = txtTotalAmt.Text.ConvertElseZero(),
                TotalFine = txtFine.Text.ConvertElseZero(),
                TotalInWeight = txtInWeight.Text.ConvertElseZero(),
                TotalOutWeight = txtOutWeight.Text.ConvertElseZero(),
                FromDate = DateTime.Now.ToString("MMMM dd, yyyy"),
                ToDate = DateTime.Now.ToString("MMMM dd, yyyy"),
                OrderStatus = status,
                Orders = orders,
                Address = Utility.GetShopAddress()
            };
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
            if (statastics.OrderStatus == "Completed")
            {
                MessageBox.Show("Completed order can not be edited !!");
                return;
            }

            if (!String.IsNullOrWhiteSpace(txtOrderId.Text))
            {

                Model.Order order = new(
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

        private void orderGridView_DoubleClick(object sender, EventArgs e)
        {
        }

        private void btnAdd_Enter(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.CornflowerBlue;
        }

        private void btnAdd_Leave(object sender, EventArgs e)
        {
            btnAdd.BackColor = Control.DefaultBackColor;
        }

        private void btnEdit_Enter(object sender, EventArgs e)
        {
            btnEdit.BackColor = Color.CornflowerBlue;
        }

        private void btnEdit_Leave(object sender, EventArgs e)
        {
            btnEdit.BackColor = Control.DefaultBackColor;
        }

        private void btnClear_Enter(object sender, EventArgs e)
        {
            btnClear.BackColor = Color.CornflowerBlue;
        }

        private void btnClear_Leave(object sender, EventArgs e)
        {
            btnClear.BackColor = Control.DefaultBackColor;
        }
    }
}
