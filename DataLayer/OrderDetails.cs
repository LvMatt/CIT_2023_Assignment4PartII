using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class OrderDetails
    {
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }

        [Key]
        public int ProductId { get; set; }


        [Key]
        public int OrderId { get; set; }

        public Product Product { get; set; } // Navigation property for Product
        public Order Order { get; set; }     // Navigation property for Order

    }

}

