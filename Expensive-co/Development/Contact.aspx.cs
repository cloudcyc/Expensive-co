using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Expensive_co.Development
{
    public partial class Contact : System.Web.UI.Page
    {
        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ExpensiveDBConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userEmail"] != null)
            {
                this.name.Text = Session["userFullName"].ToString();
                this.email.Text = Session["userEmail"].ToString();
            }
        }
        protected void FeedbackBtn_Click(object sender, EventArgs e)
        {
            string currentRole = null;
            
            if (Session["userRole"] != null)
            {
                currentRole = Session["userRole"].ToString();
            }
            else
            {
                currentRole = null;
            }
           

            string message = null;
            if (currentRole == null || currentRole == "Member")
            {
                DateTime currentTime = DateTime.Now;
                SqlCommand AddFeedBackCommand = new SqlCommand("INSERT INTO Feedback (feedback, feedbackDate, respondentName, respondentEmail) VALUES (@feedback,@feedbackDate,@respondentName,@respondentEmail)", connect);
                AddFeedBackCommand.Parameters.AddWithValue("@feedback", this.Feedback.Text);
                AddFeedBackCommand.Parameters.AddWithValue("@feedbackDate", currentTime.ToString("yyyy-MM-dd hh:mm tt"));
                AddFeedBackCommand.Parameters.AddWithValue("@respondentName", this.name.Text);
                AddFeedBackCommand.Parameters.AddWithValue("@respondentEmail", this.email.Text);

                connect.Open();
                AddFeedBackCommand.ExecuteNonQuery();
                connect.Close();

                message = "<script>alert('Thank You for the feedback'" + this.name.Text + ");</script>";
            }
            else if(currentRole == "Admin")
            {
                
                message = "<script>alert('You're an Admin, you can not give a feedback.');</script>";
            }
            Response.Write(message);

        }
    }
}