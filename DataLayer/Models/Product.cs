using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.YourOutputDirectory;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Supplierid { get; set; }

    public int? Categoryid { get; set; }

    public string? QuantityPerUnit { get; set; }

    public float UnitPrice { get; set; } = 0.0F;

    public int? UnitsInStock { get; set; } = 0;

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderDetails> Orderdetails { get; set; } = new List<OrderDetails>();

    public virtual Supplier? Supplier { get; set; }

    [NotMapped]
    public string CategoryName { get; set; }
    

}
