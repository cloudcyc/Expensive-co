using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;

namespace Expensive_co.Development
{
    public partial class Register : System.Web.UI.Page
    {
        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ExpensiveDBConnectionString"].ConnectionString);


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {

            SqlCommand registerQuery = new SqlCommand("INSERT INTO Users (userFullName, userEmail, userContact, userPassword, userAddress, userRole, userDOB) VALUES (@userFullName,@userEmail,@userContact,@userPassword,@userAddress,@userRole,@userDOB)", connect);

            //bool Validation = validationFunction(this.FirstName.Text, this.Email.Text, this.Phone.Text, this.Password.Text, this.ConfirmPassword.Text, this.DOB.Text);
            bool Validation = GlobalFunction.validationFunction(this.FullName.Text, this.Email.Text, this.Phone.Text, this.Password.Text, this.ConfirmPassword.Text, this.DOB.Text, this.InvalidPanel, this.InvalidError);

            if (Validation == true)
            {
                registerQuery.Parameters.AddWithValue("@userFullName", this.FullName.Text);
                registerQuery.Parameters.AddWithValue("@userEmail", this.Email.Text);
                registerQuery.Parameters.AddWithValue("@userContact", this.Phone.Text);
                registerQuery.Parameters.AddWithValue("@userPassword", this.ConfirmPassword.Text);
                registerQuery.Parameters.AddWithValue("@userAddress", this.Address.Text);
                registerQuery.Parameters.AddWithValue("@userRole", "Member");
                registerQuery.Parameters.AddWithValue("@userDOB", this.DOB.Text);

                connect.Open();
                int result = registerQuery.ExecuteNonQuery();
                connect.Close();

                Response.Write("<script>alert('Register Successfully');</script>");
                Response.Redirect("Login.aspx");

            }
            else
            {
                Response.Write("<script>alert('"+ this.InvalidError.Text +"');</script>");
            }
 
        }

        /*public bool validationFunction(string Fullname, string Email, string PhoneNumber, string Password, string ConfirmPassword, string DOB)
        {
            Regex checkNum = new Regex(@"^\d+$"); //Only number
            Regex checkStrongPassword = new Regex(@"^.*(?=.{7,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9]).{6,20}$"); //Atleast 1 upper and lower, 1 number, and special character
            Regex checkEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"); //checking email can be xxx@mail.xxx.xx.xxx.my
            if (Password == ConfirmPassword)
            {
                if (Fullname != null && checkEmail.IsMatch(Email) && checkNum.IsMatch(PhoneNumber) && checkStrongPassword.IsMatch(Password) && checkStrongPassword.IsMatch(ConfirmPassword) && DOB !=null && Password == ConfirmPassword)
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
                        this.InvalidPanel.Visible = true;
                        this.InvalidError.Text = "Email already Exist";
                        return false;
                    }
                    else if (checkingPhone.Rows.Count > 0)
                    {
                        this.InvalidPanel.Visible = true;
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
                    this.InvalidPanel.Visible = true;
                    this.InvalidError.Text = "Did you meet the requirement?\n Phone Number only number\n Password need to be 6~20 character, least 1 Upper and 1 Lower case, 1 Number, and 1 Special Character";
                    return false;
                }
            }
            else
            {
                this.InvalidPanel.Visible = true;
                this.InvalidError.Text = "The Password does not match.";
                return false;
            }
            
            
        }*/

    }
}