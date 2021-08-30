using DBProductOrder;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EF6CodeFirstDemo
{
  internal class Program
  {
    static Random rnd; 


    private static void Main(string[] args)
    {
      Console.WriteLine("DB Refresh Start.");
      rnd = new Random(System.Environment.TickCount);
      using (var ctx = new DBContext())
      {
        if (!ctx.Database.Exists())
        {
          ctx.Database.Create();
          Console.WriteLine("Empty DB created.");
        }

        foreach (var customer in ctx.Customers)
          ctx.Customers.Remove(customer);
        foreach (var product in ctx.Products)
          ctx.Products.Remove(product);
        foreach (var order in ctx.Orders)
          ctx.Orders.Remove(order);
        foreach (var orderItem in ctx.OrderItems)
          ctx.OrderItems.Remove(orderItem);
        ctx.SaveChanges();
        ctx.Database.ExecuteSqlCommand(@"DBCC CHECKIDENT('Products', RESEED,0);");
        ctx.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Orders', RESEED,0);");
        ctx.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Customers', RESEED,0);");
        ctx.Database.ExecuteSqlCommand("DBCC CHECKIDENT('OrderItems', RESEED,0);");

        ctx.Products.Add(new Product() { Price = 15.3F, ProductName = "Guma malá" });
        ctx.Products.Add(new Product() { Price = 20.8F, ProductName = "Guma velká" });
        ctx.Products.Add(new Product() { Price = 30.3F, ProductName = "Pero bílé" });
        ctx.Products.Add(new Product() { Price = 30.3F, ProductName = "Pero modré" });
        ctx.Products.Add(new Product() { Price = 30.3F, ProductName = "Pero červené" });
        ctx.Products.Add(new Product() { Price = 12.7F, ProductName = "Tužka měkká" });
        ctx.Products.Add(new Product() { Price = 11.4F, ProductName = "Tužka tvrdá" });
        ctx.Products.Add(new Product() { Price = 18.0F, ProductName = "Pravítko 16cm" });
        ctx.Products.Add(new Product() { Price = 25.1F, ProductName = "Pravítko 30cm" });
        ctx.Products.Add(new Product() { Price = 40.9F, ProductName = "Trojúhelník pravý úhel" });
        ctx.Products.Add(new Product() { Price = 40.9F, ProductName = "Trojúhelní 60/30" });
        ctx.Products.Add(new Product() { Price = 55.2F, ProductName = "Penál malý" });
        ctx.Products.Add(new Product() { Price = 71.3F, ProductName = "Pytel" });
        ctx.Products.Add(new Product() { Price = 47.8F, ProductName = "Pastelky malá sada" });
        ctx.Products.Add(new Product() { Price = 90.0F, ProductName = "Pastelky velké včetně růžové" });
        ctx.Products.Add(new Product() { Price = 33.33F, ProductName = "Fixy 8ks-základní barvy" });
        ctx.Products.Add(new Product() { Price = 120.9F, ProductName = "Fixy velké 30 barev" });
        ctx.SaveChanges();

        ctx.Customers.Add(new Customer() { ClientName = "Maleter Václav", ClientAddress = "Na Vlachovce 20, 18000 Praha 8" });
        ctx.Customers.Add(new Customer() { ClientName = "Chromý Jirka", ClientAddress = "Viklefova 1, 13000 Praha 3" });
        ctx.Customers.Add(new Customer() { ClientName = "Adéla Bernášková", ClientAddress = "Jaurisova 5, 14000 Praha 4" });
        ctx.Customers.Add(new Customer() { ClientName = "Marek Minář", ClientAddress = "Slezská 5, 13000 Praha 3" });
        ctx.Customers.Add(new Customer() { ClientName = "Lýdie Vostrá", ClientAddress = "Cholupická 301, 15000 Praha 5" });
        ctx.SaveChanges();

        ctx.Orders.Add(new Order() { CustomerID = 1, InsertDate = DateTime.Now });
        ctx.Orders.Add(new Order() { CustomerID = 1, InsertDate = DateTime.Now });
        ctx.Orders.Add(new Order() { CustomerID = 2, InsertDate = DateTime.Now });
        ctx.Orders.Add(new Order() { CustomerID = 3, InsertDate = DateTime.Now });
        ctx.SaveChanges();

        var all = ctx.Products;
        var lisi = ctx.Products.AsEnumerable().Where((x, i) => i % 2 == 0);
        var sudi = ctx.Products.AsEnumerable().Where((x, i) => i % 2 == 1);
        var oneProduct = new List<Product>(ctx.Products.Take(1));

        int modifikator = 1;
        foreach (var xOrder in ctx.Orders.ToList())
        {
          xOrder.OrderItems = new List<OrderItem>();
          float newPrice = 0.0F;
          switch (modifikator)
          {
            case 1:
              foreach (var OrderProduct in ctx.Products)
              {
                var oneorder = new OrderItem() { OrderID = xOrder.OrderID, ProductID = OrderProduct.ProductID, Count = NahodneCislo() };
                newPrice += oneorder.Count * OrderProduct.Price;
                xOrder.OrderItems.Add(oneorder);
              }
              break;
            case 2:
              foreach (var OrderProduct in lisi) 
              {
                var oneorder = new OrderItem() { OrderID = xOrder.OrderID, ProductID = OrderProduct.ProductID, Count = NahodneCislo() };
                newPrice += oneorder.Count * OrderProduct.Price;
                xOrder.OrderItems.Add(oneorder);
              }
              break;
            case 3:
              foreach (var OrderProduct in sudi)
              {
                var oneorder = new OrderItem() { OrderID = xOrder.OrderID, ProductID = OrderProduct.ProductID, Count = NahodneCislo() };
                newPrice += oneorder.Count * OrderProduct.Price;
                xOrder.OrderItems.Add(oneorder);
              }
              break;
            case 4:
              foreach (var OrderProduct in oneProduct)
              {
                var oneorder = new OrderItem() { OrderID = xOrder.OrderID, ProductID = OrderProduct.ProductID, Count = NahodneCislo() };
                newPrice += oneorder.Count * OrderProduct.Price;
                xOrder.OrderItems.Add(oneorder);
              }
              break;
            default:
              modifikator = 1;
              break;
          }
          xOrder.PriceFull = (float)Math.Round((double)newPrice, 2);
          modifikator++;
        }

        ctx.SaveChanges();

        // https://docs.microsoft.com/cs-cz/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/reading-related-data-with-the-entity-framework-in-an-asp-net-mvc-application

        // https://www.entityframeworktutorial.net/eager-loading-in-entity-framework.aspx  Eager loading
        using (var ctx1 = new  DBContext()){





          var results = ctx1.Customers.Include("Orders").ToList();


          var result2 = ctx1.Orders.Include("Customer").Include("OrderItems").ToList();
          var a = ctx1.Customers.ToList();
          foreach (var cust1 in ctx1.Customers)
          {
            ctx1.Entry(cust1).Collection(o => o.Orders).Load();
            var x = cust1.CustomerID;
            var y = cust1.Orders;
          }
          foreach (var prod1 in ctx1.Products)
          {
          }
          foreach (var ord1 in ctx1.Orders)
          {
          }
          foreach (var orditem1 in ctx1.OrderItems)
          {
          }
        }





      }
      Console.WriteLine("DB Refresh completed.");
      Console.ReadLine();
    }

    private static int NahodneCislo() {
      int cislo = rnd.Next(1, 10);
      if(cislo <= 5)
        return 1;
      return rnd.Next(2, 10);
    }
  }
}