using DBProductOrder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductOrder
{

  internal class myOneProduct : DBProductOrder.Product
  {
    public int CountItems { get; set; }
    public float PriceFull { get; set; }
    public int OrderID { get; set; }

    public myOneProduct() { CountItems = 0; PriceFull = 0F; OrderID = 0; }
  }

  public partial class OrdersManipulation : System.Web.UI.Page
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
        gvOrder.DataSource = orders;
        gvOrder.DataBind();

        gvProduct.DataSource = null;
        gvProduct.DataBind();
      }
      btnCancelEdit.Visible = false;
      btnSaveEdit.Visible = false;
    }

    protected void gvOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
      GridViewRow selectedRow = gvOrder.SelectedRow;
      int orderID = (int)gvOrder.DataKeys[selectedRow.RowIndex].Values[0];
      List<myOneProduct> myproducts = new List<myOneProduct>();
      using (var ctx = new DBContext())
      {
        var orderitems = ctx.OrderItems.Where(x => x.OrderID == orderID);
        var allproduct = ctx.Products.OrderBy(n => n.ProductName).ToList();
        foreach (var productitem in allproduct)
        {
          myOneProduct myproduct = new myOneProduct() { ProductID = productitem.ProductID, ProductName = productitem.ProductName, Price = productitem.Price, isActive = productitem.isActive, OrderID = orderID };
          var aktorderitem = orderitems.Where(X => X.ProductID == productitem.ProductID);
          if (aktorderitem.Count() == 0)
          {
          }
          else
          {
            myproduct.CountItems = aktorderitem.First().Count;
            myproduct.PriceFull = (float)Math.Round((float)(aktorderitem.First().Count * myproduct.Price), 2);
          }
          myproducts.Add(myproduct);
        }
      }
      gvProduct.DataSource = myproducts;
      gvProduct.DataBind();

      foreach (GridViewRow row in gvOrder.Rows)
      {
        if (row.RowIndex == gvOrder.SelectedIndex)
        {
          row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
        }
        else
        {
          row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
        }
      }
      btnCancelEdit.Visible = true;
      btnSaveEdit.Visible = true;

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

    protected void gvCustomer_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    }

    protected void gvCustomer_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      if (e.CommandName == "InsertNew")
      {
        GridViewRow row = gvOrder.FooterRow;
        DropDownList ddlClientName2 = row.FindControl("ddlClientName") as DropDownList;
        int customerID = 0;
        int.TryParse(ddlClientName2.SelectedValue, out customerID);
        if (customerID == 0) {
          string script = @"<script>alert('""Nelze přidat - vyberte ze seznamu ""');</script>";
          ClientScript.RegisterClientScriptBlock(GetType(), "alert", script);
          return;
        }

        using (var ctx = new DBContext())
        {
          var obj = new DBProductOrder.Order()
          {
            CustomerID = customerID,
            InsertDate = DateTime.Now,
            PriceFull = 0F,
          };
          ctx.Orders.Add(obj);
          ctx.SaveChanges();
          BindGrid();
        }
      }

    }

    protected void gvCustomer_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
      int OrderID = Convert.ToInt32(gvOrder.DataKeys[e.RowIndex].Value);
      using (var ctx = new DBContext())
      {
        var obj = ctx.Orders.First(x => x.OrderID == OrderID);
        ctx.Orders.Remove(obj);
        ctx.SaveChanges();
        BindGrid();
      }


    }

    protected void gvCustomer_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void gvCustomer_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    protected void gvOrder_DataBound(object sender, EventArgs e)
    {
      using (var ctx = new DBContext())
      {
        DropDownList ddlClientName2 = gvOrder.FooterRow.FindControl("ddlClientName") as DropDownList;
        ddlClientName2.DataSource = ctx.Customers.OrderBy(x => x.ClientName).ToList();
        ddlClientName2.DataTextField = "ClientName";
        ddlClientName2.DataValueField = "CustomerID";
        ddlClientName2.DataBind();
        ddlClientName2.Items.Insert(0, new ListItem("-Add Customer-", "0"));
      }

    }


    protected void gvProduct_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        Label lblcount = (Label)e.Row.FindControl("lblCount");
        TextBox txtnewcount = (TextBox)e.Row.FindControl("newCount2");
        if (lblcount.Text == "0")
          txtnewcount.Text = "";
        else
          txtnewcount.Text = lblcount.Text.ToString();

      }

    }

    protected void btnSaveEdit_Click(object sender, EventArgs e)
    {

      using (var ctx = new DBContext())
      {
        bool isanychange = false;
        int orderID = 0;
        foreach (GridViewRow row in gvProduct.Rows)
        {
          if (row.RowType == DataControlRowType.DataRow)
          {
            TextBox myTextBox = row.FindControl("newCount2") as TextBox;
            Label lblCount = row.FindControl("lblCount") as Label;
            String newvalue = myTextBox.Text.Trim();
            String oldvalue = lblCount.Text.Trim();
            if ((newvalue.Length == 0 && oldvalue == "0") || newvalue == oldvalue)
            {
              // netreba nic delat
            }
            else
            {
              Label lblProductID = row.FindControl("lblProductID") as Label;
              int productID = 0;
              int.TryParse(lblProductID.Text, out productID);
              Label lblOrderID = row.FindControl("lblOrderID") as Label;
              int.TryParse(lblOrderID.Text, out orderID);
              if (newvalue == "0")
              {
                var todeleterow = ctx.OrderItems.Where(x => x.ProductID == productID).First();
                ctx.OrderItems.Remove(todeleterow);
                isanychange = true;
              }
              else
              {
                int newCount = 0;
                int.TryParse(myTextBox.Text, out newCount);
                if (newCount > 0)
                {
                  if (oldvalue == "0")       // tzn musime produkt do objednavky pridat 
                  {
                    OrderItem toinsertrow = new OrderItem() { ProductID = productID, Count = newCount, OrderID = orderID };
                    ctx.OrderItems.Add(toinsertrow);
                    isanychange = true;
                  }
                  else
                  {
                    var toupdaterow = ctx.OrderItems.Where(x => x.ProductID == productID).First();
                    toupdaterow.Count = newCount;
                    isanychange = true;
                  }
                }
              }
            }
          }
        }
        if (isanychange)
        {
          ctx.SaveChanges();
          var query = from oi in ctx.OrderItems
                      join prod in ctx.Products on oi.ProductID equals prod.ProductID
                      where oi.OrderID == orderID
                      select new { oi.Count, prod.Price };
          var sum = query.ToList().Select(x => x.Price * x.Count).Sum();
          ctx.Orders.Where(x => x.OrderID == orderID).First().PriceFull = (float)Math.Round(sum, 2);
          ctx.SaveChanges();
        }
      }
      BindGrid();
    }
    protected void btnCancelEdit_Click(object sender, EventArgs e)
    {

      BindGrid();
    }
  }
}