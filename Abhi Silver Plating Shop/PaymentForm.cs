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
        public void SetValuesFromReport(Dictionary<String, String> reportForm)
        {
            this.reportFormValues = reportForm;
        }
        public PaymentForm()
        {
            InitializeComponent();
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            label1.Text = Utils.Utility.appName;
            if (reportFormValues == null)
            {
                MessageBox.Show("Data not loaded properly, please close the form and reopen again !");
                return;
            }
            txtCustId.Text = reportFormValues["customerId"];
            txtTotalAmt.Text = reportFormValues["totalAmount"];
            txtTotalFine.Text = reportFormValues["totalFine"];
            txtFromDate.Text = reportFormValues["fromDate"];
            txtToDate.Text = reportFormValues["toDate"];
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
