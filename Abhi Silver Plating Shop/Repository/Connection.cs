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
    class Connection
    {
        MySql.Data.MySqlClient.MySqlConnection connection;

        static readonly string host = "localhost";
        static readonly string db = "plating_shop";
        static readonly string username = "root";
        static readonly string password = "root";
        public static string strProvider = "server=" + host + ";Database=" + db + ";User ID=" + username + ";Password=" + password;

        public Connection()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        public bool Open()
        {
            try
            {
                strProvider = "server=" + host + ";Database=" + db + ";User ID=" + username + ";Password=" + password + ";CharSet=utf8;";
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
        public void Close()
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

            //Open connection
            if (this.Open() == true)
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
                    user.Username = dataReader["username"] + "";
                    user.Password = dataReader["password"] + "";
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.Close();

                //return list to be displayed
                return user;
            }

            return user;

        }

        public BindingSource populateDataSourceData(string query)
        {
            if (this.Open() == true)
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand(query, connection);
                adapter.SelectCommand = command;
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                this.Close();
                return bindingSource;
            }
            return null;
        }


    }
}
