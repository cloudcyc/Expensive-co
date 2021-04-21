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
            
            if (Session["userEmail"] != null && Session["userRole"] == "Admin")
            {
                //Login button change to Account button which return to dashboard for Admin
                this.btn1.HRef = "AdminDashboard.aspx";
                this.LoginAccount_btn_Label.Text = "Return Dashboard";

                //Register button change to Logout button
                this.btn2.HRef = "Logout.aspx";
                this.RegisterLogout_btn_Label.Text = "Logout";
                
            }else if (Session["userEmail"] != null && Session["userRole"] == "Member")
            {
                //Login button change to Account button which lead to dashboard for member
                this.btn1.HRef = "#";
                this.LoginAccount_btn_Label.Text = "Account";

                //Register button change to Logout button
                this.btn2.HRef = "Logout.aspx";
                this.RegisterLogout_btn_Label.Text = "Logout";
            }
            else
            {
                //Login button change to Account button which lead to dashboard for member
                this.btn1.HRef = "Login.aspx";
                this.LoginAccount_btn_Label.Text = "Login";

                //Register button change to Logout button
                this.btn2.HRef = "Register.aspx";
                this.RegisterLogout_btn_Label.Text = "Register";
            }
  
        }
        
    }
}