using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductOrderCoreRazor.Models
{
  public class OrderItem
  {
    public int OrderItemID { get; set; }
    public int ProductID { get; set; }
    public int Count { get; set; }
    public int OrderID { get; set; }
  }
}
