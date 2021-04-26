using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Abhi_Silver_Plating_Shop.Service
{
    class ItemService
    {
        Repository.BaseDao baseDao = new Repository.BaseDao();

        public bool AddItem(Model.Item item)
        {
            try
            {
                if (baseDao.OpenConnection() == true)
                {
                    MySqlCommand insertCommand = new MySqlCommand(Repository.Queries.ITEM_INSERT_QUERY, baseDao.Connection);
                    insertCommand.Parameters.AddWithValue("@itemId", Utils.Utility.UniqueId());
                    insertCommand.Parameters.AddWithValue("@name", item.Name);
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
        public bool UpdateItem(Model.Item item)
        {
            try
            {
                if (baseDao.OpenConnection() == true)
                {
                    MySqlCommand insertCommand = new MySqlCommand(Repository.Queries.ITEM_UPDATE_QUERY, baseDao.Connection);
                    insertCommand.Parameters.AddWithValue("@itemId", item.Id);
                    insertCommand.Parameters.AddWithValue("@name", item.Name);
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

        public bool DeleteItem(Model.Item item)
        {
            try
            {
                if (baseDao.OpenConnection() == true)
                {
                    MySqlCommand insertCommand = new MySqlCommand(Repository.Queries.ITEM_DELETE_QUERY, baseDao.Connection);
                    insertCommand.Parameters.AddWithValue("@itemId", item.Id);
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
