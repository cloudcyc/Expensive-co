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
    public partial class DeleteProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int product_ID = Convert.ToInt32(Request.QueryString["productID"]);
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ExpensiveDBConnectionString"].ConnectionString);
            SqlCommand DeleteProduct = new SqlCommand("DELETE FROM Products WHERE productID ="+ product_ID, connect);
            connect.Open();
            DeleteProduct.ExecuteNonQuery();
            connect.Close();
            Response.Redirect("ProductList.aspx");
        }
    }
}