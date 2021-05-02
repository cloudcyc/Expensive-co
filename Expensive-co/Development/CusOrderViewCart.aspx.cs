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
    public partial class CusOrderViewCart : System.Web.UI.Page
    {
        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ExpensiveDBConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = GetData();
            StringBuilder html = new StringBuilder();
            double TotalAmountPerItem = 0;
            double TotalAmount = 0;

            foreach (DataRow row in dt.Rows)
            {

                SqlCommand SelectedProductInCartCommand = new SqlCommand("SELECT* FROM Products WHERE productID =" + row["productID"], connect);
                SqlDataAdapter SelectedProductInCartAdapter = new SqlDataAdapter(SelectedProductInCartCommand);
                DataTable SelectedProductInCartDT = new DataTable();
                SelectedProductInCartAdapter.Fill(SelectedProductInCartDT);
                connect.Open();
                SelectedProductInCartCommand.ExecuteNonQuery();
                connect.Close();

                html.Append("<tr>");

                foreach (DataRow rowInCart in SelectedProductInCartDT.Rows)
                {
                    html.Append("<td>");
                    html.Append("<img class=\"col-md-6 col-lg-3 pb-5\" src =\"../Assets/productImg/" + rowInCart["productImage"] + "\">");
                    html.Append("</td>");
                    html.Append("<td>" + rowInCart["productName"] + "</td>");
                }

                html.Append("<td>" + "RM " + row["productPrice"] + "</td>");
                html.Append("<td>" + row["productQuantity"] + "</td>");
                html.Append("<td>" + row["productRequest"] + "</td>");



                html.Append("</tr>");
                TotalAmountPerItem = Convert.ToDouble(row["productPrice"]) * Convert.ToInt32(row["productQuantity"]);
                TotalAmount = TotalAmount + TotalAmountPerItem;

            }
            this.TotalAmount.Text = TotalAmount.ToString();
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
        }
        private DataTable GetData()
        {

            SqlCommand cmd = new SqlCommand("SELECT * FROM Carts WHERE cartID =" + Convert.ToInt32(Request.QueryString["cart_ID"]), connect);
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = connect;
                    sda.SelectCommand = cmd;
                    using (DataTable getCartTable = new DataTable())
                    {
                        sda.Fill(getCartTable);
                        return getCartTable;
                    }
                }
            }
        }
    }
}