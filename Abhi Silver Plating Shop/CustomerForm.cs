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
            updateCustomer = null;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = true;
        }
        private void CustomerForm_Load(object sender, EventArgs e)
        {
            PopulateCustomerGrid();
            ClearForm();
            label1.Text = Utils.Utility.appName;
        }

        private void customerGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = true;
            updateCustomer = new Model.Customer();
            updateCustomer.Id = Utils.Utility.CellValueByIndex(0, customerGridView);
            txtCustName.Text = Utils.Utility.CellValueByIndex(1, customerGridView);
            txtCustAddr.Text = Utils.Utility.CellValueByIndex(2, customerGridView);
            txtCustEmail.Text = Utils.Utility.CellValueByIndex(3, customerGridView);
            txtCustMob.Text = Utils.Utility.CellValueByIndex(4, customerGridView);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
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
            else if (updateCustomer != null && !string.IsNullOrEmpty(updateCustomer.Id))
            {
                MessageBox.Show("Please Enter New Customer Details");
                updateCustomer = null;
                ClearForm();
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (updateCustomer != null && !string.IsNullOrWhiteSpace(updateCustomer.Id))
            {
                updateCustomer.Name = txtCustName.Text;
                updateCustomer.Address = txtCustAddr.Text;
                updateCustomer.Email = txtCustEmail.Text;
                updateCustomer.Mobile = txtCustMob.Text;
                customerService.UpdateCustomer(updateCustomer);
                MessageBox.Show("Customer Updated Success.");
                PopulateCustomerGrid();
                updateCustomer = null;
                ClearForm();
            }
            else
            {
                MessageBox.Show("PLease select customer from list in order to edit.");
            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (updateCustomer != null && !string.IsNullOrWhiteSpace(updateCustomer.Id))
            {

                if (customerService.DeleteCustomer(updateCustomer))
                {
                    MessageBox.Show("Customer delete success.");
                }
                PopulateCustomerGrid();
                updateCustomer = null;
                ClearForm();
            }
            else
            {
                MessageBox.Show("PLease select customer from list in order to delete.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void txtCustName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToLower(e.KeyChar);
        }

        private void txtCustAddr_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToLower(e.KeyChar);
        }

        private void txtCustEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToLower(e.KeyChar);
        }
    }
}
