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
        public OrderForm()
        {
            InitializeComponent();
        }

        void PopulateComboBox()
        {
            DataTable dataTable = new Repository.BaseDao().PopulateDataSourceData(Repository.Queries.ITEM_SELECT_QUERY);
            this.itemCombo.DataSource = dataTable;
            this.itemCombo.DisplayMember = "Name";
            this.itemCombo.ValueMember = "itemId";
        }

        void PopulateOrderGrid()
        {
            DataTable dataTable = new Repository.BaseDao().PopulateDataSourceData(Repository.Queries.ORDER_SELECT_QUERY);
            orderGridView.DataSource = dataTable;
            orderGridView.Columns["orderId"].Visible = false;
            orderGridView.Columns["customerId"].Visible = false;
            orderGridView.Columns["itemId"].Visible = false;
        }

        void ClearForm()
        {
            btnEdit.Enabled = false;
            btnAdd.Enabled = true;
        }
        private void itemCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show(itemCombo.SelectedValue.ToString());
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            PopulateComboBox();
            PopulateOrderGrid();
        }

        private void itemCombo_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void orderGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void orderGridView_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            (orderGridView.DataSource as DataTable).DefaultView.RowFilter = e.FilterString;
        }
    }
}
