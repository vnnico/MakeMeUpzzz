using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectMakeMeUpzzz.Controllers;
using ProjectMakeMeUpzzz.Helpers;
using ProjectMakeMeUpzzz.Models;

namespace ProjectMakeMeUpzzz.Views
{
    public partial class ManageMakeUp : System.Web.UI.Page
    {
        DatabaseEntities1 db = new DatabaseEntities1();
        protected void Page_Load(object sender, EventArgs e)

        {
            List<MakeupType> makeups = (from makeupType in db.MakeupTypes select makeupType).ToList();
            GridType.DataSource = makeups;
            GridType.DataBind();



        }

        protected void GridType_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridType.Rows[e.RowIndex];
            String id = row.Cells[0].Text.ToString();


            Response<MakeupType> response = MakeupTypeController.RemoveMakeupType(id);
            if (response.IsSuccess)
            {
                Response<List<MakeupType>> responses = MakeupTypeController.GetAllMakeupTypes();
                if (responses.IsSuccess)
                {
                    GridType.DataSource = responses.Payload;
                    GridType.DataBind();
                }

            }
        }

        protected void GridType_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = GridType.Rows[e.NewEditIndex];
            string id = row.Cells[0].Text.ToString();
            Response.Redirect("~/Views/UpdateMakeUpType.aspx/?Id=" + id);
        }

        protected void GridType_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}