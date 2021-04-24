using System;
using System.Collections.Generic;
using System.Text;

namespace Abhi_Silver_Plating_Shop.Model
{
    class User
    {
        private string username;
        private string name;
        private string password;

        public string Username { get => username; set => username = value; }
        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
    }
}
