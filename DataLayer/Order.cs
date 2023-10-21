using System;
namespace DataLayer
{
    public class Order
    {
        public int Id { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipPostalcode { get; set; }
        public string ShipCountry { get; set; }
        public int Freight { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public DateTime OrderDate { get; set; }

        public List<OrderDetails> OrderDetails { get; set; } // Navigation property for OrderDetails

    }
}

