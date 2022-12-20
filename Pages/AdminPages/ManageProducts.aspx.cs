using EasyShop.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyShop.Pages.AdminPages
{
    public partial class ManageProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetImages();

                if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    FillPage(id);
                }
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ProductModel productModel = new ProductModel();
            Product product = CreateProduct();

            //check if the url contains an id parameter
            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                lblmsg.Text = productModel.UpdateProduct(id, product);
            }
            else
            {
                lblmsg.Text = productModel.InsertProduct(product);
            }
        }
        private void FillPage(int id)
        {
            //Get Selected product from db
            ProductModel productModel = new ProductModel();
            Product product = productModel.GetProduct(id);

            //Fill id's data into the Controls fields          
            txtName.Text = product.Name;
            txtDescription.Text = product.Description;
            txtPrice.Text = product.Price.ToString();

            //set dropdownList values
            ddlImage.SelectedValue = product.Image;
            ddlProductType.SelectedValue = product.TypeID.ToString();
        }

        private void GetImages()
        {
            try
            {  //get all files paths
                string[] images = Directory.GetFiles(Server.MapPath("~/Images/Products/"));

                //Get all file names and add them to an arraylist
                ArrayList imageList = new ArrayList();

                foreach (string image in images)
                {
                    string imageName = image.Substring(image.LastIndexOf(@"\", StringComparison.Ordinal) + 1);
                    imageList.Add(imageName);
                }
                //set the arrayList as the dropdownview'datasource and refresh
                ddlImage.DataSource = imageList;
                ddlImage.AppendDataBoundItems = true;
                ddlImage.DataBind();

            }
            catch (Exception e)
            {
                lblmsg.Text = e.Message;
            }
        }

        private Product CreateProduct()
        {
            Product product = new Product();

            product.Name = txtName.Text;

            product.Price = Convert.ToInt32(txtPrice.Text);
            product.TypeID = Convert.ToInt32(ddlProductType.SelectedValue);
            product.Description = txtDescription.Text;
            product.Image = ddlImage.SelectedValue;

            return product;
        }

    }

}
