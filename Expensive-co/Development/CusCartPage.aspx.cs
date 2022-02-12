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
    public partial class CusCartPage : System.Web.UI.Page
    {
        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ExpensiveDBConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userRole"] == null || Session["userRole"] == "Admin")
            {
                Response.Write("<script>alert('Are you lost?');</script>");
                Response.Redirect("Home.aspx");
            }

            DataTable dt = GetData();
            StringBuilder html = new StringBuilder();
            double TotalAmountPerItem = 0;
            double TotalAmount = 0;

            foreach (DataRow row in dt.Rows)
            {
                this.currentCartID.Text = row["cartID"].ToString();
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
                    html.Append("<td class=\"w-25\">");
                        html.Append("<img class=\"col-md-6 pb-5 img-fluid\" src =\"../Assets/productImg/" + rowInCart["productImage"] + "\">");
                    html.Append("</td>");
                    html.Append("<td>" + rowInCart["productName"] + "</td>");
                }
                
                html.Append("<td>" + "RM "+ row["productPrice"] + "</td>");
                html.Append("<td>" + row["productQuantity"] + "</td>");
                html.Append("<td>" + row["productRequest"] + "</td>");
                html.Append("<td>");
                html.Append("<a class=\"btn btn-danger text-white\" href=\"DeleteFunction.aspx?inCartproduct_ID=" + row["productID"] + "&currentCart_ID=" + row["cartID"] + "\">Delete</a>");
                html.Append("</td>");


                html.Append("</tr>");
                TotalAmountPerItem = Convert.ToDouble(row["productPrice"]) * Convert.ToInt32(row["productQuantity"]);
                TotalAmount = TotalAmount + TotalAmountPerItem;

            }
            this.TotalAmount.Text = TotalAmount.ToString();
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

        }

        private DataTable GetData()
        {
            
            SqlCommand cmd = new SqlCommand("SELECT * FROM Carts WHERE userID ="+ Convert.ToInt32(Session["userID"]) + "AND cartStatus = 'Pending'", connect);
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = connect;
                    sda.SelectCommand = cmd;
                    using (DataTable testingdt = new DataTable())
                    {
                        sda.Fill(testingdt);
                        return testingdt;
                    }
                }
            }
        }

        protected void CheckOutBtn_Click(object sender, EventArgs e)
        {
            if (this.currentCartID.Text != "NoCartID")
            {
                DateTime currentTime = DateTime.Now;
                String CheckOutQuery = "INSERT INTO Orders (cartID, totalPrice, userID, orderStatus, orderDate) VALUES(@cartID, @totalPrice, @userID, @orderStatus, @orderDate)";
                SqlCommand CheckOutCommand = new SqlCommand(CheckOutQuery, connect);
                CheckOutCommand.Parameters.AddWithValue("@cartID", Convert.ToInt32(this.currentCartID.Text));
                CheckOutCommand.Parameters.AddWithValue("@totalPrice", this.TotalAmount.Text);
                CheckOutCommand.Parameters.AddWithValue("@userID", Convert.ToInt32(Session["userID"]));
                CheckOutCommand.Parameters.AddWithValue("@orderStatus", "Packing");
                CheckOutCommand.Parameters.AddWithValue("@orderDate", currentTime.ToString("yyyy-MM-dd hh:mm tt"));

                String UpdateCartQuery = "Update Carts SET cartStatus = @cartStatus WHERE cartID=@cartID";
                SqlCommand UpdateCartCommand = new SqlCommand(UpdateCartQuery, connect);
                UpdateCartCommand.Parameters.AddWithValue("@cartStatus", "Checked Out");
                UpdateCartCommand.Parameters.AddWithValue("@cartID", Convert.ToInt32(this.currentCartID.Text));
                connect.Open();
                UpdateCartCommand.ExecuteNonQuery();
                CheckOutCommand.ExecuteNonQuery();
                connect.Close();

                Response.Redirect("CusOrderHistory.aspx");
            }
            else
            {
                Response.Write("<script>alert('Please add some item to check out.');</script>");
            }
            
        }
    }
}