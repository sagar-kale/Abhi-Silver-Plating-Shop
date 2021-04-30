using System;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Abhi_Silver_Plating_Shop.Utils;

namespace Abhi_Silver_Plating_Shop.Repository
{
    class BaseDao
    {
        MySqlConnection connection;

        public MySqlConnection Connection { get => connection; }
        readonly IDataAccess dataAccess;
        public BaseDao()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            dataAccess = DataAccess.Instance;

        }
        public static bool TestConnection(string connectionString)
        {
            bool isConnected = false;
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    isConnected = true;
                }
                catch (MySqlException ex)
                {
                    isConnected = false;
                    MessageBox.Show(ex.Message);
                }
            }

            return isConnected;
        }
        public bool OpenConnection()
        {
            try
            {
                connection = new MySqlConnection(Utility.connectionString);
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {

                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
                return false;
            }
        }
        public void CloseConnection()
        {
            connection.Close();
            connection.Dispose();
        }
        public DataSet ExecuteDataSet(string sql)
        {
            try
            {
                DataSet ds = new();
                MySqlDataAdapter da = new(sql, connection);
                da.Fill(ds, "result");
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
        public MySqlDataReader ExecuteReader(string sql)
        {
            try
            {

                MySqlDataReader reader;

                //Create Command
                MySqlCommand cmd = new(sql, connection);

                //Create a data reader and Execute the command
                reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
        public int ExecuteNonQuery(string sql)
        {
            try
            {
                int affected;
                MySqlTransaction mytransaction = connection.BeginTransaction();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;
                affected = cmd.ExecuteNonQuery();
                mytransaction.Commit();
                return affected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return -1;
        }

        // Authenticate user
        public bool Authenticate(Model.User user)
        {
            bool isAuthenticated = false;
            try
            {
                List<Model.User> users = dataAccess.LoadData<Model.User, Model.User>(Queries.USER_SELECT_BY_USERNAME, user);
                Model.User loggedInUser = users.Find(usr => usr.Username == user.Username && usr.Password.Trim().Decrypt() == user.Password.Trim());
                if (loggedInUser != null && !String.IsNullOrWhiteSpace(loggedInUser.Username))
                {
                    isAuthenticated = true;
                    loggedInUser.Password = null;
                    Model.LoginInfo.UserID = loggedInUser.Username;
                    Model.LoginInfo.UserRole = loggedInUser.Role;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return isAuthenticated;

        }

        public bool IsRecordExits(string table, string column, string value)
        {
            bool isExits = false;
            string query = "SELECT * FROM " + table + " where " + column + "=@" + column + ";";

            try
            {
                //Open connection
                if (this.OpenConnection() == true)
                {
                    Console.WriteLine("conection.....opened");
                    MySqlCommand cmd = new(query, connection);
                    cmd.Parameters.AddWithValue("@" + column, value);
                    cmd.Prepare();

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //Read the data and store them in the list
                    if (dataReader.HasRows)
                    {
                        isExits = true;
                    }
                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    this.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return isExits;

        }

        public DataTable PopulateDataSourceData(string query)
        {
            DataTable dataTable = new();
            try
            {
                if (this.OpenConnection() == true)
                {
                    MySqlCommand command = new(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    dataTable.Load(reader);
                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.CloseConnection();
            }
            return dataTable;
        }

        public DataTable PopulateReportData(string query, string customerId,DateTime fromDate,DateTime toDate)
        {
            DataTable dataTable = new();
            try
            {
                if (this.OpenConnection() == true)
                {
                    using MySqlCommand command = new(query, connection);
                    command.Parameters.AddWithValue("@customerId", customerId);
                    command.Parameters.AddWithValue("@fromDate", fromDate);
                    command.Parameters.AddWithValue("@toDate", toDate);
                    command.Prepare();
                    using MySqlDataReader reader = command.ExecuteReader();
                    dataTable.Load(reader);
                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.CloseConnection();
            }
            return dataTable;
        }

    }
}
