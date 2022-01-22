using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace Expensive_co.Development
{
    public partial class SalesHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = GetData();
            StringBuilder html = new StringBuilder();

            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");

                    html.Append("<td>" + row["orderID"] + "</td>");
                    html.Append("<td>" + row["cartID"] + "</td>");
                    html.Append("<td>" + row["userID"] + "</td>");
                    html.Append("<td>RM "+ row["totalPrice"] + "</td>");
                    html.Append("<td>" + row["orderDate"] + "</td>");
                    html.Append("<td>");
                //+row["orderStatus"] + "</td>"
                //create dropdown onclick
                /*html.Append("<div class=\"dropdown\">");
                    html.Append("<button type=\"button\" class=\"btn btn-primary dropdown-toggle\" data-toggle=\"dropdown\">Status Dropdown</button>");
                    html.Append("<div class=\"dropdown-menu\">");
                    html.Append("<a class=\"dropdown-item\" href=\"#\">Action</a>");
                    html.Append("<a class=\"dropdown-item\" href=\"#\">Another action</a>");
                    html.Append("<a class=\"dropdown-item\" href=\"#\">Something else here</a>");
                    html.Append("</div>");
                html.Append("</div>");*/

                //html.Append("<div class=\"dropdown\">");
                //html.Append("<a class=\"dropdown-toggle\" role=\"button\" id=\"dropdownMenuLink\" data-bs-toggle=\"dropdown\" aria-expanded=\"false\">" + row["orderStatus"] + "</a>");
                //html.Append("<ul class=\"dropdown-menu\" aria-labelledby=\"dropdownMenuLink\">");
                //html.Append("<li><a class=\"dropdown-item\" href=\"#\">Packing</a></li>");
                //html.Append("<li><a class=\"dropdown-item\" href=\"#\">Shipped Out</a></li>");
                //html.Append("</ul>");
                //html.Append("</div>");
                if (row["orderStatus"].ToString() == "Packing")
                {
                    html.Append("<a class=\"btn btn-warning text-white\" href=\"ChangeOrderStatus.aspx?orderStatus=" + row["orderStatus"] + "&orderID=" + row["orderID"] + "\">" + row["orderStatus"] +"</a>");
                }
                else
                {
                    html.Append("<a class=\"btn btn-primary text-white\" href=\"ChangeOrderStatus.aspx?orderStatus=" + row["orderStatus"] + "&orderID=" + row["orderID"] + "\">" + row["orderStatus"] + "</a>");
                }

                html.Append("</td>");
                    html.Append("<td>");
                        html.Append("<a class=\"btn btn-danger text-white\" href=\"DeleteFunction.aspx?order_ID=" + row["orderID"] + "&cartInOrder_ID=" + row["cartID"] + "\">Delete</a>");
                        html.Append("<a class=\"btn btn-success text-white\" href=\"AdminViewOrderCart.aspx?cart_ID=" + row["cartID"] + "\">View Cart</a>");
                    html.Append("</td>");

                html.Append("</tr>");

            }
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

        }
        private DataTable GetData()
        {
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ExpensiveDBConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Orders ORDER BY orderID DESC", connect);
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = connect;
                    sda.SelectCommand = cmd;
                    using (DataTable getOrderTable = new DataTable())
                    {
                        sda.Fill(getOrderTable);
                        return getOrderTable;
                    }
                }
            }
        }
    }
}