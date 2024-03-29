﻿using System;
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
    public partial class CusOrderHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userRole"] == null || Session["userRole"] == "Admin")
            {
                Response.Write("<script>alert('Are you lost?');</script>");
                Response.Redirect("Home.aspx");
            }
            DataTable dt = GetData();
            StringBuilder html = new StringBuilder();

            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");


                html.Append("<td>" + row["orderID"] + "</td>");
                html.Append("<td>" + row["cartID"] + "</td>");
                html.Append("<td>RM " + row["totalPrice"] + "</td>");
                html.Append("<td>" + row["orderStatus"] + "</td>");
                html.Append("<td>" + row["orderDate"] + "</td>");
                html.Append("<td>");
                    html.Append("<a class=\"btn btn-success text-white\" href=\"CusOrderViewCart?cart_ID=" + row["cartID"] + "\">View Cart</a>");
                html.Append("</td>");

                html.Append("</tr>");

            }
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
        }

        private DataTable GetData()
        {
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ExpensiveDBConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Orders WHERE userID=" + Convert.ToInt32(Session["userID"]) + " ORDER BY orderID DESC", connect);
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = connect;
                    sda.SelectCommand = cmd;
                    using (DataTable gettingDataDT = new DataTable())
                    {
                        sda.Fill(gettingDataDT);
                        return gettingDataDT;
                    }
                }
            }
        }

    }
}