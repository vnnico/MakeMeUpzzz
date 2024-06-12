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
    public partial class Home : System.Web.UI.Page
    {
        protected User user;
        protected void Page_Load(object sender, EventArgs e)
        {

            /*var master = (Master)this.Master;

            if (master != null)
            {
                user = master.GetUser();

                Response<List<User>> responses = UserController.GetAllUsers();
                if (responses.IsSuccess)
                {
                    GridViewCustomer.DataSource = responses.Payload;
                    GridViewCustomer.DataBind();
                }
            }*/

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

                Response<List<User>> responses = UserController.GetAllUsers();
                if (responses.IsSuccess)
                {
                    GridViewCustomer.DataSource = responses.Payload;
                    GridViewCustomer.DataBind();
                }
            }


        }


    }
}