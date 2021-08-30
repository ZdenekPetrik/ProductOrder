using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProductOrderCoreRazor.Data;
using ProductOrderCoreRazor.Models;

namespace ProductOrderCoreRazor.Pages.Orders
{
  public class IndexModel : PageModel
  {
    private readonly ProductOrderCoreRazor.Data.ProductOrderContext _context;

    public IndexModel(ProductOrderCoreRazor.Data.ProductOrderContext context)
    {
      _context = context;
    }

    public IList<Order> Order { get; set; }

    public async Task OnGetAsync()
    {
      Order = await _context.Order.ToListAsync();                                                           // NAčte pouze Order bez cizích klíču (Lazy cteni)
      Order = await _context.Order.Include(o => o.Customer).ToListAsync();                                  // Načte Order a jednu větu  Customer
      Order = await _context.Order.Include(o => o.Customer).Include(o=>o.OrderItems).ToListAsync();         // Mačte Order, jednu větu Customer a včechny OrderItems (Eager cteni)
      //                
    }
  }
}
