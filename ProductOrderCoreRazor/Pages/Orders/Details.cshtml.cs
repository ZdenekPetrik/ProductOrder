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
  public class DetailsModel : PageModel
  {
    private readonly ProductOrderCoreRazor.Data.ProductOrderContext _context;

    public DetailsModel(ProductOrderCoreRazor.Data.ProductOrderContext context)
    {
      _context = context;
    }

    public Order Order { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      Order = await _context.Order
          .Include(o => o.Customer)
          .Include(o => o.OrderItems)
          .AsNoTracking()
          .FirstOrDefaultAsync(m => m.OrderID == id);

      if (Order == null)
      {
        return NotFound();
      }
      return Page();
    }
  }
}
