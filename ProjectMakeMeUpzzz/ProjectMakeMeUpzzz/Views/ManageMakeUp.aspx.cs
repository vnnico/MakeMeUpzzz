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
            List<Makeup> makeups = (from makeup in db.Makeups select makeup).ToList();
            InsertGrid.DataSource = makeups;
            InsertGrid.DataBind();

            List<MakeupBrand> makeupbrands = (from makeupbrand in db.MakeupBrands select makeupbrand).ToList();
            BrandGV.DataSource = makeupbrands;
            BrandGV.DataBind();

            List<MakeupType> makeups = (from makeupType in db.MakeupTypes select makeupType).ToList();
            GridType.DataSource = makeups;
            GridType.DataBind();
        }



        

        protected void InsertGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
           
           GridViewRow row = InsertGrid.Rows[e.NewEditIndex];
            string id = row.Cells[0].Text.ToString();
            Response.Redirect("~/Views/UpdateMakeUp.aspx/?ID=" + id);
        
        }

        protected void InsertGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = InsertGrid.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text.ToString());
           

            Response<Makeup> response = MakeupController.DeleteMakeup(id);
            if (response.IsSuccess)
            {
                Response<List<Makeup>> responses = MakeupController.GetAllMakeups();
                if (responses.IsSuccess)
                {
                    InsertGrid.DataSource = responses.Payload;
                    InsertGrid.DataBind();
                }
              
            }
        }

        protected void InsertGrid_SelectedIndexChanged(object sender, EventArgs e)
           



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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertMakeUp.aspx/");
        }

        protected void InsertMBrandLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertMakeUpBrand.aspx/");
        }

        protected void BrandGV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BrandGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = BrandGV.Rows[e.RowIndex];
            String id = row.Cells[0].Text.ToString();

            Response<MakeupBrand> response = MakeupBrandController.RemoveMakeupBrandById(id);
            if (response.IsSuccess)
            {
                Response<List<MakeupBrand>> responses = MakeupBrandController.GetAllMakeupBrands();
                if (responses.IsSuccess)
                {
                    BrandGV.DataSource = responses.Payload;
                    BrandGV.DataBind();
                }

            }
        }

        protected void BrandGV_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridViewRow row = BrandGV.Rows[e.NewEditIndex];
            string id = row.Cells[0].Text.ToString();
            Response.Redirect("~/Views/UpdateMakeUpBrand.aspx/?ID=" + id);
        }
    }
}