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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] != null || Request.Cookies["user_auth"] != null)
            {

                Response.Redirect("~/Views/Home.aspx");

            }


        }


        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            String username = TextBoxUsername.Text;
            String password = TextBoxPassword.Text;
            Boolean remember = CheckBox.Checked;

            Response<User> response = UserController.Login(username, password);
            if (response.IsSuccess)
            {
                User user = response.Payload;
                Session["user"] = user;

                if (remember)
                {
                    HttpCookie cookie = new HttpCookie("user_auth");
                    cookie.Value = user.UserID.ToString();
                    cookie.Expires = DateTime.Now.AddDays(3);
                    Response.Cookies.Add(cookie);
                }
                Response.Redirect("~/Views/Home.aspx");
            }

            LabelError.Text = response.Message;
        }

        protected void LinkButtonRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Register.aspx");
        }
    }
    }
