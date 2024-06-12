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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                User user = (User)Session["user"];
                if (user.UserRole != "admin")
                {
                    //Response.Redirect("~/Views/Home.aspx");
                }
            }
            else
            {
                //Response.Redirect("~/Views/Home.aspx");
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
                            CurrentMBrandIDLbl.Text = makeupbrand.MakeupBrandID.ToString();
                        }
                    }
                    else
                    {
                        UpdateMBrandErrorLbl.Text = response.Message;
                        UpdateMBrandErrorLbl.Visible = true;
                    }
                }
                else
                {
                    UpdateMBrandErrorLbl.Text = "Invalid ID.";
                    UpdateMBrandErrorLbl.Visible = true;
                }
            }
        }

        protected void UpdateMBrandBtn_Click(object sender, EventArgs e)
        {
            try
            {
                String MBrandName = UpdateMBrandNameTB.Text.ToString();
                String MBrandRating = UpdateMBrandRatingTB.Text.ToString();

                Response<MakeupBrand> response = MakeupBrandController.UpdateMakeupBrand(Request.QueryString["id"], MBrandName, MBrandRating);

                if (response.IsSuccess == true)
                {
                    //Response.Redirect("~/Views/ManageMakeup.aspx");
                }

                UpdateMBrandErrorLbl.Text = response.Message;
                UpdateMBrandErrorLbl.Visible = true;
            }
            catch (Exception error)
            {
                UpdateMBrandErrorLbl.Text = error.Message;
                UpdateMBrandErrorLbl.Visible = true;
            }
        }

        protected void BacktoManageMakeUpBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageMakeUp.aspx");
        }
    }
}