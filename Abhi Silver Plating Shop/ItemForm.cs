using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Abhi_Silver_Plating_Shop
{
    public partial class ItemForm : Form
    {
        private Service.ItemService itemService = null;
        private Model.Item updateItem = null;
        public ItemForm()
        {
            InitializeComponent();
            itemService = new Service.ItemService();

        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                ItemNameErrProvider.SetError(txtItemName, "Please Enter Item Name");
            }
            else
            {
                ItemNameErrProvider.Clear();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ItemForm_Load(object sender, EventArgs e)
        {
            PopulateItemGrid();
            ClearForm();
            label1.Text = Utils.Utility.appName;
        }
        void PopulateItemGrid()
        {
            DataTable dataTable = new Repository.BaseDao().PopulateDataSourceData(Repository.Queries.ITEM_SELECT_QUERY);
            itemGridView.DataSource = dataTable;
            itemGridView.Columns["itemId"].Visible = false;
        }

        void ClearForm()
        {

            txtItemName.Clear();
            updateItem = null;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                MessageBox.Show("Please Enter Item Name");
                txtItemName.Focus();
                txtItemName.Text = "";
            }
            else if (updateItem != null && !string.IsNullOrEmpty(updateItem.Id))
            {
                MessageBox.Show("Please Enter New Item Details");
                updateItem = null;
                ClearForm();
            }
            else
            {
                Model.Item item = new Model.Item(null, txtItemName.Text);
                bool isAdded = itemService.AddItem(item);
                if (isAdded)
                {
                    MessageBox.Show("Item Added !!");
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Item adding failed..");
                }
                PopulateItemGrid();

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (updateItem != null && !string.IsNullOrWhiteSpace(updateItem.Id))
            {
                updateItem.Name = txtItemName.Text;
                itemService.UpdateItem(updateItem);
                MessageBox.Show("Item Updated Success.");
                PopulateItemGrid();
                updateItem = null;
                ClearForm();
            }
            else
            {
                MessageBox.Show("PLease select Item from list in order to edit.");
            }
        }

        private void itemGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = true;
            updateItem = new Model.Item
            {
                Id = Utils.Utility.CellValueByIndex(0, itemGridView)
            };
            txtItemName.Text = Utils.Utility.CellValueByIndex(1, itemGridView);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (updateItem != null && !string.IsNullOrWhiteSpace(updateItem.Id))
            {

                if (itemService.DeleteItem(updateItem))
                {
                    MessageBox.Show("Item delete success.");
                }
                PopulateItemGrid();
                updateItem = null;
                ClearForm();
            }
            else
            {
                MessageBox.Show("PLease select item from list in order to delete.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToLower(e.KeyChar);
        }
    }
}
