using System;
using System.Collections.Generic;
using System.Text;

namespace Abhi_Silver_Plating_Shop.Model
{
    class Customer
    {
        private string id;
        private string name;
        private string email;
        private string address;
        private string mobile;

        public Customer()
        {
        }

        public Customer(string id, string name, string email, string address, string mobile)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.address = address;
            this.mobile = mobile;
        }

        public string Name { get => name; set => name = value; }
        public string Id { get => id; set => id = value; }
        public string Email { get => email; set => email = value; }
        public string Address { get => address; set => address = value; }
        public string Mobile { get => mobile; set => mobile = value; }
    }
}
