using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductOrderCoreRazor.Models
{
  public class Order
  {
    public int OrderID { get; set; }
    public DateTime InsertDate { get; set; }
    public float PriceFull { get; set; }

    public int CustomerID { get; set; }

    [ForeignKey("CustomerID")]
    public Customer Customer { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; }
  }
}
