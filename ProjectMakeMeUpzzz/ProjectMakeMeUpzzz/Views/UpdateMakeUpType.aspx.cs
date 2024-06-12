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
            //{
            //    User user = (User)Session["user"];
            //    if (user.UserRole != "admin")
            //    {
            //        Response.Redirect("~/Views/Home.aspx");
            //    }
            //    if (!Page.IsPostBack)
            //    {
                    Response<MakeupType> response = MakeupTypeController.GetMakeupTypeById(Convert.ToInt32(Request.QueryString["Id"]));
                    if (response.IsSuccess)
                    {
                        MakeupType makeupType = response.Payload;
                        txt_MakeUpTypeID.Text = makeupType.MakeupTypeID.ToString();
                        txt_MakeUpTypeName.Text = makeupType.MakeupTypeName;
                    }
                    else
                    {
                        Response.Write(response.Message);
                    }
            //    }
            //}
            //else
            //{
            //    Response.Redirect("~/Views/Home.aspx");
            //}
        }

        protected void UpdateMakeUpTypeBtn_Click(object sender, EventArgs e)
        {
            string id = txt_MakeUpTypeID.Text;
            string name = txt_MakeUpTypeName.Text;

            Response<MakeupType> response = MakeupTypeController.UpdateMakeupType(id, name);

            // sengaja komen dulu soalnya ga bisa save database nya
            //if (response.IsSuccess)
            //{
            //    Response.Redirect("~/Views/ManageMakeUp.aspx");
            //}
            lbl_Error.Text = response.Message;
            lbl_Error.Visible = true;
        }

    }
}