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
            string file_name = productimage.FileName.ToString();
            SqlCommand addProductCommand = new SqlCommand("INSERT INTO Products (productName, productDescription, productPrice, productBrand, productCategory, productStatus, productImage) VALUES(@productName, @productDescription, @productPrice, @productBrand, @productCategory,@productStatus, '"+file_name+"')", connect);

            productimage.PostedFile.SaveAs(Server.MapPath("../Assets/productImg/") + file_name);

            addProductCommand.Parameters.AddWithValue("@productName", this.productname.Text);
            addProductCommand.Parameters.AddWithValue("@productDescription", this.productdescription.Text);
            addProductCommand.Parameters.AddWithValue("@productPrice", this.productprice.Text);
            addProductCommand.Parameters.AddWithValue("@productBrand", this.productbrand.Text);
            addProductCommand.Parameters.AddWithValue("@productCategory", this.productcategories.Text);
            addProductCommand.Parameters.AddWithValue("@productStatus", "1");
            

            connect.Open();
            int result = addProductCommand.ExecuteNonQuery();
            connect.Close();
            Response.Redirect("ProductList.aspx");
        }
    }
}