using System;
using System.Collections.Generic;

namespace DataLayer.YourOutputDirectory;

public partial class Order
{
    public int Id { get; set; }

    public string? Customerid { get; set; }

    public int? Employeeid { get; set; }

    private DateTime? _date;
    private DateTime? _required;

    public DateTime? Date
    {
        get
        {
            if (_date == null)
            {
                return new DateTime();
            }
            Console.WriteLine("TUU SOOOOM!");
            return _date;
        }
        set
        {
            _date = value;
        }
    }

    public DateTime? Required
    {
        get
        {
            if (_required == null)
            {
                return new DateTime();
            }
            return _date;
        }
        set
        {
            _required = value;
        }
    }


    public DateTime? Shippeddate { get; set; }

    public int? Freight { get; set; }

    public string? ShipName { get; set; }

    public string? Shipaddress { get; set; }

    public string? ShipCity { get; set; }

    public string? Shippostalcode { get; set; }

    public string? Shipcountry { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<OrderDetails> OrderDetails
    {
        get
        {
            if (_orderDetails != null && _orderDetails.Count > 0)
            {
                return _orderDetails;
            }
            return null;
        }
        set
        {
            _orderDetails = value;
        }
    }

    private ICollection<OrderDetails> _orderDetails;
}
