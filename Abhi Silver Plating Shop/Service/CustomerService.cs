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
                    if (update == -1)
                    {
                        return false;
                    }

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }
    }
}
