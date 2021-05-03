using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Expensive_co.Development
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable OrderTable = this.GetTotalSalesData();
            object TotalSalesObject;
            TotalSalesObject = OrderTable.Compute("Sum(totalPrice)", string.Empty);
            this.TotalSales.Text = "RM " + TotalSalesObject.ToString();

            //displaying the total Member
            DataTable MemberTable = this.GetMemberData();
            this.TotalMemberCount.Text = MemberTable.Rows.Count.ToString();

            //displaying the total Product
            DataTable ProductTable = this.GetProductData();
            this.TotalProductCount.Text = ProductTable.Rows.Count.ToString();


            DataTable dt = GetData();
            StringBuilder html = new StringBuilder();

            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");

                html.Append("<td>" + row["orderID"] + "</td>");
                html.Append("<td>" + row["cartID"] + "</td>");
                html.Append("<td>" + row["userID"] + "</td>");
                html.Append("<td>RM " + row["totalPrice"] + "</td>");
                html.Append("<td>" + row["orderDate"] + "</td>");
                html.Append("<td>");
                    html.Append("<a class=\"btn btn-success text-white\" href=\"AdminViewOrderCart.aspx?cart_ID=" + row["cartID"] + "\">View Cart</a>");
                html.Append("</td>");
                html.Append("</tr>");

            }
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

        }

        //Get product Date function
        private DataTable GetProductData()
        {
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ExpensiveDBConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Products", connect);
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = connect;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        //Get Member Date function
        private DataTable GetMemberData()
        {
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ExpensiveDBConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users Where userRole='Member'", connect);
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = connect;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        private DataTable GetTotalSalesData()
        {
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ExpensiveDBConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Orders", connect);
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = connect;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        private DataTable GetData()
        {
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ExpensiveDBConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT TOP 5 * FROM Orders ORDER BY orderID DESC", connect);
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