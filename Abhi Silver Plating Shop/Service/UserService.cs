using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Abhi_Silver_Plating_Shop.Repository;

namespace Abhi_Silver_Plating_Shop.Service
{
    class UserService
    {
        BaseDao baseDao = new BaseDao();
        private readonly IDataAccess dataAccess = DataAccess.Instance;
        public bool AddUser(Model.User user)
        {
            try
            {
                dataAccess.SaveData(Queries.USER_INSERT_QUERY, user);
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
                    MySqlCommand insertCommand = new MySqlCommand(Queries.USER_UPDATE_QUERY, baseDao.Connection);
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
                    MySqlCommand insertCommand = new MySqlCommand(Queries.USER_DELETE_QUERY, baseDao.Connection);
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