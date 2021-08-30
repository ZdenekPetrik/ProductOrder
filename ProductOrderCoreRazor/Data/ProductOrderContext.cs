using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductOrderCoreRazor.Models;

namespace ProductOrderCoreRazor.Data
{
  public class ProductOrderContext : DbContext
  {
    public ProductOrderContext(DbContextOptions<ProductOrderContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Customer>(entity =>
      {
        entity.ToTable("Customers");
      });
      builder.Entity<Product>(entity =>
      {
        entity.ToTable("Products");
      });
      builder.Entity<Order>(entity =>
      {
        entity.ToTable("Orders");
      });
      builder.Entity<OrderItem>(entity =>
      {
        entity.ToTable("OrderItems");
      });
    }

    public DbSet<ProductOrderCoreRazor.Models.Customer> Customer { get; set; }

    public DbSet<ProductOrderCoreRazor.Models.Product> Product { get; set; }

    public DbSet<ProductOrderCoreRazor.Models.Order> Order { get; set; }
  }
}
