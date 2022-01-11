using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace Expensive_co.Development
{
    public class GlobalFunction
    {
        
        private static SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ExpensiveDBConnectionString"].ConnectionString);

        
        public static bool validationFunction(string Fullname, string Email, string PhoneNumber, string Password, string ConfirmPassword, string DOB, Panel InvalidPanel, Label InvalidError)
        {
            Regex checkNum = new Regex(@"^\d+$"); //Only number
            Regex checkStrongPassword = new Regex(@"^.*(?=.{7,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9]).{6,20}$"); //Atleast 1 upper and lower, 1 number, and special character
            Regex checkEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"); //checking email can be xxx@mail.xxx.xx.xxx.my
            if (Password == ConfirmPassword)
            {
                if (Fullname != null && checkEmail.IsMatch(Email) && checkNum.IsMatch(PhoneNumber) && checkStrongPassword.IsMatch(Password) && checkStrongPassword.IsMatch(ConfirmPassword) && DOB != null && Password == ConfirmPassword)
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
                        InvalidPanel.Visible = true;
                        InvalidError.Text = "Email already Exist";
                        return false;
                    }
                    else if (checkingPhone.Rows.Count > 0)
                    {
                        InvalidPanel.Visible = true;
                        InvalidError.Text = "Phone Number already Exist";
                        return false;
                    }
                    else
                    {
                        InvalidPanel.Visible = false;
                        return true;
                    }
                }
                else
                {
                    InvalidPanel.Visible = true;
                    InvalidError.Text = "Did you meet the requirement?\n Phone Number only number\n Password need to be 6~20 character, least 1 Upper and 1 Lower case, 1 Number, and 1 Special Character";
                    return false;
                }
            }
            else
            {
                InvalidPanel.Visible = true;
                InvalidError.Text = "The Password does not match.";
                return false;
            }


        }
    }
}