using System;

namespace Abhi_Silver_Plating_Shop.Model
{
    public class Order
    {

        private string orderId;
        private string itemId;
        private string customerId;
        private double inWeight;
        private double outWeight;
        private double fine;
        private double totalAmount;
        private double labourRate;
        private DateTime createdDate;
        private DateTime lasModifiedDate;
        private DateTime date;
        private string status;
        private Stat stat;
        private string itemName;

        public Order()
        {
        }

        public Order(string orderId, string itemId, string customerId, double inWeight, double outWeight, double fine, double totalAmount, double labourRate, DateTime createdDate, DateTime lasModifiedDate, DateTime date, string status)
        {
            this.orderId = orderId;
            this.itemId = itemId;
            this.customerId = customerId;
            this.inWeight = inWeight;
            this.outWeight = outWeight;
            this.fine = fine;
            this.TotalAmount = totalAmount;
            this.labourRate = labourRate;
            this.createdDate = createdDate;
            this.lasModifiedDate = lasModifiedDate;
            this.date = date;
            this.status = status;
        }

        public string OrderId { get => orderId; set => orderId = value; }
        public string ItemId { get => itemId; set => itemId = value; }
        public string CustomerId { get => customerId; set => customerId = value; }
        public double InWeight { get => inWeight; set => inWeight = value; }
        public double OutWeight { get => outWeight; set => outWeight = value; }
        public double Fine { get => fine; set => fine = value; }
        public double LabourRate { get => labourRate; set => labourRate = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
        public DateTime LasModifiedDate { get => lasModifiedDate; set => lasModifiedDate = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Status { get => status; set => status = value; }
        public double TotalAmount { get => totalAmount; set => totalAmount = value; }
        public Stat Stat { get => stat; set => stat = value; }
        public string ItemName { get => itemName; set => itemName = value; }
    }
}