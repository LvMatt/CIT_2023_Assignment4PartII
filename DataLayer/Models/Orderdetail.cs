﻿using System;
using System.Collections.Generic;

namespace DataLayer.YourOutputDirectory;

public partial class OrderDetails
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int UnitPrice { get; set; }

    public int Quantity { get; set; }

    public int Discount { get; set; }

    public virtual Order Order { get; set; }

    public virtual Product Product { get; set; }
}
