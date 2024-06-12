using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectMakeMeUpzzz.Controllers;
using ProjectMakeMeUpzzz.Helpers;
using ProjectMakeMeUpzzz.Models;

namespace ProjectMakeMeUpzzz.Views
{
    public partial class Profile : System.Web.UI.Page
    {
        protected User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Request.Cookies["user_auth"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (Session["user"] == null)
                {
                    int id = Convert.ToInt32(Request.Cookies["user_auth"].Value);
                    Response<User> response = UserController.GetUserById(id);
                    user = response.Payload;
                    Session["user"] = user;
                }
                else
                {
                    user = (User)Session["user"];
                }

                if(!IsPostBack)
                {

                    UsernameID.Text = user.Username;
                    EmailID.Text = user.UserEmail;
                    DOBID.Text = user.UserDOB.ToString();
                    GenderID.Text = user.UserGender;


                }
                


            }


        }

        protected void UpdateProfileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/UpdateProfile.aspx");
        }

        protected void UpdatePassowrdBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/UpdatePassword.aspx");
        }
    }
}