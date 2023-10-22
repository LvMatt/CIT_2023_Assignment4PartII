using System;
using System.Collections.Generic;

namespace DataLayer.YourOutputDirectory;

public partial class Employee
{
    public int Employeeid { get; set; }

    public string Lastname { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string? Title { get; set; }

    public DateOnly? Birthdate { get; set; }

    public DateOnly? Hiredate { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Postalcode { get; set; }

    public string? Country { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
