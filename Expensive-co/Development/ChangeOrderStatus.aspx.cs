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
    public partial class ChangeOrderStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int order_ID = Convert.ToInt32(Request.QueryString["orderID"]);
            string order_Status = Request.QueryString["orderStatus"];
            string query = null;

            
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ExpensiveDBConnectionString"].ConnectionString);
            if (order_Status == "Packing")
            {
                query = "Update Orders SET orderStatus = 'Delivered' WHERE orderID=" + order_ID;
            }
            else if (order_Status == "Delivered")
            {
                query = "Update Orders SET orderStatus = 'Packing' WHERE orderID=" + order_ID;
            }

            SqlCommand UpdateOrderStatus = new SqlCommand(query, connect);
            connect.Open();
            UpdateOrderStatus.ExecuteNonQuery();
            connect.Close();
            Response.Redirect("SalesHistory.aspx");
        }
    }
}