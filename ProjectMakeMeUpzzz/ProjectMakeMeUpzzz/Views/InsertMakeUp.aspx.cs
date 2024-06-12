using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectMakeMeUpzzz.Controllers;
using ProjectMakeMeUpzzz.Helpers;
using ProjectMakeMeUpzzz.Models;

namespace ProjectMakeMeUpzzz.Views
{
    public partial class InsertMakeUp : System.Web.UI.Page
        
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Response<List<MakeupType>> response = MakeupTypeController.GetAllMakeupTypes();
                if (response.IsSuccess)
                {
                    MakeUpTypeIdDdl.DataSource = response.Payload;
                    MakeUpTypeIdDdl.DataValueField = "MakeupTypeID";
                    MakeUpTypeIdDdl.DataTextField = "MakeupTypeName";
                    MakeUpTypeIdDdl.DataBind();
                }
                Response<List<MakeupBrand>> response2 = MakeupBrandController.GetAllMakeupBrands();
                if (response2.IsSuccess)
                {
                    MakeUpBrandIdDdl.DataSource = response2.Payload;
                    MakeUpBrandIdDdl.DataValueField = "MakeupBrandID";
                    MakeUpBrandIdDdl.DataTextField = "MakeupBrandName";
                    MakeUpBrandIdDdl.DataBind();
                }
            }
        }
    

    

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
           
            
                string name = NameTxt.Text;
                string price = PriceTxt.Text;
                string weight = WeightTxt.Text;
                string typeid = MakeUpTypeIdDdl.SelectedValue;
                string brandid = MakeUpBrandIdDdl.SelectedValue;

                Response<Makeup> response = MakeupController.InsertMakeup(name, price, weight, typeid, brandid);
                if (response.IsSuccess)
                {
                    Response.Redirect("~/Views/ManageMakeUp.aspx");
                }

                ErrorValidationLabel.Text = "Weight is Overcappacity";
                ErrorValidationLabel.Visible = true;
            
             
            
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageMakeUp.aspx");
        }
    }
}
