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
    public partial class UpdateProfile : System.Web.UI.Page
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

                if (user != null)
                {
                    TextBoxUsername.Text = user.Username.ToString();
                    TextBoxEmail.Text = user.UserEmail.ToString();
                    RadioButtonListGender.SelectedValue = user.UserGender.ToString();
                    TextBoxDOB.Text = user.UserDOB.ToString();
                }
            }
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {

            User user = (User)Session["user"];
            int id = user.UserID;
            string username = TextBoxUsername.Text;
            string email = Convert.ToString(TextBoxEmail.Text);
            DateTime dob = DateTime.Parse(TextBoxDOB.Text);
            String gender = RadioButtonListGender.SelectedValue;
                


            Response<User> response = UserController.UpdateUserData(id, username, email, dob, gender);
            {
                if (response.IsSuccess)
                {
                    Response.Write("<script>alert(" + response.Message + ");</script>");
                    Session["user"] = UserController.GetUserById(id).Payload;
                }
                else
                {
                    errorlabel.Visible = true;
                    errorlabel.Text = response.Message;
                }

                Response.Redirect("~/Views/Login.aspx");


            }
        }
    }
}