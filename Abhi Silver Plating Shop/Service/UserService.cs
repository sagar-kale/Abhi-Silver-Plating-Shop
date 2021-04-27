using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Abhi_Silver_Plating_Shop.Repository;

namespace Abhi_Silver_Plating_Shop.Service
{
    class UserService
    {
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
                dataAccess.SaveData(Queries.USER_UPDATE_QUERY, user);
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
                dataAccess.SaveData(Queries.USER_DELETE_QUERY, user);
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