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
    public partial class Shops : System.Web.UI.Page
    {
        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ExpensiveDBConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataTable dt = this.GetData();
                StringBuilder html = new StringBuilder();

                foreach (DataRow row in dt.Rows)
                {
                     html.Append("<div class=\"col-md-6 col-lg-3 pb-5\">");
                        html.Append("<a href=\"Product_information.aspx?productID=" + row["productID"] + "\">");
                            html.Append("<div class=\"card mb-4 h-100 product-wap rounded-0\">");
                            if (row["productImage"].ToString() == "")
                            {
                                html.Append("<img class=\"card-img rounded-0 h-100\" src=\"../Assets/img/NoProductImage.png\">");
                            }
                            else
                            {
                                html.Append("<img class=\"card-img rounded-0 h-100\" src =\"../Assets/productImg/" + row["productImage"] + "\" >");
                            }
                            html.Append("<div class=\"card-body\">");

                            html.Append("<h3>" + row["productName"] + "</h3>");
                            html.Append("RM" + row["productPrice"] + "<br>");

                            html.Append("</div>");
                            html.Append("</div>");
                        html.Append("</a>");
                     html.Append("</div>");
                    
                }

                PlaceHolder2.Controls.Add(new Literal { Text = html.ToString() });
            }
        }
        private DataTable GetData()
        {
            if (Request.QueryString["searchName"] == null)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products WHERE productStatus=1", connect);
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = connect;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            else
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products WHERE productStatus=1 AND productName LIKE '"+ Request.QueryString["searchName"].ToString() + "%'", connect);
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = connect;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }

                
            
        }
        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Shops.aspx?searchName=" + this.Searchbar.Text);
        }   
    }
}