using System;
using System.Collections.Generic;
using System.Text;

namespace Abhi_Silver_Plating_Shop.Model
{
    class User
    {
        private string username;
        private string role;
        private string name;
        private string password;

        public User()
        {
        }

        public User(string username, string role, string name, string password)
        {
            this.username = username;
            this.role = role;
            this.name = name;
            this.password = password;
        }

        public string Username { get => username; set => username = value; }
        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        public string Role { get => role; set => role = value; }
    }
}
