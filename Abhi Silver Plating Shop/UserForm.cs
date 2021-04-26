using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reactive.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Abhi_Silver_Plating_Shop
{
    public partial class UserForm : Form
    {
        private Service.UserService userService = null;
        public UserForm()
        {
            InitializeComponent();
            userService = new Service.UserService();
        }

        void DelayTextBoxTyping()
        {
            IDisposable subscription =
      Observable
          .FromEventPattern(
              h => txtUsername.TextChanged += h,
              h => txtUsername.TextChanged -= h)
          .Select(x => txtUsername.Text)
          .Throttle(TimeSpan.FromMilliseconds(700))
          .Select(x => Observable.Start(() => x.ToLower()))
          .Switch()
          .ObserveOn(this)
          .Subscribe(x =>
          {
              if (Regex.IsMatch(x, @"\s"))
              {
                  MessageBox.Show("Dont use space in username");
                  btnAdd.Enabled = false;
                  return;
              }
              if (!String.IsNullOrWhiteSpace(x))
              {
                  bool isExits = new Repository.BaseDao().IsRecordExits("user_auth", "username", x);
                  if (isExits)
                  {
                      btnAdd.Enabled = false;
                      MessageBox.Show("Username already exists! , Please use another username");
                  }
                  else
                  {
                      btnAdd.Enabled = true;
                  }
              }
          });
        }


        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            // DelayTextBoxTyping();
            PopulateUserGrid();
            ClearForm();
        }

        void PopulateUserGrid()
        {
            DataTable dataTable = new Repository.BaseDao().PopulateDataSourceData(Repository.Queries.USER_SELECT_QUERY);
            userGridView.DataSource = dataTable;
            userGridView.Columns["password"].Visible = false;
        }

        void ClearForm()
        {
            txtUsername.Enabled = true;
            txtUsername.Clear();
            txtName.Clear();
            txtPassword.Clear();
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = true;
        }

        bool CheckIfUserExits()
        {
            bool isExists = false;
            if (!String.IsNullOrWhiteSpace(txtUsername.Text))
            {
                bool isExits = new Repository.BaseDao().IsRecordExits("user_auth", "username", txtUsername.Text.Trim());
                if (isExits)
                {
                    MessageBox.Show("Username already exists! , Please use another username");
                    txtUsername.Focus();
                    txtUsername.Text = "";
                    isExists = true;
                }
                else
                {
                    isExists = false;
                }

            }
            return isExists;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please Enter User Name");
                ClearForm();
                txtUsername.Focus();
                txtUsername.Text = "";
            }
            else
            {
                if (CheckIfUserExits()) return;

                Model.User user = new Model.User(
                    txtUsername.Text,
                    cmbRole.Text,
                    txtName.Text,
                    txtPassword.Text
                    );

                bool isAdded = userService.AddUser(user);
                if (isAdded)
                {
                    MessageBox.Show("User Added !!");
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("User adding failed..");
                }
                PopulateUserGrid();

            }
        }

        private void userGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = true;
            txtUsername.Enabled = false;
            txtUsername.Text = Utils.Utility.CellValueByIndex(0, userGridView);
            txtName.Text = Utils.Utility.CellValueByIndex(2, userGridView);
            txtPassword.Text = Utils.Utility.CellValueByIndex(1, userGridView);
            cmbRole.Text = Utils.Utility.CellValueByIndex(3, userGridView);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtUsername.Text))
            {

                Model.User user = new Model.User(
                    txtUsername.Text,
                    cmbRole.Text,
                    txtName.Text,
                    txtPassword.Text
                    );

                userService.UpdateUser(user);
                MessageBox.Show("User Updated Success.");
                PopulateUserGrid();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Please select user from list in order to edit.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtUsername.Text))
            {
                Model.User user = new Model.User
                {
                    Username = txtUsername.Text
                };

                if (userService.DeleteUser(user))
                {
                    MessageBox.Show("User delete success.");
                }
                PopulateUserGrid();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Please select user from list in order to delete.");
            }
        }
    }
}
