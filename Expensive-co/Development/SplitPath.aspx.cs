using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Expensive_co.Development
{
    public partial class SplitPath : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Path1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contact.aspx");
        }

        protected void Path2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CusOrderHistory.aspx");
        }
    }
}