using EasyShop.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyShop.Pages
{
    public partial class Success : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if user is logged in
            string userId = User.Identity.GetUserId();

            //Display all items in user's cart.
            GetPurchasesInCart(userId);

            List<Cart> carts = (List<Cart>)Session[User.Identity.GetUserId()];

            CartModel model = new CartModel();
            model.MarkOrdersAsPaid(carts);

            Session[User.Identity.GetUserId()] = null;

            //..................................................................................
          
        }
        private void GetPurchasesInCart(string userId)
        {
            CartModel cartModel = new CartModel();
            double subTotal = 0;

            //Get all purchases for current user and display in table
            List<Cart> purchaseList = cartModel.GetOrdersInCart(userId);
            CreateShopTable(purchaseList, out subTotal);

            //Add totals to webpage
            double vat = subTotal * 0.21;
            double totalAmount = subTotal + 15 + vat;

            litTotal.Text = "Rs " + subTotal;
            litVat.Text = "Rs " + vat;
            litTotalAmount.Text = "Rs " + totalAmount;
        }

        private void CreateShopTable(IEnumerable<Cart> carts, out double subTotal)
        {
            subTotal = new double();
            ProductModel model = new ProductModel();

            foreach (Cart cart in carts)
            {
                //Create HTML elements and fill values with database data
                Product product = model.GetProduct(cart.ProductID);

                ImageButton btnImage = new ImageButton
                {
                    ImageUrl = string.Format("~/Images/Products/{0}", product.Image),
                    PostBackUrl = string.Format("~/Pages/Product.aspx?id={0}", product.ID)
                };

                //Create table to hold shopping cart details
                Table table = new Table { CssClass = "CartTable" };
                TableRow row1 = new TableRow();
                TableRow row2 = new TableRow();

                TableCell cell1_1 = new TableCell { RowSpan = 2, Width = 50 };
                TableCell cell1_2 = new TableCell
                {
                    Text = string.Format("<h4>{0}</h4><br />{1}<br/>In Stock",
                    product.Name, "Item No:" + product.ID),
                    HorizontalAlign = HorizontalAlign.Left,
                    Width = 350,
                };
                TableCell cell1_3 = new TableCell { Text = "Unit Price<hr/>" };
                TableCell cell1_4 = new TableCell { Text = "Quantity<hr/>" };
                TableCell cell1_5 = new TableCell { Text = "Item Total<hr/>" };
                TableCell cell1_6 = new TableCell();

                TableCell cell2_1 = new TableCell();
                TableCell cell2_2 = new TableCell { Text = "Rs " + product.Price };
                TableCell cell2_3 = new TableCell { Text = " " + cart.Amount };
                TableCell cell2_4 = new TableCell { Text = "Rs " + (cart.Amount * product.Price, 2) };
                TableCell cell2_5 = new TableCell();



                //Set custom controls
                cell1_1.Controls.Add(btnImage);
         

                //Add rows & cells to table
                row1.Cells.Add(cell1_1);
                row1.Cells.Add(cell1_2);
                row1.Cells.Add(cell1_3);
                row1.Cells.Add(cell1_4);
                row1.Cells.Add(cell1_5);
                row1.Cells.Add(cell1_6);

                row2.Cells.Add(cell2_1);
                row2.Cells.Add(cell2_2);
                row2.Cells.Add(cell2_3);
                row2.Cells.Add(cell2_4);
                row2.Cells.Add(cell2_5);
                table.Rows.Add(row1);
                table.Rows.Add(row2);
                pnlShoppingCart.Controls.Add(table);

                //Add total of current purchased item to subtotal
                subTotal += Convert.ToDouble(cart.Amount * product.Price);
            }

        }
    }
}