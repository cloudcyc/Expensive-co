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
    public partial class CusCartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DataTable dt = GetData();
            StringBuilder html = new StringBuilder();

            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");

                html.Append("<td>");
                //html.Append("<div class=\"col-3 p-md-5\">");
                html.Append("<img class=\"col-md-6 col-lg-3 pb-5\" src =\"../Assets/img/lv.jpg\">");
                //html.Append("</div>");
                html.Append("</td>");
                html.Append("<td>" + row["productName"] + "</td>");
                html.Append("<td>" + row["productPrice"] + "</td>");
                html.Append("<td>");
                html.Append("<a class=\"btn btn-danger text-white\" href=\"#\">Delete</a>");
                html.Append("</td>");


                html.Append("</tr>");

            }
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

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