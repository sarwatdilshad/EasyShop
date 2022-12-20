using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Policy;
using EasyShop.Models;

namespace EasyShop.Pages.Account
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            var userStore = new UserStore<IdentityUser>();

         userStore.Context.Database.Connection.ConnectionString =
                System.Configuration.ConfigurationManager.ConnectionStrings["EasyShopDBConnectionString"].ConnectionString;
            
            var manager = new UserManager<IdentityUser>(userStore);

            //Create new user and try to store in DB.
            var user = new IdentityUser { UserName = txtUserName.Text };

            if (txtPassword.Text == txtConfirmPassword.Text)
            {
                try
                {
                    IdentityResult result = manager.Create(user, txtPassword.Text);
                    if (result.Succeeded)
                    {
                        
                        UserInformation info = new UserInformation
                        {
                            Address = txtAddress.Text,
                            FirstName = txtFirstName.Text,
                            LastName = txtLastName.Text,
                            GUID = user.Id,
                            PostalCode = Convert.ToInt32(txtPostalCode.Text),
                            Phone = txtPhone.Text,
                            Email = txtEmail.Text
                        };

                        UserInfoModel model = new UserInfoModel();
                        model.InsertUserDetail(info);

                        //Store user in DB
                        var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                        var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                        //If succeedeed, log in the new user and set a cookie and redirect to homepage
                        authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                        Response.Redirect("~/Index.aspx");
                    }
                    else
                    {
                        litStatusMessage.Text = result.Errors.FirstOrDefault();
                    }
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            litStatusMessage.Text="Property: {0} throws Error: {1}"+ validationError.PropertyName + validationError.ErrorMessage;
                        }
                    }
                }
                //catch (Exception ex)
                //{
                //    litStatusMessage.Text = ex.ToString();
                //}
            }
            else
            {
                litStatusMessage.Text = "Passwords must match!";
            }
        }
    }
}