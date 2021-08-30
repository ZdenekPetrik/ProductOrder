using DBProductOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductOrder
{

  public class myOneOrderProduct : DBProductOrder.Product {
    public int Count;
    public bool isVisible;

    public myOneOrderProduct() { Count = 0; isVisible = false; }
  }



  public partial class Orders : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        BindGrid();
      }

    }


    void BindGrid()
    {
      using (var ctx = new DBContext())
      {

        var orders = ctx.Orders.Include("Customer").Include("OrderItems").OrderBy(n => n.InsertDate).ToList();
        gvOrder.DataSource =  orders;
        gvOrder.DataBind();

        gvProduct.DataSource = null;
        gvOrder.DataBind();
      }
    }

    protected void gvOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
      GridViewRow row = gvOrder.SelectedRow;
      int orderID = (int )gvOrder.DataKeys[row.RowIndex].Values[0];
      List<myOneOrderProduct> myproducts = new List<myOneOrderProduct>();
      using (var ctx = new DBContext())
      {
        var orderitems = ctx.OrderItems.Where(x => x.OrderID == orderID);
        var allproduct = ctx.Products.OrderBy(n => n.ProductName).ToList();
        foreach (var orderitem in orderitems) {
          var aktproduct = allproduct.Where(X => X.ProductID == orderitem.ProductID).First();
          myproducts.Add(new myOneOrderProduct() { ProductID = orderitem.ProductID, ProductName = aktproduct.ProductName, Price = aktproduct.Price, Count = orderitem.Count, isActive = aktproduct.isActive });
        }
      }
      gvProduct.DataSource = myproducts;
      gvProduct.DataBind();
    }

    protected void gvOrder_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
      GridViewRow row = gvOrder.Rows[e.NewSelectedIndex];
      var x = row.DataKeysContainer;


     }

    protected int GetCountOfOrderItems(object orderItems1)
    {
      if (orderItems1 == null)
        return 0;
      IEnumerable<OrderItem> orderItems = (IEnumerable<OrderItem>)orderItems1;
      int pocet = orderItems.Count();
      return pocet;
    }

    
  }
}