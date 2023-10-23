using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.YourOutputDirectory;

public partial class ProductViewModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Supplierid { get; set; }

    public int? Categoryid { get; set; }

    public string? QuantityPerUnit { get; set; }

    public float UnitPrice { get; set; }

    public int? UnitsInStock { get; set; }
}
