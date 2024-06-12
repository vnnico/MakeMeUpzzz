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
    
    public partial class UpdatePassword : System.Web.UI.Page
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


            }

        }

        protected void UpdatePasswordBtn_Click(object sender, EventArgs e)
        {
            User user = (User)Session["user"];
            int id = user.UserID;
            String OldPasswords = OldPassword.Text;
            String NewPasswords = NewPassword.Text;
            Response<User> responses = UserController.UpdateUserPassword(id, OldPasswords, NewPasswords);
            {
                if (responses.IsSuccess)
                {
                    Response.Write("<script>alert(" + responses.Message + ");</script>");
                    Session["user"] = UserController.GetUserById(id).Payload;
                }
                else
                {
                    errorlabel.Visible = true;
                    errorlabel.Text = responses.Message;
                }
                Response.Redirect("~/Views/Login.aspx");
            }
        }
    }
}