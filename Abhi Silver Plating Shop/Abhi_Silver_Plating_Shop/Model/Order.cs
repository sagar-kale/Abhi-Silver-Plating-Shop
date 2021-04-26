using System;

namespace Abhi_Silver_Plating_Shop.Model
{
    class Order
    {

        private string orderId;
        private string itemId;
        private string customerId;
        private double inWeight;
        private double outWeight;
        private double fine;
        private double labourRate;
        private DateTime createdDate;
        private DateTime lasModifiedDate;
        private DateTime date;
        private string status;

        public Order()
        {
        }

        public Order(string orderId, string itemId, string customerId, double inWeight, double outWeight, double fine, double labourRate, DateTime createdDate, DateTime lasModifiedDate, DateTime date, string status)
        {
            this.OrderId = orderId;
            this.ItemId = itemId;
            this.CustomerId = customerId;
            this.InWeight = inWeight;
            this.OutWeight = outWeight;
            this.Fine = fine;
            this.LabourRate = labourRate;
            this.CreatedDate = createdDate;
            this.LasModifiedDate = lasModifiedDate;
            this.Date = date;
            this.Status = status;
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
    }
}