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
    public partial class AdminManageUser : System.Web.UI.Page
    {
        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ExpensiveDBConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = GetData();
            StringBuilder html = new StringBuilder();

            foreach (DataRow row in dt.Rows)
            {
                html.Append("<div class=\"col-md-6 col-lg-3 pb-5\">");
                html.Append("<div class=\"card mb-4 product-wap rounded-0\">");
                html.Append("<div class=\"card-body\">");

                html.Append("<h3>" + row["userFullName"] + "</h3>");
                html.Append( row["userEmail"] + "<br>");
                html.Append( row["userContact"] + "<br>");
                html.Append( row["userRole"] + "<br>");

                html.Append("<div class=\"text-center  py-3\">");
                html.Append("<a class=\"btn btn-success text-white\" href=\"AdminEditUser.aspx?userID=" + row["userID"] + "\"> Edit</a>");
                html.Append("<a class=\"btn btn-danger text-white\"  href=\"DeleteFunction.aspx?userID=" + row["userID"] + "\">Delete</a>");


                html.Append("</div>");
                html.Append("</div>");
                html.Append("</div>");
                html.Append("</div>");

            }
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
        }

        private DataTable GetData()
        {
            if (Request.QueryString["searchName"] == null)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE NOT userID=" + Convert.ToInt32(Session["userID"]), connect);
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
            else
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE NOT userID=" + Convert.ToInt32(Session["userID"]) + "AND userFullName LIKE '" + Request.QueryString["searchName"].ToString() +"%'", connect);
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
            
            

        }
       
        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminManageUser.aspx?searchName="+ this.Searchbar.Text);
        }
    }
}