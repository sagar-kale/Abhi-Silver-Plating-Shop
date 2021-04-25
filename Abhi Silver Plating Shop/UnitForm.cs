using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Abhi_Silver_Plating_Shop
{
    public partial class UnitForm : Form
    {
        private Service.UnitService unitService = null;
        private Model.Unit updateUnit = null;
        public UnitForm()
        {
            InitializeComponent();
            unitService = new Service.UnitService();
        }
        void PopulateUnitGrid()
        {
            DataTable dataTable = new Repository.BaseDao().PopulateDataSourceData(Repository.Queries.UNIT_SELECT_QUERY);
            unitGridView.DataSource = dataTable;
            unitGridView.Columns["unitId"].Visible = false;
        }

        void ClearForm()
        {

            txtUnitName.Clear();
            txtRate.Clear();
            updateUnit = null;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClearForm();
        }

        private void UnitForm_Load(object sender, EventArgs e)
        {
            PopulateUnitGrid();
            ClearForm();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUnitName.Text) && string.IsNullOrWhiteSpace(txtRate.Text))
            {
                MessageBox.Show("Please Enter Details");
                txtUnitName.Focus();
                ClearForm();
            }
            else if (updateUnit != null && !string.IsNullOrEmpty(updateUnit.Id))
            {
                MessageBox.Show("Please Enter New Rate Details");
                updateUnit = null;
                ClearForm();
            }
            else if (!Utils.Utility.IsNumeric(txtRate.Text))
            {
                MessageBox.Show("Enter valid rate");
                ClearForm();
            }
            else
            {
                Model.Unit unit = new Model.Unit(null, txtUnitName.Text, Double.Parse(txtRate.Text));
                bool isAdded = unitService.AddUnit(unit);
                if (isAdded)
                {
                    MessageBox.Show("Rate Added !!");
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Rate adding failed..");
                }
                PopulateUnitGrid();

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (updateUnit != null && !string.IsNullOrWhiteSpace(updateUnit.Id))
            {
                if (Utils.Utility.IsNumeric(txtRate.Text) && !String.IsNullOrWhiteSpace(txtUnitName.Text))
                {
                    updateUnit.Name = txtUnitName.Text;
                    updateUnit.Rate = Double.Parse(txtRate.Text);
                    unitService.UpdateUnit(updateUnit);
                    MessageBox.Show("Unit Updated Success.");
                    PopulateUnitGrid();
                    updateUnit = null;
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Enter valid details !");
                }
            }
            else
            {
                MessageBox.Show("Please select Unit from list in order to edit.");
            }
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            if (!Utils.Utility.IsNumeric(txtRate.Text))
            {
                unitRateErrProvider.SetError(txtRate, "Please enter rate in numneric format");
            }
            else
            {
                unitRateErrProvider.Clear();
            }

            if (String.IsNullOrWhiteSpace(txtUnitName.Text))
            {
                unitNameErrProvider.SetError(txtUnitName, "Please enter unit name");
            }
            else
            {
                unitNameErrProvider.Clear();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (updateUnit != null && !String.IsNullOrWhiteSpace(updateUnit.Id))
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure , You want to delete the rate?", "Delete Rate!!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (unitService.DeleteUnit(updateUnit))
                    {
                        MessageBox.Show("Rate delete success.");
                    }
                    PopulateUnitGrid();
                    ClearForm();
                }
                else
                {
                    ClearForm();
                }
            }
            else
            {
                MessageBox.Show("Please select rate from list in order to delete.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void unitGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = true;
            updateUnit = new Model.Unit
            {
                Id = Utils.Utility.CellValueByIndex(0, unitGridView)
            };
            txtUnitName.Text = Utils.Utility.CellValueByIndex(1, unitGridView);
            txtRate.Text = Utils.Utility.CellValueByIndex(2, unitGridView);

        }
    }
}
