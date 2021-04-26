using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Abhi_Silver_Plating_Shop.Service
{
    class UserService
    {
        Repository.BaseDao baseDao = new Repository.BaseDao();

        public bool AddUser(Model.User user)
        {
            try
            {
                if (baseDao.OpenConnection() == true)
                {
                    MySqlCommand insertCommand = new MySqlCommand(Repository.Queries.USER_INSERT_QUERY, baseDao.Connection);
                    insertCommand.Parameters.AddWithValue("@username", user.Username);
                    insertCommand.Parameters.AddWithValue("@name", user.Name);
                    insertCommand.Parameters.AddWithValue("@password", user.Password);
                    insertCommand.Parameters.AddWithValue("@role", user.Role);
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
        public bool UpdateUser(Model.User user)
        {
            try
            {
                if (baseDao.OpenConnection() == true)
                {
                    MySqlCommand insertCommand = new MySqlCommand(Repository.Queries.USER_UPDATE_QUERY, baseDao.Connection);
                    insertCommand.Parameters.AddWithValue("@username", user.Username);
                    insertCommand.Parameters.AddWithValue("@name", user.Name);
                    insertCommand.Parameters.AddWithValue("@password", user.Password);
                    insertCommand.Parameters.AddWithValue("@role", user.Role);
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

        public bool DeleteUser(Model.User user)
        {
            try
            {
                if (baseDao.OpenConnection() == true)
                {
                    MySqlCommand insertCommand = new MySqlCommand(Repository.Queries.USER_DELETE_QUERY, baseDao.Connection);
                    insertCommand.Parameters.AddWithValue("@username", user.Username);
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