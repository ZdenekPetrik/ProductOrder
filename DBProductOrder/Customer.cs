using System;
using System.Collections.Generic;

namespace DBProductOrder
{
  public class Customer
  {
    public int CustomerID { get; set; }
    public string ClientName { get; set; }
    public string ClientAddress { get; set; }

    public virtual ICollection<Order> Orders { get; set; }
  }
}