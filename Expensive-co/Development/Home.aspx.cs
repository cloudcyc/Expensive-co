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
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ExpensiveDBConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataTable dt = this.GetNewestProduct();
                StringBuilder html = new StringBuilder();

                foreach (DataRow row in dt.Rows)
                {
                    html.Append("<div class=\"col-12 col-md-4 p-5 mt-3\">");
                    html.Append("<a href=\"Product_information.aspx?productID=" + row["productID"] + "\" ><img src =\"../Assets/productImg/" + row["productImage"] + "\" class=\"rounded-circle img-fluid border\"></a>");
                    html.Append("<h5 class=\"text-center mt-3 mb-3\">" + row["productName"] + "</h5>");
                    html.Append("<p class=\"text-center\"><a href=\"Product_information.aspx?productID=" + row["productID"] + "\" class=\"btn btn-success\">Go Shop</a></p>");
                    html.Append("</div>");
                }

                NewProduct.Controls.Add(new Literal { Text = html.ToString() });

                DataTable MostPopularDT = this.GetMostPopular();
                StringBuilder html2 = new StringBuilder();
                foreach (DataRow row in MostPopularDT.Rows)
                {
                    int totalpurchased = 5;
                    if (Convert.ToInt32(row["TotalProduct"]) <= 5)
                    {
                        totalpurchased = Convert.ToInt32(row["TotalProduct"]);
                    }


                    SqlCommand SelectedMostPopularCommand = new SqlCommand("SELECT * FROM Products WHERE productID =" + row["productID"] + " AND productStatus=1", connect);
                    SqlDataAdapter SelectedMostPopularAdapter = new SqlDataAdapter(SelectedMostPopularCommand);
                    DataTable SelectedMostPopularDT = new DataTable();
                    SelectedMostPopularAdapter.Fill(SelectedMostPopularDT);
                    connect.Open();
                    SelectedMostPopularCommand.ExecuteNonQuery();
                    connect.Close();
                    html2.Append("<div class=\"col-12 col-md-4 mb-4\">");
                    html2.Append("<div class=\"card h-100 product-wap\">");
                    foreach (DataRow rowPopular in SelectedMostPopularDT.Rows)
                    {
                        html2.Append("<a href=\"Product_information.aspx?productID=" + rowPopular["productID"] + "\">");
                        html2.Append("<img src = \"../Assets/productImg/" + rowPopular["productImage"] + "\" class=\"card-img-top h-100\" alt=" + rowPopular["productImage"] + ">");
                        html2.Append("</a>");
                        html2.Append("<div class=\"card-body\">");
                        html2.Append("<ul class=\"list-unstyled d-flex justify-content-between\">");
                        html2.Append("<li>");
                        for (int i = 0; i < totalpurchased; i++)
                        {
                            html2.Append("<i class=\"text-warning fa fa-star\"></i>");
                        }

                        html2.Append("</li>");
                        html2.Append("<li class=\"text-muted text-right\">RM " + rowPopular["productPrice"] + "</li>");
                        html2.Append("</ul>");
                        html2.Append("<a href=\"Product_information.aspx?productID=" + rowPopular["productID"] + "\" class=\"h2 text-decoration-none text-dark\">" + rowPopular["productName"] + "</a>");

                        html2.Append("<p class=\"text-muted\"></p>");
                        html2.Append("</div>");


                    }
                    html2.Append("</div>");
                    html2.Append("</div>");
                }
                BestSeller.Controls.Add(new Literal { Text = html2.ToString() });
                
            }

            
        }
        private DataTable GetNewestProduct()
        {
            
            SqlCommand cmd = new SqlCommand("SELECT TOP 3 * FROM Products WHERE productStatus=1 ORDER BY productID DESC", connect);
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = connect;
                    sda.SelectCommand = cmd;
                    using (DataTable NewestProductDT = new DataTable())
                    {
                        sda.Fill(NewestProductDT);
                        return NewestProductDT;
                    }
                }
            }
        }

        private DataTable GetMostPopular()
        {

            SqlCommand cmd = new SqlCommand("SELECT TOP 3 COUNT('productID') as 'TotalProduct', ProductID FROM Carts GROUP BY productID ORDER BY COUNT('TotalProduct') DESC", connect);
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = connect;
                    sda.SelectCommand = cmd;
                    using (DataTable MostPopularDT = new DataTable())
                    {
                        sda.Fill(MostPopularDT);
                        return MostPopularDT;
                    }
                }
            }
        }
    }
}