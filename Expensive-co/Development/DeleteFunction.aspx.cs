using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Expensive_co.Development
{
    public partial class DeleteProduct : System.Web.UI.Page
    {
        int product_ID = 0;
        int user_ID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            user_ID = Convert.ToInt32(Request.QueryString["userID"]);
            product_ID = Convert.ToInt32(Request.QueryString["productID"]);
            //if product id is 0, run delete user
            if (product_ID == 0)
            {
                SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ExpensiveDBConnectionString"].ConnectionString);
                SqlCommand DeleteCommand = new SqlCommand("DELETE FROM Users WHERE userID =" + user_ID, connect);
                
                connect.Open();
                DeleteCommand.ExecuteNonQuery();
                connect.Close();
                Response.Redirect("AdminManageUser.aspx");
            }
            //if user_ID is 0, run delete product
            else if (user_ID == 0)
            {
                
                SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ExpensiveDBConnectionString"].ConnectionString);
                SqlCommand DeleteCommand = new SqlCommand("DELETE FROM Products WHERE productID =" + product_ID, connect);
                File.Delete(Server.MapPath("../Assets/productImg/") + Request.QueryString["productImage"]);
                connect.Open();
                DeleteCommand.ExecuteNonQuery();
                connect.Close();
                Response.Redirect("ProductList.aspx");
            }
            
        }
    }
}