using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Expensive_co.Development
{
    public partial class AddProduct : System.Web.UI.Page
    {
        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ExpensiveDBConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddProductBtn_Click(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            string file_name = productimage.FileName.ToString();
            if (file_name != null )
            {
                SqlCommand addProductCommand = new SqlCommand("INSERT INTO Products (productName, productDescription, productPrice, productBrand, productCategory, productStatus, productImage, productDate) VALUES(@productName, @productDescription, @productPrice, @productBrand, @productCategory,@productStatus, '" + file_name + "',@productDate)", connect);

                productimage.PostedFile.SaveAs(Server.MapPath("../Assets/productImg/") + file_name);

                addProductCommand.Parameters.AddWithValue("@productName", productname.Text);
                addProductCommand.Parameters.AddWithValue("@productDescription", productdescription.Text);
                addProductCommand.Parameters.AddWithValue("@productPrice", productprice.Text);
                addProductCommand.Parameters.AddWithValue("@productBrand", productbrand.Text);
                addProductCommand.Parameters.AddWithValue("@productCategory", productcategories.Text);
                addProductCommand.Parameters.AddWithValue("@productStatus", "1");
                addProductCommand.Parameters.AddWithValue("@productDate", currentTime.ToString("yyyy-MM-dd hh:mm tt"));

                connect.Open();
                int result = addProductCommand.ExecuteNonQuery();
                connect.Close();

                Response.Write("<script>alert('Added Successfully');</script>");
                Response.Redirect("ProductList.aspx");
            }
            else
            {
                InvalidPanel.Visible = true;
                InvalidError.Text = "Fill in all the requirement";
                Response.Write("<script>alert('Fill in all the requirement');</script>");
            }
            
        }
    }
}