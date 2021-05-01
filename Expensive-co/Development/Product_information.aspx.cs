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
    public partial class Product_information : System.Web.UI.Page
    {
        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ExpensiveDBConnectionString"].ConnectionString);
        
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["productID"] == null)
            {
                Response.Redirect("Shops.aspx");
            }
            else
            {
                int product_ID = Convert.ToInt32(Request.QueryString["productID"]);
                SqlCommand SelectedProductCommand = new SqlCommand("SELECT* FROM Products WHERE productID =" + product_ID, connect);
                SqlDataAdapter SelectedProductAdapter = new SqlDataAdapter(SelectedProductCommand);
                DataTable SelectedProductDT = new DataTable();
                SelectedProductAdapter.Fill(SelectedProductDT);
                connect.Open();
                SelectedProductCommand.ExecuteNonQuery();
                connect.Close();

                

                foreach (DataRow row in SelectedProductDT.Rows)
                {
                    
                    this.Image1.ImageUrl = "~/Assets/productImg/" + row["productImage"];
                    this.Image1.AlternateText = row["productImage"].ToString();
                    this.HiddenProductID.Text = row["productID"].ToString();
                    this.HiddenProductCategory.Text = row["productCategory"].ToString();
                    Label1.Text = row["productName"].ToString();
                    Label2.Text = row["productPrice"].ToString();
                    Label3.Text = row["productBrand"].ToString();
                    Label4.Text = row["productDescription"].ToString();

                    if(row["productCategory"].ToString() == "Shoe")
                    {
                        this.DropDownList1.Visible = true;
                        this.DropDownList2.Visible = false;
                        this.Label5.Visible = false;
                    }
                    else if (row["productCategory"].ToString() == "Accessory")
                    {
                        this.DropDownList1.Visible = false;
                        this.DropDownList2.Visible = false;
                        this.Label5.Visible = true;
                    }
                    else
                    {
                        this.DropDownList1.Visible = false;
                        this.DropDownList2.Visible = true;
                        this.Label5.Visible = false;
                    }
                }
                
            }
        }

        protected void AddToCartBtn_Click(object sender, EventArgs e)
        {
            String AddCartQuery = null;
            String CheckCartQuery = null;
            int cartNum = 1;
            if (Session["userRole"] == "Admin")
            {
                Response.Redirect("AdminDashboard.aspx");
                //Error message for you are an Admin

            }
            else if (Session["userRole"] == null)
            {
                Response.Redirect("Login.aspx");
                //Error message for you are an Admin
            }
            else if (Session["userRole"] == "Member")
            {
                //check existing cart
                CheckCartQuery = "SELECT COUNT(productID) as 'Number of product', cartID FROM Carts WHERE cartStatus = 'Checked Out' AND userID =" + Convert.ToInt32(Session["userID"]) + " GROUP BY cartID"; //Thanks JY
                SqlCommand CheckCartCommand = new SqlCommand(CheckCartQuery, connect);
                SqlDataAdapter CheckCartAdapter = new SqlDataAdapter(CheckCartCommand);
                DataTable CheckCartDT = new DataTable();
                CheckCartAdapter.Fill(CheckCartDT);

                connect.Open();
                CheckCartCommand.ExecuteNonQuery();
                connect.Close();

                int RowCount = CheckCartDT.Rows.Count;
                for (int counted = 0; counted <= RowCount; counted++)
                {
                    cartNum = cartNum + 1;
                }
                //End check cart

                AddCartQuery = "INSERT INTO Carts (cartID, productID, productPrice, productQuantity, cartStatus, userID, productRequest) VALUES (@cartID,@productID,@productPrice,@productQuantity,@cartStatus,@userID,@productRequest)";
                SqlCommand AddCartCommand = new SqlCommand(AddCartQuery, connect);
   
                AddCartCommand.Parameters.AddWithValue("@cartID", Session["userID"].ToString() + "00" + cartNum.ToString());
                AddCartCommand.Parameters.AddWithValue("@productID", Convert.ToInt32(this.HiddenProductID.Text));
                AddCartCommand.Parameters.AddWithValue("@productPrice", Convert.ToInt32(this.Label2.Text));
                AddCartCommand.Parameters.AddWithValue("@productQuantity", Convert.ToInt32(this.QuantityNumber.Text));
                AddCartCommand.Parameters.AddWithValue("@cartStatus", "Pending");
                AddCartCommand.Parameters.AddWithValue("@userID", Convert.ToInt32(Session["userID"]));

                if (this.HiddenProductCategory.Text == "Accessory")
                {
                    AddCartCommand.Parameters.AddWithValue("@productRequest", "Item is " + this.Label5.Text);
                }
                else if (this.HiddenProductCategory.Text == "Shoe")
                {
                    if (this.DropDownList1.SelectedIndex == 0)
                    {
                        //message box choose a Size
                        return;

                    }
                    else
                    {
                        AddCartCommand.Parameters.AddWithValue("@productRequest", "Requested product size " + this.DropDownList1.Text);
                    }
                    
                }
                else
                {
                    if (this.DropDownList2.SelectedIndex == 0)
                    {
                        //message box choose a Size
                        return;

                    }
                    else
                    {
                        AddCartCommand.Parameters.AddWithValue("@productRequest", "Requested product size " + this.DropDownList2.Text);
                    }
                }
                connect.Open();
                AddCartCommand.ExecuteNonQuery();
                connect.Close();
                //Finish go to cart
                Response.Redirect("CusCartPage.aspx");
            }
        }

        protected void MinusQuantity_Click(object sender, EventArgs e)
        {
            int currentQuantity = Convert.ToInt32(this.QuantityNumber.Text);
            int ResultAfterMinus = currentQuantity - 1;
            if (ResultAfterMinus == 0)
            {
                this.QuantityNumber.Text = "1";
            }
            else
            {
                this.QuantityNumber.Text = Convert.ToString(ResultAfterMinus);
            }
        }

        protected void AddQuantity_Click(object sender, EventArgs e)
        {
            int currentQuantity = Convert.ToInt32(this.QuantityNumber.Text);
            int ResultAfterAdd = currentQuantity + 1;
            
            this.QuantityNumber.Text = Convert.ToString(ResultAfterAdd);
            
        }
    }
}