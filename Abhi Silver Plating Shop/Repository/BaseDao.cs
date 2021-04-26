using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Data;

namespace Abhi_Silver_Plating_Shop.Repository
{
    class BaseDao
    {
        MySql.Data.MySqlClient.MySqlConnection connection;

        static readonly string host = "localhost";
        static readonly string db = "plating_shop";
        static readonly string username = "root";
        static readonly string password = "root";
        public static string strProvider = "server=" + host + ";database=" + db + ";userid=" + username + ";password=" + password + ";";

        public MySqlConnection Connection { get => connection; }

        public BaseDao()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        public bool OpenConnection()
        {
            try
            {
                strProvider = "server=" + host + ";database=" + db + ";userid=" + username + ";password=" + password + ";";
                connection = new MySqlConnection(strProvider);
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
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
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
                MySqlCommand cmd = new MySqlCommand(sql, connection);

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

        //Select statement
        public Model.User FetchUser(string username, string password)
        {
            string query = "SELECT * FROM user_auth where username=@val1 and password=@val2";

            //Create a user to store the result
            Model.User user = new Model.User();

            try
            {
                //Open connection
                if (this.OpenConnection() == true)
                {
                    Console.WriteLine("conection.....opened");
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@val1", username);
                    cmd.Parameters.AddWithValue("@val2", password);
                    cmd.Prepare();

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        user.Name = dataReader["name"] + "";
                        user.Role = dataReader["role"] + "";
                        user.Username = dataReader["username"] + "";
                        user.Password = dataReader["password"] + "";
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

            return user;

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
                    MySqlCommand cmd = new MySqlCommand(query, connection);
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
            DataTable dataTable = new DataTable();
            try
            {
                if (this.OpenConnection() == true)
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    dataTable.Load(reader);
                    this.CloseConnection();
                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dataTable;
        }


    }
}
