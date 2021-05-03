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
    public partial class CusEditProfile : System.Web.UI.Page
    {
        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ExpensiveDBConnectionString"].ConnectionString);
        int userID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userRole"] == null || Session["userRole"] == "Admin")
            {
                Response.Write("<script>alert('Are you lost?');</script>");
                Response.Redirect("Home.aspx");
            }

            if (!IsPostBack)
            {
                userID = Convert.ToInt32(Session["userID"]);

                SqlCommand CurrentUserCommand = new SqlCommand("SELECT* FROM Users WHERE userID =" + userID, connect);
                SqlDataAdapter CurrentUserAdapter = new SqlDataAdapter(CurrentUserCommand);
                DataTable CurrentUserDT = new DataTable();
                CurrentUserAdapter.Fill(CurrentUserDT);
                connect.Open();
                CurrentUserCommand.ExecuteNonQuery();
                connect.Close();

                foreach (DataRow row in CurrentUserDT.Rows)
                {
                    this.FullName.Text = row["userFullName"].ToString();
                    this.Email.Text = row["userEmail"].ToString();
                    this.Phone.Text = "0" + row["userContact"].ToString();
                    DateTime user_dob = DateTime.Parse(row["userDOB"].ToString());
                    this.DOB.Text = user_dob.ToString("yyyy-MM-dd");
                    this.Address.Text = row["userAddress"].ToString();
                    this.Password.Attributes.Add("Value", row["userPassword"].ToString());
                    this.ConfirmPassword.Attributes.Add("Value", row["userPassword"].ToString());
                }
            }
        }

        protected void EditProfileBtn_Click(object sender, EventArgs e)
        {
            string query = null;
            bool Validation = validationFunction(this.FullName.Text, this.Email.Text, this.Phone.Text, this.Password.Text, this.ConfirmPassword.Text, this.DOB.Text);
            userID = Convert.ToInt32(Session["userID"]);

            if (Validation == true)
            {
                query = "Update Users SET userFullName =@userFullName, userEmail =@userEmail , userContact =@userContact , userPassword =@userPassword, userAddress =@userAddress, userRole =@userRole, userDOB =@userDOB WHERE userID=@userID";
                SqlCommand UpdateProfileCommand = new SqlCommand(query, connect);
                UpdateProfileCommand.Parameters.AddWithValue("@userFullName", this.FullName.Text);
                UpdateProfileCommand.Parameters.AddWithValue("@userEmail", this.Email.Text);
                UpdateProfileCommand.Parameters.AddWithValue("@userContact", this.Phone.Text);
                UpdateProfileCommand.Parameters.AddWithValue("@userPassword", this.ConfirmPassword.Text);
                UpdateProfileCommand.Parameters.AddWithValue("@userAddress", this.Address.Text);
                UpdateProfileCommand.Parameters.AddWithValue("@userRole", Session["userRole"].ToString());
                UpdateProfileCommand.Parameters.AddWithValue("@userDOB", this.DOB.Text);
                UpdateProfileCommand.Parameters.AddWithValue("@userID", userID);

                Session["userFullName"] = this.FullName.Text;
                connect.Open();
                UpdateProfileCommand.ExecuteNonQuery();
                connect.Close();

                Response.Redirect("CusEditProfile.aspx");

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
                    if (Session["userEmail"].ToString() != Email)
                    {
                        if (checkingEmail.Rows.Count > 0)
                        {
                            this.InvalidError.Text = "Email already Exist";
                            return false;
                        }
                        this.InvalidPanel.Visible = false;
                        return true;
                    }
                    else if ("0" + Session["userPhone"] != PhoneNumber)
                    {
                        if (checkingPhone.Rows.Count > 0)
                        {
                            this.InvalidError.Text = "Phone Number already Exist";
                            return false;
                        }
                        this.InvalidPanel.Visible = false;
                        return true;
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