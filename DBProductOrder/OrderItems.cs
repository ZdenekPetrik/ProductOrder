using System;
using System.Collections.Generic;

namespace DBProductOrder
{
  public class OrderItem
  {
    public int OrderItemID { get; set; }
    public int ProductID { get; set; }
    public int Count { get; set; }
    public int OrderID { get; set; }
  }
}