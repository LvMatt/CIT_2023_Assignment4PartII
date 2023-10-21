using System;
namespace DataLayer
{
	public class Product
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitPrice { get; set; }
        public int UnitsInStock { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<OrderDetails> OrderDetails { get; set; } // Navigation property for OrderDetails

    }
}

