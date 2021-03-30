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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ExpensiveDBConnectionString"].ConnectionString);
            
            string checkuser = "select count(*) from ExpensiveDB";
            SqlCommand cmd = new SqlCommand(checkuser, connect);
            cmd.ExecuteScalar();
            connect.Open();
            connect.Close();






        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            if (this.TextBox1.Text == "admin" && this.TextBox2.Text == "123")
            {
                this.Label1.Text = this.TextBox1.Text;
            }
            else
            {
                this.Label1.Text = "Incorrect Password";
            }
        }
    }
}