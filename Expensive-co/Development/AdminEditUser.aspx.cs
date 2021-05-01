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
    public partial class AdminEditUser : System.Web.UI.Page
    {
        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ExpensiveDBConnectionString"].ConnectionString);
        int user_ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["userID"] == null)
            {
                Response.Redirect("AdminManageUser.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    user_ID = Convert.ToInt32(Request.QueryString["userID"]);
                    SqlCommand SelectedUserCommand = new SqlCommand("SELECT* FROM Users WHERE userID =" + user_ID, connect);
                    SqlDataAdapter SelectedUserAdapter = new SqlDataAdapter(SelectedUserCommand);
                    DataTable SelectedUserDT = new DataTable();
                    SelectedUserAdapter.Fill(SelectedUserDT);
                    connect.Open();
                    SelectedUserCommand.ExecuteNonQuery();
                    connect.Close();

                    foreach (DataRow row in SelectedUserDT.Rows)
                    {
                        this.FullName.Text = row["userFullName"].ToString();
                        this.Email.Text = row["userEmail"].ToString();
                        this.Phone.Text = "0" + row["userContact"].ToString();
                        DateTime user_dob = DateTime.Parse(row["userDOB"].ToString());
                        this.DOB.Text = user_dob.ToString("yyyy-MM-dd");
                        this.DropDownList1.Text = row["userRole"].ToString();
                        this.Address.Text = row["userAddress"].ToString();
                    }
                }
            }
        }

        protected void UpdateUserProfileBtn_Click(object sender, EventArgs e)
        {
            string query = null;
            bool Validation = validationFunction(this.FullName.Text, this.Email.Text, this.Phone.Text, this.DOB.Text);
            user_ID = Convert.ToInt32(Request.QueryString["userID"]);
            if (Validation == true)
            {
                query = "Update Users SET userFullName =@userFullName, userEmail =@userEmail , userContact =@userContact ,userAddress =@userAddress, userRole =@userRole, userDOB =@userDOB WHERE userID=@userID";
                SqlCommand UpdateUserProfileCommand = new SqlCommand(query, connect);
                UpdateUserProfileCommand.Parameters.AddWithValue("@userFullName", this.FullName.Text);
                UpdateUserProfileCommand.Parameters.AddWithValue("@userEmail", this.Email.Text);
                UpdateUserProfileCommand.Parameters.AddWithValue("@userContact", this.Phone.Text);
                UpdateUserProfileCommand.Parameters.AddWithValue("@userAddress", this.Address.Text);
                UpdateUserProfileCommand.Parameters.AddWithValue("@userRole", this.DropDownList1.Text);
                UpdateUserProfileCommand.Parameters.AddWithValue("@userDOB", this.DOB.Text);
                UpdateUserProfileCommand.Parameters.AddWithValue("@userID", user_ID);

                connect.Open();
                UpdateUserProfileCommand.ExecuteNonQuery();
                connect.Close();

                Response.Redirect("AdminManageUser.aspx");
            }
        }

        public bool validationFunction(string Fullname, string Email, string PhoneNumber, string DOB)
        {
            Regex checkNum = new Regex(@"^\d+$"); //Only number
            Regex checkEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"); //checking email can be xxx@mail.xxx.xx.xxx.my

            if (Fullname != null && checkEmail.IsMatch(Email) && checkNum.IsMatch(PhoneNumber) && DOB != null)
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
                return false;
                Response.Redirect("AdminManageUser.aspx");
            }
                
 
        }
    }
}