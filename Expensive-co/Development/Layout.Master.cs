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
                
                
                
                //html.Append("<h2>Admin</h2>");
                //Navgiation to Admin Dashboard and logout btn***

                //Login button change to Account button which return to dashboard for Admin
                //this.btn1.HRef = "AdminDashboard.aspx";
                //this.LoginAccount_btn_Label.Text = "Return Dashboard";

                ////Register button change to Logout button
                //this.btn2.HRef = "Logout.aspx";
                //this.RegisterLogout_btn_Label.Text = "Logout";

            }
            else if (Session["userEmail"] != null && Session["userRole"] == "Member")
            {
                //profile, cart, order
                //<div class="dropdown">
                //      <a class="dropdown-toggle" href="#" role="button" id="dropdownMenuLink" data-bs-toggle="dropdown" aria-expanded="false">
                //        Dropdown link
                //      </a>
                
                //      <ul class="dropdown-menu" aria-labelledby="dropdownMenuLink">
                //        <li><a class="dropdown-item" href="#">Action</a></li>
                //        <li><a class="dropdown-item" href="#">Another action</a></li>
                //        <li><a class="dropdown-item" href="#">Something else here</a></li>
                //      </ul>
                //    </div>

                
                //html.Append("<a class=\"dropdown-item\" href=\"CusCartPage.aspx\">View Cart</a>");
                //html.Append("<a class=\"dropdown-item\" href=\"CusOrderHistory.aspx\">Order History</a>");
                
                html.Append("<a class=\"dropdown-item\" href=\"Logout.aspx\">Logout</a>");

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