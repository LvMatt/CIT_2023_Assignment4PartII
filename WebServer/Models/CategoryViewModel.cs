using System;
using System.Collections.Generic;

namespace WebServer.Models;

public partial class CategoryViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

}
