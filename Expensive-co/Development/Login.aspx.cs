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

            if (dt.Rows.Count > 0)
            {
                Session["userEmail"] = this.Email.Text;
                Response.Redirect("Home.aspx");
               
            }
            else
            {
                this.Label1.Text = "Incorrect Email or Password";
            }
        }


    }
}