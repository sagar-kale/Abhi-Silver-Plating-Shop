using Abhi_Silver_Plating_Shop.Utils;
using Abhi_Silver_Plating_Shop.Validator;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reactive.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Abhi_Silver_Plating_Shop
{
    public partial class UserForm : Form
    {
        private Service.UserService userService = null;
        readonly UserValidator validator;
        public UserForm()
        {
            InitializeComponent();
            userService = new Service.UserService();
            validator = new UserValidator();
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
            label1.Text = Utility.appName;
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

        bool CheckIfUserExits(Model.User user)
        {
            bool isAvailable = new Repository.BaseDao().IsRecordExits("user_auth", "username", txtUsername.Text.Trim());

            if (isAvailable)
            {
                MessageBox.Show("Username already exists! , Please use another username");
                txtUsername.Focus();
                txtUsername.Text = "";
            }

            return isAvailable;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Model.User user = new(
                   txtUsername.Text,
                   cmbRole.Text,
                   txtName.Text,
                   txtPassword.Text.Encrypt()
                   );



            if (!validator.Validate(user).ShowWarningIfNotValid())
            {

                if (CheckIfUserExits(user)) return;

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
            txtUsername.Text = Utility.CellValueByIndex(0, userGridView);
            txtName.Text = Utility.CellValueByIndex(2, userGridView);
            txtPassword.Text = Utility.CellValueByIndex(1, userGridView);
            cmbRole.Text = Utility.CellValueByIndex(3, userGridView);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtUsername.Text))
            {

                Model.User user = new(
                    txtUsername.Text,
                    cmbRole.Text,
                    txtName.Text,
                    txtPassword.Text.Encrypt()
                    );

                if (validator.Validate(user).ShowWarningIfNotValid())
                    return;

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
                Model.User user = new()
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

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToLower(e.KeyChar);
        }
    }
}
