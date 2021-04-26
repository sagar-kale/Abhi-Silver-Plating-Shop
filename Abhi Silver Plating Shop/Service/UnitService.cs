using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Abhi_Silver_Plating_Shop.Model;

namespace Abhi_Silver_Plating_Shop.Service
{
    class UnitService
    {
        Repository.BaseDao baseDao = new Repository.BaseDao();

        public bool AddUnit(Unit unit)
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
        public bool UpdateUnit(Unit unit)
        {
            try
            {
                if (baseDao.OpenConnection() == true)
                {
                    MySqlCommand insertCommand = new MySqlCommand(Repository.Queries.UNIT_UPDATE_QUERY, baseDao.Connection);
                    insertCommand.Parameters.AddWithValue("@unitId", unit.Id);
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

        public bool DeleteUnit(Unit unit)
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
        public Unit FetchRate(Unit unit)
        {
            Unit reUnit = new Unit();
            reUnit.Name = unit.Name;
            try
            {
                if (baseDao.OpenConnection() == true)
                {
                    MySqlCommand selectCommand = new MySqlCommand(Repository.Queries.UNIT_SELECT_BY_UNITNAME_QUERY, baseDao.Connection);
                    selectCommand.Parameters.AddWithValue("@unitName", unit.Name.ToUpper());
                    selectCommand.Prepare();
                    MySqlDataReader mySqlDataReader = selectCommand.ExecuteReader();
                    while (mySqlDataReader.Read())
                    {
                        reUnit.Id = mySqlDataReader.GetString("unitId");
                        reUnit.Rate = mySqlDataReader.GetDouble("rate");
                    }
                    baseDao.CloseConnection();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return reUnit;
        }
    }

}
