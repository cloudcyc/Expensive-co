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
    public partial class AdminViewFeedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = GetData();
            StringBuilder html = new StringBuilder();

            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                    html.Append("<td>" + row["feedbackID"] + "</td>");
                    html.Append("<td>" + row["feedback"] + "</td>");
                    html.Append("<td>" + row["feedbackDate"].ToString() + "</td>");
                    html.Append("<td>" + row["respondentName"] + "</td>");
                    html.Append("<td>" + row["respondentEmail"] + "</td>");
                html.Append("</tr>");

            }
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
        }

        private DataTable GetData()
        {
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ExpensiveDBConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Feedback", connect);
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = connect;
                    sda.SelectCommand = cmd;
                    using (DataTable getFeedbackTable = new DataTable())
                    {
                        sda.Fill(getFeedbackTable);
                        return getFeedbackTable;
                    }
                }
            }
        }

    }
}