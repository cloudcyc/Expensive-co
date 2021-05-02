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
            string LoginEmail = null;
            string LoginPassword = null;
            string LoginUserFullName = null;
            string LoginUserRole = null;
            int LoginUserID = 0;
            int LoginUserPhone = 0;

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
                 LoginEmail = dt.Rows[counted]["userEmail"].ToString();
                 LoginPassword = dt.Rows[counted]["userPassword"].ToString();
                 LoginUserFullName = dt.Rows[counted]["userFullName"].ToString();
                 LoginUserRole = dt.Rows[counted]["userRole"].ToString();
                 LoginUserID = Convert.ToInt32(dt.Rows[counted]["userID"]);
                 LoginUserPhone = Convert.ToInt32(dt.Rows[counted]["userContact"]);

                
            }
            if (LoginEmail != this.Email.Text && LoginPassword != this.Password.Text)
            {
                Response.Write("<script>alert('Incorrect Email or Password');</script>");
                //Response.Redirect("Home.aspx");
                //this.Invalid.Text = "Incorrect Email or Password";
            }
            else
            {
                Session["userEmail"] = LoginEmail;
                Session["userFullName"] = LoginUserFullName;
                Session["userID"] = LoginUserID;
                Session["userPhone"] = LoginUserPhone;
                if (LoginUserRole == "Admin")
                {
                    Session["userRole"] = "Admin";
                    Response.Redirect("AdminDashboard.aspx");
                }
                else if (LoginUserRole == "Member")
                {
                    Session["userRole"] = "Member";
                    Response.Redirect("Home.aspx");
                }

            }
        }


    }
}