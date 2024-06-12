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
    public partial class Master : System.Web.UI.MasterPage
    {

        protected User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            if (Session["user"] == null && Request.Cookies["user_auth"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (Request.Cookies["user_auth"] != null)
            {
                int id = Convert.ToInt32(Request.Cookies["user_auth"].Value);
                Response<User> response = UserController.GetUserById(id);

                if (response.IsSuccess)
                {

                    user = response.Payload;
                    Session["user"] = user;

                }
                else
                {
                    Response.Redirect("~/Views/Login.aspx");
                }


            } */

            if (Session["user"] == null && Request.Cookies["user_auth"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
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

        public User GetUser()
        {
            return user;
        }

        protected void ButtonHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Home.aspx");
        }

        protected void ButtonManageMakeUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageMakeUp.aspx");
        }

        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            String[] cookies = Request.Cookies.AllKeys;
            foreach (String cookie in cookies)
            {
                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }

            Session.Remove("user");
            Response.Redirect("~/Views/Login.aspx");
        }

        protected void ButtonProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Profile.aspx/");
        }

        protected void ButtonProfileCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Profile.aspx/");
        }
    }
}