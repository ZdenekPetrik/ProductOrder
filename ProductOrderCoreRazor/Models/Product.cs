using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductOrderCoreRazor.Models
{
  public class Product
  {
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public float Price { get; set; }
    public bool isActive { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; }
  }

}
