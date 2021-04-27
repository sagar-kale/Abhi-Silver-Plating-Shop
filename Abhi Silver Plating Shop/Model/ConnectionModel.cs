using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abhi_Silver_Plating_Shop.Model
{
    public class ConnectionModel
    {
        private string server;
        private string database;
        private string username;
        private string password;
        private string shopName;

        public ConnectionModel()
        {
        }

        public ConnectionModel(string server, string database, string username, string password, string shopName)
        {
            this.server = server;
            this.database = database;
            this.username = username;
            this.password = password;
            this.ShopName = shopName;
        }

        public string Server { get => server; set => server = value; }
        public string Database { get => database; set => database = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string ShopName { get => shopName; set => shopName = value; }
    }
}
