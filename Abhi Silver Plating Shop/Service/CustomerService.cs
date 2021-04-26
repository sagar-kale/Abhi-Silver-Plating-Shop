using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Abhi_Silver_Plating_Shop.Service
{
    class CustomerService
    {
        Repository.BaseDao baseDao = new Repository.BaseDao();

        public bool AddCustomer(Model.Customer customer)
        {
            try
            {
                if (baseDao.OpenConnection() == true)
                {
                    MySqlCommand insertCommand = new MySqlCommand(Repository.Queries.CUSTOMER_INSERT_QUERY, baseDao.Connection);
                    insertCommand.Parameters.AddWithValue("@customerId", Utils.Utility.UniqueId());
                    insertCommand.Parameters.AddWithValue("@name", customer.Name);
                    insertCommand.Parameters.AddWithValue("@address", customer.Address);
                    insertCommand.Parameters.AddWithValue("@email", customer.Email);
                    insertCommand.Parameters.AddWithValue("@mobile", customer.Mobile);
                    insertCommand.Prepare();
                    int update = insertCommand.ExecuteNonQuery();
                    baseDao.CloseConnection();
                    if (update == -1)
                    {
                        return false;
                    }

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
        public bool UpdateCustomer(Model.Customer customer)
        {
            try
            {
                if (baseDao.OpenConnection() == true)
                {
                    MySqlCommand insertCommand = new MySqlCommand(Repository.Queries.CUSTOMER_UPDATE_QUERY, baseDao.Connection);
                    insertCommand.Parameters.AddWithValue("@customerId", customer.Id);
                    insertCommand.Parameters.AddWithValue("@name", customer.Name);
                    insertCommand.Parameters.AddWithValue("@address", customer.Address);
                    insertCommand.Parameters.AddWithValue("@email", customer.Email);
                    insertCommand.Parameters.AddWithValue("@mobile", customer.Mobile);
                    insertCommand.Prepare();
                    insertCommand.ExecuteNonQuery();
                    baseDao.CloseConnection();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public bool DeleteCustomer(Model.Customer customer)
        {
            try
            {
                if (baseDao.OpenConnection() == true)
                {
                    MySqlCommand insertCommand = new MySqlCommand(Repository.Queries.CUSTOMER_DELETE_QUERY, baseDao.Connection);
                    insertCommand.Parameters.AddWithValue("@customerId", customer.Id);
                    insertCommand.Prepare();
                    insertCommand.ExecuteNonQuery();
                    baseDao.CloseConnection();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
    }

}