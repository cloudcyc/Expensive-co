using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Expensive_co.Development
{
    public partial class EditProduct : System.Web.UI.Page
    {
        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ExpensiveDBConnectionString"].ConnectionString);
        int product_ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            if (Request.QueryString["productID"] == null)
            {
                Response.Redirect("ProductList.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    product_ID = Convert.ToInt32(Request.QueryString["productID"]);
                    SqlCommand SelectedProductCommand = new SqlCommand("SELECT* FROM Products WHERE productID =" + product_ID, connect);
                    SqlDataAdapter SelectedProductAdapter = new SqlDataAdapter(SelectedProductCommand);
                    DataTable SelectedProductDT = new DataTable();
                    SelectedProductAdapter.Fill(SelectedProductDT);
                    connect.Open();
                    SelectedProductCommand.ExecuteNonQuery();
                    connect.Close();

                    foreach (DataRow row in SelectedProductDT.Rows)
                    {

                        this.productname.Text = row["productName"].ToString();
                        this.productprice.Text = row["productPrice"].ToString();
                        this.productbrand.Text = row["productBrand"].ToString();

                        this.currentproductImage.ImageUrl = "~/Assets/productImg/" + row["productImage"];
                        this.currentproductImage.AlternateText = row["productImage"].ToString();
                        this.productcategories.Text = row["productCategory"].ToString();
                        this.productdescription.Text = row["productDescription"].ToString();

                    }
                }
                
                

            }
        }
        protected void EditBtn_Click(object sender, EventArgs e)
        {
            product_ID = Convert.ToInt32(Request.QueryString["productID"]);
            string query = null;
            int urlproductStatus = Convert.ToInt32(Request.QueryString["productStatus"]);
            string file_name = productimage.FileName.ToString();
            
            if (file_name != "")
            {
                File.Delete(Server.MapPath("../Assets/productImg/") + currentproductImage.AlternateText);
                productimage.PostedFile.SaveAs(Server.MapPath("../Assets/productImg/") + file_name);
            }
           
            query = "Update Products SET productName =@productName, productDescription =@productDescription , productPrice =@productPrice , productBrand =@productBrand , productCategory =@productCategory, productStatus =@productStatus , productImage =@productImage  WHERE productID=@productID";
           
            SqlCommand UpdateProductCommand = new SqlCommand(query, connect);
            UpdateProductCommand.Parameters.AddWithValue("@productName",this.productname.Text);
            UpdateProductCommand.Parameters.AddWithValue("@productDescription", this.productdescription.Text);
            UpdateProductCommand.Parameters.AddWithValue("@productPrice", this.productprice.Text);
            UpdateProductCommand.Parameters.AddWithValue("@productBrand", this.productbrand.Text);
            UpdateProductCommand.Parameters.AddWithValue("@productCategory", this.productcategories.Text);
            UpdateProductCommand.Parameters.AddWithValue("@productStatus", urlproductStatus);

            if (file_name != "")
            {
                UpdateProductCommand.Parameters.AddWithValue("@productImage", file_name);
            }
            else
            {
                UpdateProductCommand.Parameters.AddWithValue("@productImage", currentproductImage.AlternateText);
            }

            UpdateProductCommand.Parameters.AddWithValue("@productID", product_ID);

            connect.Open();
            UpdateProductCommand.ExecuteNonQuery();
            connect.Close();
            Response.Write("<script>alert('Added Successfully');</script>");
            Response.Redirect("ProductList.aspx");
        }
    }
}