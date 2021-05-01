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
        

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ExpensiveDBConnectionString"].ConnectionString);
            int product_ID = 0;
            int user_ID = 0;
            int inCartproduct_ID = 0;
            int order_ID = 0;

            user_ID = Convert.ToInt32(Request.QueryString["userID"]);
            product_ID = Convert.ToInt32(Request.QueryString["productID"]);
            inCartproduct_ID = Convert.ToInt32(Request.QueryString["inCartproduct_ID"]);
            order_ID = Convert.ToInt32(Request.QueryString["order_ID"]);
            //if product id is not 0, run delete product
            if (product_ID != 0)
            {
                
                SqlCommand DeleteCommand = new SqlCommand("DELETE FROM Products WHERE productID =" + product_ID, connect);
                File.Delete(Server.MapPath("../Assets/productImg/") + Request.QueryString["productImage"]);
                connect.Open();
                DeleteCommand.ExecuteNonQuery();
                connect.Close();
                Response.Redirect("ProductList.aspx");
            }
            //if user_ID is not 0, run delete user
            else if (user_ID != 0)
            {
                
                SqlCommand DeleteCommand = new SqlCommand("DELETE FROM Users WHERE userID =" + user_ID, connect);

                connect.Open();
                DeleteCommand.ExecuteNonQuery();
                connect.Close();
                Response.Redirect("AdminManageUser.aspx"); 
            }
            else if (inCartproduct_ID != 0)
            {
                
                SqlCommand DeleteCommand = new SqlCommand("DELETE FROM Carts WHERE productID =" + inCartproduct_ID + "AND cartID =" + Convert.ToInt32(Request.QueryString["currentCart_ID"]) , connect);

                connect.Open();
                DeleteCommand.ExecuteNonQuery();
                connect.Close();
                Response.Redirect("CusCartPage.aspx");
            }
            else if (order_ID != 0)
            {
                SqlCommand DeleteCommand = new SqlCommand("DELETE FROM Orders WHERE orderID =" + order_ID, connect);
                SqlCommand DeleteCommand2 = new SqlCommand("DELETE FROM Carts WHERE cartID =" + Convert.ToInt32(Request.QueryString["cartInOrder_ID"]), connect); 

                connect.Open();
                DeleteCommand.ExecuteNonQuery();
                DeleteCommand2.ExecuteNonQuery();
                connect.Close();
                Response.Redirect("SalesHistory.aspx");
            }
            
        }
    }
}