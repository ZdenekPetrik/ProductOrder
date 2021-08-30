using System;
using System.Collections.Generic;
using System.Data.Entity;


namespace DBProductOrder
{
  public class DBContext : DbContext
  {
    public DBContext() : base("ProductOrderDatabase")
    {
      this.Configuration.LazyLoadingEnabled = true;
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {

      modelBuilder.Configurations.Add(new ProductConfigurations());
      modelBuilder.Configurations.Add(new CustomerConfigurations());
    }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
  }
}