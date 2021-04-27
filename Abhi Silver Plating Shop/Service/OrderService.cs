using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Abhi_Silver_Plating_Shop.Model;
using Abhi_Silver_Plating_Shop.Utils;
using Abhi_Silver_Plating_Shop.Repository;

namespace Abhi_Silver_Plating_Shop.Service
{
    class OrderService
    {
        readonly BaseDao baseDao = new();
        private readonly IDataAccess dataAccess = DataAccess.Instance;
        public bool AddOrder(Order order)
        {
            try
            {
                order.OrderId = Utility.UniqueId();
                dataAccess.SaveData(Queries.ORDER_INSERT_QUERY, order);
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
                dataAccess.SaveData(Queries.ORDER_UPDATE_QUERY, order);
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
                dataAccess.SaveData(Queries.ORDER_DELETE_QUERY, order);
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
                    MySqlCommand selectCommand = new(query, baseDao.Connection);
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