using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Data;

namespace Abhi_Silver_Plating_Shop.Repository
{
    /// <summary>
    /// This class uses dapper, its parameter setup is same as JPA class fields in java
    /// use @ in query to parameter replace
    /// </summary>
    public class DataAccess : IDataAccess
    {
        public static readonly IDataAccess Instance = new DataAccess();
        readonly string connectionString;

        private DataAccess()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            this.connectionString = Utils.Utility.connectionString;
        }

        public List<T> LoadData<T, U>(string sql, U parameters)
        {
            using IDbConnection connection = new MySqlConnection(connectionString);
            List<T> rows = connection.Query<T>(sql, parameters).ToList();
            return rows;
        }

        public T LoadSingleData<T, U>(string sql, U parameters)
        {
            using IDbConnection connection = new MySqlConnection(connectionString);
            T res = connection.QuerySingle<T>(sql, parameters);
            return res;
        }

        public void SaveData<T>(string sql, T parameters)
        {
            using IDbConnection connection = new MySqlConnection(connectionString);
            connection.Execute(sql, parameters);
        }

        public DataTable PopulateGrid<T>(string sql, T parameters)
        {
            using IDbConnection connection = new MySqlConnection(connectionString);
            IDataReader dataReader = connection.ExecuteReader(sql, parameters);
            DataTable d = new();
            d.Load(dataReader);
            return d;
        }
    }
}
