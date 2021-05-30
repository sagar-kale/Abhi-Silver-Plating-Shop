using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Abhi_Silver_Plating_Shop.Repository;

namespace Abhi_Silver_Plating_Shop.Service
{
    class PaymentService
    {
        private readonly IDataAccess dataAccess = DataAccess.Instance;
        public bool MakePayment(dynamic payment)
        {
            try
            {
                dataAccess.SaveData(Queries.PAYMENT_INSERT_QUERY, payment);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public bool UpdateAmtInventory(Model.CustomerAccount account)
        {
            try
            {
                dataAccess.SaveData(Queries.AMT_INVENTORY_UPDATE_BY_CUSTOMER, account);
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