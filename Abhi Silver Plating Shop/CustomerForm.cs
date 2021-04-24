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
        private Service.CustomerService customerService = null;
        Model.Customer updateCustomer = null;
        public CustomerForm()
        {
            InitializeComponent();
            customerService = new Service.CustomerService();
        }

        void PopulateCustomerGrid()
        {
            DataTable dataTable = new Repository.BaseDao().PopulateDataSourceData(Repository.Queries.CUSTOMER_SELECT_QUERY);
            customerGridView.DataSource = dataTable;
            customerGridView.Columns["customerId"].Visible = false;
        }

        void ClearForm()
        {
            txtCustAddr.Clear();
            txtCustName.Clear();
            txtCustEmail.Clear();
            txtCustMob.Clear();
        }
        private void CustomerForm_Load(object sender, EventArgs e)
        {
            PopulateCustomerGrid();
        }

        private void customerGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            updateCustomer = new Model.Customer();
            updateCustomer.Id = Utils.Utility.CellValueByIndex(0, customerGridView);
            txtCustName.Text = Utils.Utility.CellValueByIndex(1, customerGridView);
            txtCustAddr.Text = Utils.Utility.CellValueByIndex(2, customerGridView);
            txtCustEmail.Text = Utils.Utility.CellValueByIndex(3, customerGridView);
            txtCustMob.Text = Utils.Utility.CellValueByIndex(4, customerGridView);
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustName.Text))
            {
                MessageBox.Show("Please Enter Cutomer Name");
                txtCustName.Focus();
                txtCustName.Text = "";
            }
            else
            {
                Model.Customer customer = new Model.Customer(
                    null,
                    txtCustName.Text,
                    txtCustEmail.Text,
                    txtCustAddr.Text,
                    txtCustMob.Text
                    );
                bool isAdded = customerService.AddCustomer(customer);
                if (isAdded)
                {
                    MessageBox.Show("Customer Added !!");
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Customer adding failed..");
                }
                PopulateCustomerGrid();

            }
        }

        private void txtCustMob_TextChanged(object sender, EventArgs e)
        {
            if (txtCustMob.TextLength < 10 || txtCustMob.TextLength > 10)
            {
                mobErrProvider.SetError(txtCustMob, "Please Enter 10 digit mobile number");
            }
            else
            {
                mobErrProvider.Clear();
            }
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (updateCustomer != null)
            {
                updateCustomer.Name = txtCustName.Text;
                updateCustomer.Address = txtCustAddr.Text;
                updateCustomer.Email = txtCustEmail.Text;
                updateCustomer.Mobile = txtCustMob.Text;
            }


        }
    }
}
