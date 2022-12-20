using EasyShop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyShop
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hlManager.Visible = false;
            var user = Context.User.Identity;
            if(user.Name.ToLower() != "admin"  )
            {
                hlManager.Visible= false;
            }
            else
            {
                hlManager.Visible= true;
            }
              if (user.IsAuthenticated)
            {
                litStatus.Text = Context.User.Identity.Name;

                lnkLogin.Visible = false;
                lnkRegister.Visible = false;

                lnkLogout.Visible = true;
                litStatus.Visible = true;

                CartModel model = new CartModel();
                string userId = HttpContext.Current.User.Identity.GetUserId();
                litStatus.Text = String.Format("{0} {1} ({2}) ","Welcome ", Context.User.Identity.Name,model.GetAmountOfOrders(userId));
            }
            else
            {
                lnkLogin.Visible = true;
                lnkRegister.Visible = true;

                lnkLogout.Visible = false;
                litStatus.Visible = false;
            }
        }
        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("Pages/Account/SignIn.aspx");
        }
    }
}