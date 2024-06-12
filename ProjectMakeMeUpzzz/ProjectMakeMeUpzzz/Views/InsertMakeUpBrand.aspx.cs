using ProjectMakeMeUpzzz.Controllers;
using ProjectMakeMeUpzzz.Handlers;
using ProjectMakeMeUpzzz.Helpers;
using ProjectMakeMeUpzzz.Models;
using ProjectMakeMeUpzzz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectMakeMeUpzzz.Views
{
    public partial class InsertMakeUpBrand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                User user = (User)Session["user"];
                if (user.UserRole != "admin")
                {
                    Response.Redirect("~/Views/Home.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Views/Home.aspx");
            }
        }

        protected void InsertMBrandBtn_Click(object sender, EventArgs e)
        {
            try
            {
                String MBrandName = InsertMBrandNameTB.Text.ToString();
                String MBrandRating = InsertMBrandRatingTB.Text.ToString();

                Response<MakeupBrand> response = MakeupBrandController.InsertMakeupBrand(MBrandName, MBrandRating);

                if (response.IsSuccess == true)
                {
                    Response.Redirect("~/Views/ManageMakeup.aspx");
                }

                InsertMBrandErrorLbl.Text = response.Message;
                InsertMBrandErrorLbl.Visible = true;
            }
            catch (Exception error)
            {
                InsertMBrandErrorLbl.Text = error.Message;
                InsertMBrandErrorLbl.Visible = true;
            }
        }

        protected void BacktoManageMakeUpBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageMakeup.aspx");
        }
    }
}