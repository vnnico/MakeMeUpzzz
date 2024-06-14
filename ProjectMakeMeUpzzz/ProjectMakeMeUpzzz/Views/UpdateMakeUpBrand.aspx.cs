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
    public partial class UpdateMakeUpBrand : System.Web.UI.Page
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
                        Response<MakeupBrand> response = MakeupBrandController.GetMakeupBrandById(id);
                        if (response.IsSuccess)
                        {
                            MakeupBrand makeupbrand = response.Payload;
                            if (makeupbrand != null)
                            {
                                UpdateMBrandNameTB.Text = makeupbrand.MakeupBrandName;
                                UpdateMBrandRatingTB.Text = makeupbrand.MakeupBrandRating.ToString();

                            }
                        }
                        else
                        {
                            UpdateMBrandErrorLbl.Text = response.Message;
                        }
                    }
                    else
                    {
                        UpdateMBrandErrorLbl.Text = "Invalid ID.";
                    }
                }
            }

        }

        protected void UpdateMBrandBtn_Click(object sender, EventArgs e)
        {

            String MBrandName = UpdateMBrandNameTB.Text.ToString();
            String MBrandRating = UpdateMBrandRatingTB.Text.ToString();

            Response<MakeupBrand> response = MakeupBrandController.UpdateMakeupBrand(Request.QueryString["id"], MBrandName, MBrandRating);

            if (response.IsSuccess == true)
            {
                Response.Redirect("~/Views/ManageMakeup.aspx");
            }

            UpdateMBrandErrorLbl.Text = response.Message;


        }

        protected void BacktoManageMakeUpBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageMakeUp.aspx");
        }
    }
}