using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Expensive_co.Development
{
    public partial class AddUser : System.Web.UI.Page
    {
        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ExpensiveDBConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddNewUserBtn_Click(object sender, EventArgs e)
        {
            SqlCommand addUserQuery = new SqlCommand("INSERT INTO Users (userFullName, userEmail, userContact, userPassword, userAddress, userRole, userDOB) VALUES (@userFullName,@userEmail,@userContact,@userPassword,@userAddress,@userRole,@userDOB)", connect);

            bool Validation = validationFunction(this.FullName.Text, this.Email.Text, this.Phone.Text, this.Password.Text, this.ConfirmPassword.Text, this.DOB.Text);

            if (Validation == true)
            {
                addUserQuery.Parameters.AddWithValue("@userFullName", this.FullName.Text);
                addUserQuery.Parameters.AddWithValue("@userEmail", this.Email.Text);
                addUserQuery.Parameters.AddWithValue("@userContact", this.Phone.Text);
                addUserQuery.Parameters.AddWithValue("@userPassword", this.ConfirmPassword.Text);
                addUserQuery.Parameters.AddWithValue("@userAddress", this.Address.Text);
                if (this.DropDownList1.SelectedIndex != 0)
                {
                    addUserQuery.Parameters.AddWithValue("@userRole", this.DropDownList1.Text);
                }
                else
                {
                    addUserQuery.Parameters.AddWithValue("@userRole", "Member");
                }
                
                addUserQuery.Parameters.AddWithValue("@userDOB", this.DOB.Text);

                connect.Open();
                int result = addUserQuery.ExecuteNonQuery();
                connect.Close();
                Response.Write("<script>alert('Added Successfully');</script>");
                Response.Redirect("Add User.aspx");

            }
            else
            {
                Response.Write("<script>alert('" + this.InvalidError.Text + "');</script>");
            }
        
        }

        public bool validationFunction(string Fullname, string Email, string PhoneNumber, string Password, string ConfirmPassword, string DOB)
        {
            Regex checkNum = new Regex(@"^\d+$"); //Only number
            Regex checkStrongPassword = new Regex(@"^.*(?=.{7,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9]).{6,20}$"); //Atleast 1 upper and lower, 1 number, and special character
            Regex checkEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"); //checking email can be xxx@mail.xxx.xx.xxx.my
            if (Password == ConfirmPassword)
            {
                if (Fullname != null && checkEmail.IsMatch(Email) && checkNum.IsMatch(PhoneNumber) && checkStrongPassword.IsMatch(Password) && checkStrongPassword.IsMatch(ConfirmPassword) && DOB != null)
                {
                    SqlCommand checkRegisteredEmail = new SqlCommand("select * from Users where userEmail=@userEmail", connect);
                    checkRegisteredEmail.Parameters.AddWithValue("@userEmail", Email);

                    SqlCommand checkRegisteredPhone = new SqlCommand("select * from Users where userContact=@userPhone", connect);
                    checkRegisteredPhone.Parameters.AddWithValue("@userPhone", PhoneNumber);
                    SqlDataAdapter adapterEmail = new SqlDataAdapter(checkRegisteredEmail);
                    DataTable checkingEmail = new DataTable();

                    SqlDataAdapter adapterPhone = new SqlDataAdapter(checkRegisteredPhone);
                    DataTable checkingPhone = new DataTable();

                    adapterEmail.Fill(checkingEmail);
                    adapterPhone.Fill(checkingPhone);
                    connect.Open();
                    int existEmail = checkRegisteredEmail.ExecuteNonQuery();
                    int existPhone = checkRegisteredPhone.ExecuteNonQuery();
                    connect.Close();
                    if (checkingEmail.Rows.Count > 0)
                    {
                        this.InvalidError.Text = "Email already Exist";
                        return false;
                    }
                    else if (checkingPhone.Rows.Count > 0)
                    {
                        this.InvalidError.Text = "Phone Number already Exist";
                        return false;
                    }
                    else
                    {
                        this.InvalidPanel.Visible = false;
                        return true;
                    }
                }
                else
                {
                    this.InvalidError.Text = "Password does not meet the requirement. At least 1 Upper and 1 Lower case, 1 Number, and 1 Special Character";
                    return false;
                }
            }
            else
            {
                this.InvalidPanel.Visible = true;
                this.InvalidError.Text = "The Password does not match.";
                return false;
            }


        }
    }
}