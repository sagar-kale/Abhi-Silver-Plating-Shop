﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace Abhi_Silver_Plating_Shop.Repository
{
    public class DataAccess : IDataAccess
    {
        public static readonly IDataAccess Instance = new DataAccess();
        readonly string connectionString = Utils.Utility.connectionString;
        public List<T> LoadData<T, U>(string sql, U parameters)
        {
            using IDbConnection connection = new MySqlConnection(connectionString);
            List<T> rows = connection.Query<T>(sql, parameters).ToList();
            return rows;
        }

        public void SaveData<U>(string sql, U parameters)
        {
            using IDbConnection connection = new MySqlConnection(connectionString);
            connection.Execute(sql, parameters);
        }
    }
}