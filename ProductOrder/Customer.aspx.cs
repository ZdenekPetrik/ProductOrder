using DBProductOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductOrder
{
  public partial class Customer : System.Web.UI.Page
  {

    protected void Page_Load(object sender, EventArgs e)
    {
      Title = "Customer";
      if (!IsPostBack)
      {
        BindGrid();
      }
    }

    void BindGrid()
    {
      using (var ctx = new DBContext())
      {
        var customer = ctx.Customers.OrderBy(n => n.ClientName).ToList();
        foreach (var cust1 in customer)
        {
          ctx.Entry(cust1).Collection(o => o.Orders).Load();
         }
        gvCustomer.DataSource = customer;
        gvCustomer.DataBind();
      }
    }



    protected void gvCustomer_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      if (e.CommandName == "InsertNew")
      {
        GridViewRow row = gvCustomer.FooterRow;

        TextBox txtName = row.FindControl("txtClientNameNew") as TextBox;
        TextBox txtAddress = row.FindControl("txtClientAddressNew") as TextBox;
        using (var ctx = new DBContext())
        {
          var obj = new DBProductOrder.Customer()
          {
            ClientName = txtName.Text,
            ClientAddress = txtAddress.Text
          };
          ctx.Customers.Add(obj);
          ctx.SaveChanges();
          BindGrid();
        }
      }

    }

    protected void gvCustomer_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
      int customerID = Convert.ToInt32(gvCustomer.DataKeys[e.RowIndex].Value);
      using (var ctx = new DBContext())
      {
        var obj = ctx.Customers.First(x => x.CustomerID == customerID);
        ctx.Customers.Remove(obj);
        ctx.SaveChanges();
        BindGrid();
      }
    }

    protected void gvCustomer_RowEditing(object sender, GridViewEditEventArgs e)
    {
      gvCustomer.EditIndex = e.NewEditIndex;
      BindGrid();
    }

    protected void gvCustomer_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
      GridViewRow row = gvCustomer.Rows[e.RowIndex];

      TextBox txtClientName1 = row.FindControl("txtClientName") as TextBox;
      TextBox txtClientAddress1 = row.FindControl("txtClientAddress") as TextBox;

      using (var ctx = new DBContext())
      {
        int CustomerID = Convert.ToInt32(gvCustomer.DataKeys[e.RowIndex].Value);
        var obj = ctx.Customers.First(x => x.CustomerID == CustomerID);
        obj.ClientName = txtClientName1.Text;
        obj.ClientAddress = txtClientAddress1.Text;
        ctx.SaveChanges();
        gvCustomer.EditIndex = -1;
        BindGrid();
      }

    }

    protected void gvCustomer_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
      gvCustomer.EditIndex = -1;
      BindGrid();

    }

    protected int GetCountOfOrders(object orders1) {
      if (orders1 == null)
        return 0;
      IEnumerable<Order> Orders = (IEnumerable<Order>)orders1;
      int pocet = Orders.Count();
      return pocet;
    }
  }
}