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
                //Response.Redirect("Shops.aspx");
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