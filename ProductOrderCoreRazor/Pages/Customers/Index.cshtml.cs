using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProductOrderCoreRazor.Data;
using ProductOrderCoreRazor.Models;

namespace ProductOrderCoreRazor.Pages.Customers
{
  public class IndexModel : PageModel
  {
    private readonly ProductOrderCoreRazor.Data.ProductOrderContext _context;

    public IndexModel(ProductOrderCoreRazor.Data.ProductOrderContext context)
    {
      _context = context;
    }

    public IList<Customer> Customer { get; set; }

    public async Task OnGetAsync()
    {
      try
      {
        Customer = await _context.Customer.ToListAsync();
      }
      catch (Exception ex)
      {
      }
    }
  }
}