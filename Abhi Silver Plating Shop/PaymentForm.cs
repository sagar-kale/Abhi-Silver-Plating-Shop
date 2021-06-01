using Abhi_Silver_Plating_Shop.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abhi_Silver_Plating_Shop
{
    public partial class PaymentForm : Form
    {
        Dictionary<String, String> reportFormValues = null;
        Repository.IDataAccess dataAccess = null;
        private bool isPaymentCompleted = false;
        private bool isOrderPaymentCompleted = false;
        private Model.Stat paymentStat = null;
        private Service.PaymentService paymentService = null;
        Model.CustomerAccount customerAccount = null;


        public void SetValuesFromReport(Dictionary<String, String> reportForm)
        {
            this.reportFormValues = reportForm;
        }

        public bool IsPaymentCompleted // retrieving a value from
        {
            get
            {
                return this.isPaymentCompleted;
            }
        }

        public bool IsOrderPaymentCompleted // retrieving a value from
        {
            get
            {
                return this.isOrderPaymentCompleted;
            }
        }

        public Model.Stat GetPaymentStat { get { return this.paymentStat; } }
        public PaymentForm()
        {
            InitializeComponent();
            dataAccess = Repository.DataAccess.Instance;
            paymentService = new Service.PaymentService();
        }

        void LoadPaymentInfo()
        {
            customerAccount = dataAccess.LoadSingleData<Model.CustomerAccount, dynamic>(
                 Repository.Queries.SELECT_AMT_INVENTORY_BY_CUSTOMER,
                 new { CustomerId = txtCustId.Text });
            int res = Utility.checkAccountTypeAndReturnValue(customerAccount.Type);

            txtPaidAmt.Text = customerAccount.OrderTotalAmt.ToString("F");
            if (res == 1)
            {
                txtDebitAmt.Text = customerAccount.Amount.ToString();
                txtCreditAmt.Text = "0";
            }
            else if (res == 2)
            {
                txtCreditAmt.Text = customerAccount.Amount.ToString();
                txtDebitAmt.Text = "0";
                checkBoxUseCredit.Enabled = true;
            }
            else
            {
                txtDebitAmt.Text = customerAccount.Amount.ToString();
                txtCreditAmt.Text = customerAccount.Amount.ToString();
            }
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            label1.Text = Utility.appName;
            checkBoxUseCredit.Enabled = false;

            if (reportFormValues == null)
            {
                MessageBox.Show("Data not loaded properly, please close the form and reopen again !");
                return;
            }

            txtCustId.Text = reportFormValues["customerId"];
            txtFromDate.Text = reportFormValues["fromDate"];
            txtToDate.Text = reportFormValues["toDate"];

            LoadPaymentInfo();

            txtTotalAmt.Text = customerAccount.OrderTotalAmt.ToString("F");
            txtTotalFine.Text = customerAccount.RemainingFine.ToString();
            txtPaidFine.Text = txtTotalFine.Text;

            String date = dataAccess.LoadSingleData<String, dynamic>(Repository.Queries.PAYMENT_LAST_DATE, new { customerId = txtCustId.Text });
            if (date != null)
            {
                lblLastOrderPlaced.Text = DateTime.ParseExact(date, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).ToString("MMM dd, yyyy hh:mm tt");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        void DoPaymentPreProcess(bool isPayLater)
        {

            double paidAmt = txtPaidAmt.Text.ConvertElseZero();
            double totalAmt = txtTotalAmt.Text.ConvertElseZero();
            double paidFine = txtPaidFine.Text.ConvertElseZero();
            double totalFine = customerAccount.RemainingFine;
            int res = Utility.checkAccountTypeAndReturnValue(customerAccount.Type);

            customerAccount.RemainingFine -= paidFine;

            if (paidAmt != 0 && !isPayLater)
            {
                if (paidAmt > totalAmt)
                {
                    if (res == 1)
                    {
                        customerAccount.Amount = paidAmt - customerAccount.Amount;

                    }
                    else
                    {
                        customerAccount.Amount += (paidAmt - totalAmt);
                    }
                    customerAccount.OrderTotalAmt = 0;
                    customerAccount.Type = "CREDIT";
                }
                else if (totalAmt > paidAmt && checkBoxUseCredit.Checked == false)
                {
                    double sub = totalAmt - paidAmt;
                    customerAccount.Amount += sub;
                    customerAccount.Type = "DEBIT";
                    customerAccount.OrderTotalAmt -= paidAmt;
                }
                else
                {
                    customerAccount.Amount = 0;
                    customerAccount.OrderTotalAmt = 0;
                    customerAccount.Type = "N";
                }
            }
            else if (isPayLater)
            {
                customerAccount.Amount = 0;
                customerAccount.Amount += paidAmt;
                customerAccount.Type = "DEBIT";
            }

            paymentService.UpdateAmtInventory(customerAccount); // updating customer 

            paymentStat = new Model.Stat
            {
                PaidAmt = txtPaidAmt.Text.ConvertElseZero(),
                PaidFine = txtPaidFine.Text.ConvertElseZero(),
                TotalFine = totalFine
            };

            // inserting payment entry
            paymentService.MakePayment(new
            {
                OrderId = reportFormValues["orderId"],
                customerAccount.AmountId,
                amount_paid = paymentStat.PaidAmt,
                fine_paid = paymentStat.PaidFine,
                customerId = customerAccount.CustomerId
            });

            MessageBox.Show("Payment completed...");

            if (reportFormValues["routedFromOrder"] == "true")
                isOrderPaymentCompleted = true;
            else
                isPaymentCompleted = true;
        }

        private void btnPayFull_Click(object sender, EventArgs e)
        {

            DoPaymentPreProcess(false);
            this.DialogResult = DialogResult.OK; // assinging this will close the current opened dialog
        }

        private void txtTotalAmt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxUseCredit_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxUseCredit.Enabled = false;

            if (checkBoxUseCredit.Checked == true)
            {
                double paidAmt = txtPaidAmt.Text.ConvertElseZero();
                if (customerAccount.Amount > paidAmt)
                {
                    customerAccount.Amount -= paidAmt;
                    txtPaidAmt.Text = "0";
                    customerAccount.OrderTotalAmt = 0;
                }
                else
                {

                    double amt = paidAmt - customerAccount.Amount;
                    txtPaidAmt.Text = amt.ToString();
                    customerAccount.OrderTotalAmt = amt;
                }

                txtPaidAmt.Enabled = false;
                txtPaidFine.Enabled = false;
            }
        }

        private void btnPayLater_Click(object sender, EventArgs e)
        {
            DoPaymentPreProcess(true);
            this.DialogResult = DialogResult.OK;
        }
    }
}
