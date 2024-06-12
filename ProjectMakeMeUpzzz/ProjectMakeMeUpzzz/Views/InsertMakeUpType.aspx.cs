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
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["user"] == null)
            //{
            //    Response.Redirect("~/Views/Home.aspx");
            //}
        }

        protected void submitMakeUpType_Click(object sender, EventArgs e)
        {
            try
            {
                String typeName = txt_Name.Text;
                Response<MakeupType> response = MakeupTypeController.InsertMakeupType(typeName);
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
    }
}