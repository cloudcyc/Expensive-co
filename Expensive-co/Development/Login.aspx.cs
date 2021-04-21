using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Expensive_co.Development
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ExpensiveDBConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from Users where userEmail=@username and userPassword=@password", connect);
            
            cmd.Parameters.AddWithValue("@username", this.Email.Text);
            cmd.Parameters.AddWithValue("@password", this.Password.Text);
            
            
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            adapter.Fill(dt);
            connect.Open();
            int i = cmd.ExecuteNonQuery();
            connect.Close();
            int RowCount = dt.Rows.Count;
            for (int counted = 0; counted < RowCount; counted++)
            {
                string LoginEmail = dt.Rows[counted]["userEmail"].ToString();
                string LoginPassword = dt.Rows[counted]["userPassword"].ToString();
                string LoginUserFullName = dt.Rows[counted]["userFullName"].ToString();

                if (LoginEmail == this.Email.Text && LoginPassword == this.Password.Text)
                {
                    Session["userEmail"] = LoginEmail;
                    Session["userFullName"] = LoginUserFullName;
                    if (dt.Rows[counted]["userRole"].ToString() == "Admin")
                    {
                        Session["userRole"] = "Admin";
                        Response.Redirect("AdminDashboard.aspx");
                    }
                    else if (dt.Rows[counted]["userRole"].ToString() == "Member")
                    {
                        Session["userRole"] = "Member";
                        Response.Redirect("Home.aspx");
                    }
                }
                else
                {
                    //incorrect
                    //lb1.Text = "Invalid User Name or Password! Please try again!";
                }
            }
        }


    }
}