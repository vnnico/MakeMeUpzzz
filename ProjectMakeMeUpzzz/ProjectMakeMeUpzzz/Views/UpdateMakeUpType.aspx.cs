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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                User user = (User)Session["user"];
                if (user.UserRole != "admin")
                {

                }
            }
            else
            {

            }
            if (!Page.IsPostBack)
            {
                if (int.TryParse(Request.QueryString["id"], out int id))
                {
                    Response<MakeupType> response = MakeupTypeController.GetMakeupTypeById(id);

                    if (response.IsSuccess)
                    {
                        MakeupType makeupType = response.Payload;
                        if (makeupType != null)
                        {
                            txt_MakeUpTypeID.Text = makeupType.MakeupTypeID.ToString();
                            txt_MakeUpTypeName.Text = makeupType.MakeupTypeName;

                        }
                    }
                    else
                    {
                        lbl_Error.Text = response.Message;
                        lbl_Error.Visible = true;
                    }
                }
                else
                {
                    lbl_Error.Text = "Invalid ID";
                    lbl_Error.Visible = true;
                }
            }

        }

        protected void UpdateMakeUpTypeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                String id = Request.QueryString["Id"];
                String name = txt_MakeUpTypeName.Text.ToString();

                Response<MakeupType> response = MakeupTypeController.UpdateMakeupType(id, name);


                if (response.IsSuccess)
                {
                    Response.Redirect("~/Views/ManageMakeUp.aspx");
                }
                lbl_Error.Text = response.Message;
                lbl_Error.Visible = true;
            }
            catch (Exception ex)
            {
                lbl_Error.Text = ex.Message;
                lbl_Error.Visible = true;
            }
        }

        protected void gobackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageMakeUp.aspx");
        }
    }
}