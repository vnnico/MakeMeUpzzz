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
    public partial class UpdateMakeUpType : System.Web.UI.Page
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

                if (!Page.IsPostBack)
                {
                    if (int.TryParse(Request.QueryString["id"], out int id))
                    {
                        Response<MakeupType> response = MakeupTypeController.GetMakeupTypeById(id);

                        if (response.IsSuccess)
                        {
                            MakeupType makeupType = response.Payload;
                            txt_MakeUpTypeName.Text = makeupType.MakeupTypeName;
                        }
                        else
                        {
                            lbl_Error.Text = response.Message;
                        }
                    }
                    else
                    {
                        lbl_Error.Text = "Invalid ID";
                    }
                }
            }

        }

        protected void UpdateMakeUpTypeBtn_Click(object sender, EventArgs e)
        {

            String id = Request.QueryString["Id"];
            String name = txt_MakeUpTypeName.Text.ToString();

            Response<MakeupType> response = MakeupTypeController.UpdateMakeupType(id, name);


            if (response.IsSuccess)
            {
                Response.Redirect("~/Views/ManageMakeUp.aspx");
            }
            lbl_Error.Text = response.Message;

        }

        protected void gobackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageMakeUp.aspx");
        }
    }
}