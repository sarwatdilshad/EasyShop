using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyShop.Pages.AdminPages
{
    public partial class Management : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void grdProducts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Get selected row
            GridViewRow row = grdProducts.Rows[e.NewEditIndex];

            //Get Id of selected product
            int rowId = Convert.ToInt32(row.Cells[1].Text);

            row.Cells[3].Visible = false;

            //Redirect user to ManageProducts along with the selected rowId
            Response.Redirect("~/Pages/AdminPages/ManageProducts.aspx?id=" + rowId);       
        }
    }
}