using System;
using System.Collections.Generic;
using System.Text;

namespace Abhi_Silver_Plating_Shop.Repository
{
    class Queries
    {
        public const string CUSTOMER_SELECT_QUERY = "Select customerId,name as Name,address as Address, email as Email, mobile as Mobile from customers";
        public const string CUSTOMER_INSERT_QUERY = "INSERT INTO customers VALUES (@customerId, @name, @email, @mobile, @address)";
    }
}
