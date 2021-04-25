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
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataTable dt = this.GetData();
                StringBuilder html = new StringBuilder();

                foreach (DataRow row in dt.Rows)
                {

                    html.Append("<div class=\"col-md-6 col-lg-3 pb-5\">");
                    html.Append("<div class=\"card mb-4 product-wap rounded-0\">");
                    html.Append("<img class=\"card-img rounded-0\" src=\"../Assets/img/lv.jpg\">");
                    html.Append("<div class=\"card-body\">");

                    html.Append("<h3>" + row["productName"] + "</h3>");
                    html.Append("RM" + row["productPrice"] + "<br>");

                    html.Append("<div class=\"text-center  py-3\">");
                    html.Append("<a class=\"btn btn-success text-white\">Edit</a>");
                    html.Append("<a class=\"btn btn-danger text-white\">Delete</a>");
                    html.Append("<a class=\"btn btn-success text-white\"><i class=\"far fa-eye\"></i></a>");
                    html.Append("</div>");

                    html.Append("</div>");
                    html.Append("</div>");                    
                    html.Append("</div>");
                    


                }

                PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
            }
        }


        private DataTable GetData()
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
    }
}