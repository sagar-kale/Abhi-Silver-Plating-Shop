using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abhi_Silver_Plating_Shop.Model
{
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string Phone { get; set; }
    }
    public class Stat
    {
        public double TotalInWeight { get; set; }
        public double TotalOutWeight { get; set; }
        public double TotalFine { get; set; }
        public double TotalAmt { get; set; }
        public double DebitAmt { get; set; }
        public double CreditAmt { get; set; }
        public double PaidAmt { get; set; }
        public double PaidFine { get; set; }
        public double RemainingFine { get; set; }
        public string CustomerName { get; set; }
        public string GrandAmt { get; set; }
        public string CustomerId { get; set; }
        public string LastOrderPlaced { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string OrderStatus { get; set; }

        public Address Address { get; set; }
        public List<Order> Orders { get; set; }
    }
}
