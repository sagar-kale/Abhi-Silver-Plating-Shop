using Abhi_Silver_Plating_Shop.TemplateEngine;
using Abhi_Silver_Plating_Shop.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.IO;
using iText.Html2pdf;
using Abhi_Silver_Plating_Shop.Repository;
using iText.Kernel.Pdf;
using RawPrint;

namespace Abhi_Silver_Plating_Shop
{
    public partial class ReportForm : Form
    {
        private readonly int ZERO = 0;
        private Model.Stat statastics = null;
        private bool isPaymentDone = false;
        private Model.CustomerAccount customerAccount = null;

        public ReportForm()
        {
            InitializeComponent();
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
                this.Hide();
                using PaymentForm paymentForm = new();
                Dictionary<String, String> reportForm = new();
                reportForm.Add("customerId", statastics.CustomerId);
                reportForm.Add("fromDate", statastics.FromDate);
                reportForm.Add("toDate", statastics.ToDate);
                reportForm.Add("totalAmount", statastics.TotalAmt.ToString("F"));
                reportForm.Add("totalFine", statastics.TotalFine.ToString());
                reportForm.Add("routedFromOrder", "false");
                reportForm.Add("orderId", statastics.Orders[0].OrderId);
                paymentForm.SetValuesFromReport(reportForm);
                paymentForm.ShowDialog();
                isPaymentDone = paymentForm.IsPaymentCompleted;
                if (reportGridView.RowCount > 0 && isPaymentDone == true)
                    btnGenerate.Enabled = true;
                this.Show();

                return true;
            }
            else if (keyData == (Keys.F4))
            {
                if (statastics == null)
                {
                    MessageBox.Show("Please load data first");
                    return true;
                }

                MessageBox.Show("Printing report...");
                GeneratePdf(true);
                ClearForm();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        Model.Stat CalculateStats()
        {
            Model.Stat stat = new();
            List<Model.Order> orderList = new();

            double totalOutWeight = ZERO, totalFine = ZERO, totalInWeight = ZERO, totalAmt = ZERO;
            for (int i = ZERO; i < reportGridView.RowCount; i++)
            {

                DataGridViewRow dataGridViewRow = reportGridView.Rows[i];
                string outWeightStr = dataGridViewRow.Cells["out_weight"].Value.ToString();
                string inWeightStr = dataGridViewRow.Cells["in_weight"].Value.ToString();
                string fineStr = dataGridViewRow.Cells["fine"].Value.ToString();
                string amtStr = dataGridViewRow.Cells["total_amount"].Value.ToString();
                DateTime date = ((DateTime)dataGridViewRow.Cells["date"].Value).Date;
                string customerName = dataGridViewRow.Cells.GetCellValueFromColumnHeader("Customer Name");
                string itemName = dataGridViewRow.Cells.GetCellValueFromColumnHeader("Item Name");


                double outWeight = outWeightStr.ConvertElseZero();
                double inWeight = inWeightStr.ConvertElseZero();
                double fine = fineStr.ConvertElseZero();
                double amt = amtStr.ConvertElseZero();

                // setting up order
                Model.Order order = new()
                {
                    OutWeight = outWeight,
                    InWeight = inWeight,
                    Fine = fine,
                    TotalAmount = amt,
                    ItemName = itemName,
                    Date = date
                };
                orderList.Add(order);

                totalOutWeight += outWeight;
                totalInWeight += inWeight;
                totalFine += fine;
                totalAmt += amt;
                stat.CustomerName = customerName;
                stat.CustomerId = customerCombo.SelectedValue.ToString();
            }
            stat.TotalInWeight = totalInWeight;
            stat.TotalOutWeight = totalOutWeight;
            stat.TotalFine = totalFine;
            stat.TotalAmt = totalAmt;
            stat.Orders = orderList;

            return stat;
        }
        void LoadCustomers()
        {
            DataTable dataTable = new BaseDao().PopulateDataSourceData(Queries.CUSTOMER_SELECT_QUERY);
            this.customerCombo.DataSource = dataTable;
            this.customerCombo.DisplayMember = "name";
            this.customerCombo.ValueMember = "customerId";

        }

        void LoadCustomerAccount()
        {

            customerAccount = DataAccess.Instance.LoadSingleData<Model.CustomerAccount, dynamic>(
                 Queries.SELECT_AMT_INVENTORY_BY_CUSTOMER,
                 new { CustomerId = customerCombo.SelectedValue.ToString() });
            int res = Utility.checkAccountTypeAndReturnValue(customerAccount.Type);
            lblAmt.Text = "Rs. " + customerAccount.OrderTotalAmt.ToString("F");
            lblFine.Text = customerAccount.RemainingFine.ToString();
        }
        void ClearForm()
        {

            fromDatePicker.Value = DateTime.Now.Date;
            toDatePicker.Value = DateTime.Now.Date;
            btnGenerate.Enabled = false;
            statastics = null;
            isPaymentDone = false;
        }
        void LoadStats()
        {
            // double totalAmt = orderService.FetchOrderByType(AppConstants.TOTAL_AMOUNT);
            // double totalFine = orderService.FetchOrderByType(AppConstants.TOTAL_FINE);
            Model.Stat stat = CalculateStats();
            lblAmt.Text = "Rs. " + stat.TotalAmt.ToString("F");
            lblInWeight.Text = stat.TotalInWeight.ToString();
            lblOutWeight.Text = stat.TotalOutWeight.ToString();
            lblFine.Text = stat.TotalFine.ToString();

            string date = DataAccess.Instance.LoadSingleData<string, dynamic>(
              Queries.ORDER_LAST_PLACED_BY_CUSTOMER,
              new { customerId = customerCombo.SelectedValue.ToString() });

            lblLastOrderPlaced.Text = date.FormatDate();


        }

        void PopulateReportGrid()
        {
            DataTable dataTable;
            if (cmbType.SelectedItem.ToString() == "ALL")
            {
                dataTable = DataAccess.Instance.PopulateGrid<dynamic>(
                  Queries.ORDER_SELECT_QUERY_BY_CUSTOMER,
                  new
                  {
                      customerId = customerCombo.SelectedValue.ToString()
                  });

            }
            else
            {
                dataTable = DataAccess.Instance.PopulateGrid<dynamic>(
                  Queries.ORDER_SELECT_QUERY_BY_CUSTOMER_AND_DATE,
                  new
                  {
                      customerId = customerCombo.SelectedValue.ToString(),
                      fromDate = fromDatePicker.Value.Date,
                      toDate = toDatePicker.Value.Date
                  });
            }

            reportGridView.DataSource = dataTable;
            reportGridView.Columns["date"].DefaultCellStyle.Format = "dd-MMM-yyyy";
            reportGridView.Columns["orderId"].Visible = false;
            reportGridView.Columns["customerId"].Visible = false;
            reportGridView.Columns["itemId"].Visible = false;
            reportGridView.Columns["creation_date"].Visible = false;
            reportGridView.Columns["last_modified"].Visible = false;
            reportGridView.Columns["date"].Visible = false;
            reportGridView.Columns["Customer Name"].Visible = false;
            reportGridView.Columns["labour_rate"].Visible = false;
            reportGridView.Columns["status"].Visible = false;

            LoadStats();
            LoadCustomerAccount();
        }



        private void ReportForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            cmbType.SelectedItem = "ALL";
            PopulateReportGrid();
            ClearForm();
            fromDatePicker.MaxDate = DateTime.Now.Date;
            toDatePicker.MaxDate = DateTime.Now.Date;
            label1.Text = Utility.appName;
            toDatePicker.Enabled = false;
            fromDatePicker.Enabled = false;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            btnGenerate.Enabled = false;
            GeneratePdf();
        }

        void setStat()
        {
            statastics = CalculateStats();
            if (customerAccount != null)
            {
                int res = Utility.checkAccountTypeAndReturnValue(customerAccount.Type);
                statastics.DebitAmt = res == 1 ? customerAccount.Amount : 0;
                statastics.CreditAmt = res == 2 ? customerAccount.Amount : 0;
                statastics.GrandAmt = res == 3 ? "0" : customerAccount.Amount.ToString("F") + "-" + customerAccount.Type;
                statastics.RemainingFine = customerAccount.RemainingFine;
                statastics.TotalAmt = customerAccount.OrderTotalAmt;
                statastics.TotalFine = statastics.RemainingFine;
                if (res == 0)
                {

                    statastics.GrandAmt = statastics.TotalAmt.ToString("F");
                }
            }

            statastics.Address = Utility.GetShopAddress();
            statastics.FromDate = fromDatePicker.Value.ToString("MMMM dd, yyyy");
            statastics.ToDate = toDatePicker.Value.ToString("MMMM dd, yyyy");
        }

        void GeneratePdf(bool isf4 = false)
        {
            if (isf4 == false)
                isPaymentDone = false;
            Utility.GeneratePdf(statastics, "NOT_PAID_REPORT");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            PopulateReportGrid();
            setStat();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedItem.ToString() == "DATEWISE")
            {
                fromDatePicker.Enabled = true;
                toDatePicker.Enabled = true;
            }
            else
            {
                fromDatePicker.Enabled = false;
                toDatePicker.Enabled = false;
            }
        }
    }
}
