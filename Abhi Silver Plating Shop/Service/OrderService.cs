﻿using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Abhi_Silver_Plating_Shop.Model;
using Abhi_Silver_Plating_Shop.Utils;

namespace Abhi_Silver_Plating_Shop.Service
{
    class OrderService
    {
        Repository.BaseDao baseDao = new Repository.BaseDao();

        public bool AddOrder(Order order)
        {
            try
            {
                if (baseDao.OpenConnection() == true)
                {
                    MySqlCommand insertCommand = new MySqlCommand(
                        Repository.Queries.ORDER_INSERT_QUERY,
                        baseDao.Connection);

                    insertCommand.Parameters.AddWithValue("@orderId", Utils.Utility.UniqueId());
                    insertCommand.Parameters.AddWithValue("@itemId", order.ItemId);
                    insertCommand.Parameters.AddWithValue("@customerId", order.CustomerId);
                    insertCommand.Parameters.AddWithValue("@in_weight", order.InWeight);
                    insertCommand.Parameters.AddWithValue("@out_weight", order.OutWeight);
                    insertCommand.Parameters.AddWithValue("@fine", order.Fine);
                    insertCommand.Parameters.AddWithValue("@total_amount", order.TotalAmount);
                    insertCommand.Parameters.AddWithValue("@labour_rate", order.LabourRate);
                    insertCommand.Parameters.AddWithValue("@date", order.Date);
                    insertCommand.Parameters.AddWithValue("@status", order.Status);
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
        public bool UpdateOrder(Order order)
        {
            try
            {
                if (baseDao.OpenConnection() == true)
                {
                    MySqlCommand insertCommand = new MySqlCommand(Repository.Queries.ORDER_UPDATE_QUERY, baseDao.Connection);
                    insertCommand.Parameters.AddWithValue("@orderId", order.OrderId);
                    insertCommand.Parameters.AddWithValue("@itemId", order.ItemId);
                    insertCommand.Parameters.AddWithValue("@customerId", order.CustomerId);
                    insertCommand.Parameters.AddWithValue("@in_weight", order.InWeight);
                    insertCommand.Parameters.AddWithValue("@out_weight", order.OutWeight);
                    insertCommand.Parameters.AddWithValue("@fine", order.Fine);
                    insertCommand.Parameters.AddWithValue("@total_amount", order.TotalAmount);
                    insertCommand.Parameters.AddWithValue("@labour_rate", order.LabourRate);
                    insertCommand.Parameters.AddWithValue("@date", order.Date);
                    insertCommand.Parameters.AddWithValue("@status", order.Status);

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

        public bool DeleteOrder(Order order)
        {
            try
            {
                if (baseDao.OpenConnection() == true)
                {
                    MySqlCommand insertCommand = new MySqlCommand(Repository.Queries.ORDER_DELETE_QUERY, baseDao.Connection);
                    insertCommand.Parameters.AddWithValue("@orderId", order.OrderId);
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

        public double FetchOrderByType(string type)
        {
            double response = 0;
            bool isAmount = AppConstants.TOTAL_AMOUNT == type.ToUpper();
            try
            {
                if (baseDao.OpenConnection() == true)
                {
                    string query = isAmount ? Repository.Queries.ORDER_TOTAL_AMOUNT : Repository.Queries.ORDER_TOTAL_FINE;
                    MySqlCommand selectCommand = new MySqlCommand(query, baseDao.Connection);
                    MySqlDataReader mySqlDataReader = selectCommand.ExecuteReader();
                    while (mySqlDataReader.Read())
                    {

                        response = isAmount ? mySqlDataReader.GetDouble("total_amount") : mySqlDataReader.GetDouble("total_fine");
                    }
                    baseDao.CloseConnection();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return response;
        }
    }

}