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
    public partial class AdminManageUser : System.Web.UI.Page
    {
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
                html.Append("RM" + row["userEmail"] + "<br>");
                html.Append("RM" + row["userContact"] + "<br>");
                html.Append("RM" + row["userRole"] + "<br>");

                html.Append("<div class=\"text-center  py-3\">");
                html.Append("<a class=\"btn btn-success text-white\">Edit</a>");
                html.Append("<a class=\"btn btn-danger text-white\">Delete</a>");


                html.Append("</div>");
                html.Append("</div>");
                html.Append("</div>");
                html.Append("</div>");

            }
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
        }

        private DataTable GetData()
        {
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ExpensiveDBConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users", connect);
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