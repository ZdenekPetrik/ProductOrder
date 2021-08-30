using DBProductOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductOrder
{
  public partial class Product : System.Web.UI.Page
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
        var rows = (from prod in ctx.Products select new { prod.ProductID, prod.ProductName, prod.Price }).OrderBy(n=>n.ProductName).ToList();
        gvProduct.DataSource = rows;
        gvProduct.DataBind();
      }
    }



    protected void gvProduct_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      if (e.CommandName == "InsertNew")
      {
        GridViewRow row = gvProduct.FooterRow;

        TextBox txtName1 = row.FindControl("txtProductNameNew") as TextBox;
        TextBox txtPrice1 = row.FindControl("txtPriceNew") as TextBox;

        float price;
        float.TryParse(txtPrice1.Text, out price);

        using (var ctx = new DBContext())
        {
          var obj = new DBProductOrder.Product();
          obj.ProductName = txtName1.Text;
          obj.Price = price;
          ctx.Products.Add(obj);
          ctx.SaveChanges();
          BindGrid();
        }

      }

    }

    protected void gvProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
      int productID = Convert.ToInt32(gvProduct.DataKeys[e.RowIndex].Value);
      using (var ctx = new DBContext())
      {
        var obj = ctx.Products.First(x => x.ProductID == productID);
        ctx.Products.Remove(obj);
        ctx.SaveChanges();
        BindGrid();
      }
    }

    protected void gvProduct_RowEditing(object sender, GridViewEditEventArgs e)
    {
      gvProduct.EditIndex = e.NewEditIndex;
      BindGrid();
    }

    protected void gvProduct_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
      GridViewRow row = gvProduct.Rows[e.RowIndex];

      TextBox txtName1 = row.FindControl("txtProductName") as TextBox;
      TextBox txtPrice1 = row.FindControl("txtPrice") as TextBox;

      float price;
      float.TryParse(txtPrice1.Text, out price);

      using (var ctx = new DBContext())
      {
        int ProductID = Convert.ToInt32(gvProduct.DataKeys[e.RowIndex].Value);
        var obj = ctx.Products.First(x => x.ProductID == ProductID);
        obj.ProductName = txtName1.Text;
        obj.Price = price;
        ctx.SaveChanges();
        gvProduct.EditIndex = -1;
        BindGrid();
      }

    }

    protected void gvProduct_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
      gvProduct.EditIndex = -1;
      BindGrid();

    }
  }
}