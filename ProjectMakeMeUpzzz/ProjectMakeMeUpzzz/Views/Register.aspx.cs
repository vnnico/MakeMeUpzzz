using ProjectMakeMeUpzzz.Controllers;
using ProjectMakeMeUpzzz.Helpers;
using ProjectMakeMeUpzzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectMakeMeUpzzz.Views
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] != null || Request.Cookies["user_auth"] != null)
            {

                Response.Redirect("~/Views/Home.aspx");

            }

        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            String username = TextBoxUsername.Text;
            String email = TextBoxEmail.Text;
            String gender = RadioButtonListGender.SelectedValue;
            DateTime dobNew = DateTime.Parse(TextBoxDOB.Text);
            String password = TextBoxPassword.Text;
            String confirmPassword = TextBoxConfirmPassword.Text;

            


            Response<User> response = UserController.Register(username, email, dobNew, gender, password, confirmPassword);

            if (response.IsSuccess)
            {
                Session["user"] = response.Payload;
                Response.Redirect("~/Views/Home.aspx");
            }

            LabelError.Text = response.Message;
          

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}