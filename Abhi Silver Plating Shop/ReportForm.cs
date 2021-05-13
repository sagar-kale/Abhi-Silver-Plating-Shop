using Abhi_Silver_Plating_Shop.TemplateEngine;
using Abhi_Silver_Plating_Shop.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.IO;
using iText.Html2pdf;
using Abhi_Silver_Plating_Shop.Repository;

namespace Abhi_Silver_Plating_Shop
{
    public partial class ReportForm : Form
    {
        private readonly int ZERO = 0;
        private Model.Stat statastics = null;

        public ReportForm()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F4))
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
                reportForm.Add("totalAmount", statastics.TotalAmt.ToString());
                reportForm.Add("totalFine", statastics.TotalFine.ToString());
                paymentForm.SetValuesFromReport(reportForm);
                paymentForm.ShowDialog(this);

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
        void ClearForm()
        {

            fromDatePicker.Value = DateTime.Now.Date;
            toDatePicker.Value = DateTime.Now.Date;
            btnGenerate.Enabled = false;
            statastics = null;
        }
        void LoadStats()
        {
            // double totalAmt = orderService.FetchOrderByType(AppConstants.TOTAL_AMOUNT);
            // double totalFine = orderService.FetchOrderByType(AppConstants.TOTAL_FINE);
            Model.Stat stat = CalculateStats();
            lblAmt.Text = "Rs. " + Math.Round(stat.TotalAmt, 2); ;
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
            /*DataTable dataTable = new Repository.BaseDao()
                .PopulateReportData(Repository.Queries.ORDER_SELECT_QUERY_BY_CUSTOMER,
                                    customerCombo.SelectedValue.ToString(),
                                    fromDatePicker.Value.Date,
            
            toDatePicker.Value.Date); */

            DataTable dataTable = DataAccess.Instance.PopulateGrid<dynamic>(
                Queries.ORDER_SELECT_QUERY_BY_CUSTOMER,
                new
                {
                    customerId = customerCombo.SelectedValue.ToString(),
                    fromDate = fromDatePicker.Value.Date,
                    toDate = toDatePicker.Value.Date
                });

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
        }



        private void ReportForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            PopulateReportGrid();
            ClearForm();
            fromDatePicker.MaxDate = DateTime.Now.Date;
            toDatePicker.MaxDate = DateTime.Now.Date;
            label1.Text = Utility.appName;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            btnGenerate.Enabled = false;
            GeneratePdf();
        }

        void setStat()
        {
            statastics = CalculateStats();


            Model.Address address = new()
            {
                City = Utility.GetEnvironmentProperty("city"),
                Pincode = Utility.GetEnvironmentProperty("pin"),
                Street = Utility.GetEnvironmentProperty("street"),
                Phone = Utility.GetEnvironmentProperty("phone"),
            };
            statastics.Address = address;
            statastics.FromDate = fromDatePicker.Value.ToString("MMMM dd, yyyy");
            statastics.ToDate = toDatePicker.Value.ToString("MMMM dd, yyyy");
        }

        void GeneratePdf()
        {


            Engine templateEngine = new();

            Model.ReportViewModel<Model.Stat> reportViewModel = new()
            {
                Name = Utility.appName,
                Obj = statastics
            };

            string htmlReport = templateEngine.RenderHtmlTemplate(reportViewModel);
            Clipboard.SetText(htmlReport);

            using SaveFileDialog sdf = new() { Filter = "PDF file|*.pdf", ValidateNames = true };
            if (sdf.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using FileStream stream = new(sdf.FileName, FileMode.OpenOrCreate);
                    ConverterProperties converter = new();
                    HtmlConverter.ConvertToPdf(htmlReport, stream);
                    System.Windows.Controls.WebBrowser webbrowser = new System.Windows.Controls.WebBrowser();
                    string fullPath = Path.GetFullPath(sdf.FileName);
                    MessageBox.Show("PDF path: " + fullPath, "Report Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    webbrowser.Navigate(fullPath);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            PopulateReportGrid();
            setStat();
            if (reportGridView.RowCount > 0)
                btnGenerate.Enabled = true;
        }
    }
}
