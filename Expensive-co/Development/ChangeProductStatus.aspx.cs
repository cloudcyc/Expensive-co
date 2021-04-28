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
    public partial class ChangeProductStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int product_ID = Convert.ToInt32(Request.QueryString["productID"]);
            string product_Status = Request.QueryString["productStatus"];
            string query = null;

            
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ExpensiveDBConnectionString"].ConnectionString);
            if (product_Status == "1")
            {
                query = "Update Products SET productStatus = 2 WHERE productID=" + product_ID;
            }
            else if (product_Status == "2")
            {
                query = "Update Products SET productStatus = 1 WHERE productID=" + product_ID;
            }

            SqlCommand UpdateProductStatus = new SqlCommand(query, connect);
            connect.Open();
            UpdateProductStatus.ExecuteNonQuery();
            connect.Close();
            Response.Redirect("ProductList.aspx");
        }
    }
}