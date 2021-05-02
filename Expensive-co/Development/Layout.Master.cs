using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Expensive_co.Development
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        
       protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder html = new StringBuilder();
            if (Session["userEmail"] != null && Session["userRole"] == "Admin")
            {

                html.Append("<a runat=\"server\" id=\"btn1\" class=\"nav-icon position-relative text-decoration-none\" href=\"AdminDashboard.aspx\">");
                html.Append("Return Dashboard");
                html.Append("</a>");

                html.Append("| &nbsp; &nbsp;");

                html.Append("<a runat=\"server\" id=\"btn2\" class=\"nav-icon position-relative text-decoration-none\" href=\"Logout.aspx\">");
                html.Append("Logout");
                html.Append("</a>");

            

            }
            else if (Session["userEmail"] != null && Session["userRole"] == "Member")
            {
                

                

                html.Append("<div class=\"dropdown\">");
                html.Append("<a class=\"dropdown-toggle\" href=\"CusEditProfile.aspx\" role=\"button\" id=\"dropdownMenuLink\" data-bs-toggle=\"dropdown\" aria-expanded=\"false\">"+ Session["userFullName"].ToString() +"</a>");
                html.Append("<ul class=\"dropdown-menu\" aria-labelledby=\"dropdownMenuLink\">");
                html.Append("<li><a class=\"dropdown-item\" href=\"CusEditProfile.aspx\">Profile</a></li>");
                html.Append("<li><a class=\"dropdown-item\" href=\"CusCartPage.aspx\">View Cart</a></li>");
                html.Append("<li><a class=\"dropdown-item\" href=\"CusOrderHistory.aspx\">Order History</a></li>");
                html.Append("</ul>");
                html.Append("</div>");

                html.Append("&nbsp; &nbsp; | &nbsp; &nbsp;");

                html.Append("<a runat=\"server\" id=\"btn2\" class=\"nav-icon position-relative text-decoration-none\" href=\"Logout.aspx\">");
                html.Append("Logout");
                html.Append("</a>");



                //html.Append("<a class=\"dropdown-item\" href=\"CusCartPage.aspx\">View Cart</a>");
                //html.Append("<a class=\"dropdown-item\" href=\"CusOrderHistory.aspx\">Order History</a>");

                

                //html.Append("<h2>Member</h2>");
                //Dropdown to go profile, cart and order history and Logout button ***

                //Login button change to Account button which lead to dashboard for member
                //this.btn1.HRef = "CusEditProfile.aspx";
                //this.LoginAccount_btn_Label.Text = "Account";

                ////Register button change to Logout button
                //this.btn2.HRef = "Logout.aspx";
                //this.RegisterLogout_btn_Label.Text = "Logout";
            }
            else
            {
                
                html.Append("<a runat=\"server\" id=\"btn1\" class=\"nav-icon position-relative text-decoration-none\" href=\"Login.aspx\">");
                html.Append("Login");
                html.Append("</a>");

                html.Append("| &nbsp; &nbsp;");

                html.Append("<a runat=\"server\" id=\"btn2\" class=\"nav-icon position-relative text-decoration-none\" href=\"Register.aspx\">");
                html.Append("Register");
                html.Append("</a>");
                //html.Append("<h2>Login</h2>");
                //Login button and Register button***

                //Login button change to Account button which lead to dashboard for member
                //this.btn1.HRef = "Login.aspx";
                //this.LoginAccount_btn_Label.Text = "Login";

                ////Register button change to Logout button
                //this.btn2.HRef = "Register.aspx";
                //this.RegisterLogout_btn_Label.Text = "Register";
            }
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

        }
        
    }
}