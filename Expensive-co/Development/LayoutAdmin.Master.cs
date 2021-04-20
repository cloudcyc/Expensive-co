using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Expensive_co.Development
{
    public partial class LayoutAdmin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Identification if user is an admin, if not return back to Homepage
            if (Session["userRole"] != "Admin" || Session["userRole"] == null)
            {
                Response.Redirect("Home.aspx");
            }

            this.AdminName.Text = Session["userFullName"].ToString();
        }
    }
}