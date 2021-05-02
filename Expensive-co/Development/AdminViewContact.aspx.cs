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
    public partial class AdminViewContact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //private DataTable GetData()
        //{
        //    SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ExpensiveDBConnectionString"].ConnectionString);
        //    SqlCommand cmd = new SqlCommand("SELECT * FROM Contacts", connect);
        //    {
        //        using (SqlDataAdapter sda = new SqlDataAdapter())
        //        {
        //            cmd.Connection = connect;
        //            sda.SelectCommand = cmd;
        //            using (DataTable getOrderTable = new DataTable())
        //            {
        //                sda.Fill(getOrderTable);
        //                return getOrderTable;
        //            }
        //        }
        //    }
        //}

    }
}