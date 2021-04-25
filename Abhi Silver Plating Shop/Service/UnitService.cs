using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Abhi_Silver_Plating_Shop.Service
{
    class UnitService
    {
        Repository.BaseDao baseDao = new Repository.BaseDao();

        public bool AddUnit(Model.Unit unit)
        {
            try
            {
                if (baseDao.OpenConnection() == true)
                {
                    MySqlCommand insertCommand = new MySqlCommand(Repository.Queries.UNIT_INSERT_QUERY, baseDao.Connection);
                    insertCommand.Parameters.AddWithValue("@unitId", Utils.Utility.UniqueId());
                    insertCommand.Parameters.AddWithValue("@name", unit.Name);
                    insertCommand.Parameters.AddWithValue("@rate", unit.Rate);
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
        public bool UpdateUnit(Model.Unit unit)
        {
            try
            {
                if (baseDao.OpenConnection() == true)
                {
                    MySqlCommand insertCommand = new MySqlCommand(Repository.Queries.UNIT_UPATE_QUERY, baseDao.Connection);
                    insertCommand.Parameters.AddWithValue("@unitId", unit.Id);
                    insertCommand.Parameters.AddWithValue("@name", unit.Name);
                    insertCommand.Parameters.AddWithValue("@rate", unit.Rate);
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

        public bool DeleteUnit(Model.Unit unit)
        {
            try
            {
                if (baseDao.OpenConnection() == true)
                {
                    MySqlCommand insertCommand = new MySqlCommand(Repository.Queries.UNIT_DELETE_QUERY, baseDao.Connection);
                    insertCommand.Parameters.AddWithValue("@unitId", unit.Id);
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
