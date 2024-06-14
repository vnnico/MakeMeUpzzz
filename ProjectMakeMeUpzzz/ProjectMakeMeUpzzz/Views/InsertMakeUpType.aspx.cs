using ProjectMakeMeUpzzz.Controllers;
using ProjectMakeMeUpzzz.Helpers;
using ProjectMakeMeUpzzz.Models;
using ProjectMakeMeUpzzz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ProjectMakeMeUpzzz.Views
{
    public partial class InsertMakeUpType : System.Web.UI.Page
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


                if (user.UserRole != "admin")
                {


                    Response.Redirect("~/Views/Home.aspx");
                }

            }
        }

        protected void submitMakeUpType_Click(object sender, EventArgs e)
        {

            String typeName = txt_Name.Text;
            Response<MakeupType> response = MakeupTypeController.InsertMakeupType(typeName);
            if (response.IsSuccess)
            {
                Response.Redirect("~/Views/ManageMakeUp.aspx");
            }

            lbl_Error.Text = response.Message;

        }



        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageMakeUp.aspx");
        }
    }
}