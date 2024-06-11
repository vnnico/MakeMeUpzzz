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
            if (Session["user"] != null)
            {
                User user = (User)Session["user"];
                if (user.UserRole != "admin")
                {
                    Response.Redirect("~/Views/Home.aspx");
                }
                if (!Page.IsPostBack)
                {
                    Response<List<MakeupType>> response = MakeupTypeController.GetAllMakeupTypes();
                    if (response.IsSuccess)
                    {
                        TypeIdDdl.DataSource = response.Payload;
                        TypeIdDdl.DataValueField = "MakeupTypeID";
                        TypeIdDdl.DataTextField = "MakeupTypeName";
                        TypeIdDdl.DataBind();
                    }
                    Response<List<MakeupBrand>> response2 = MakeupBrandController.GetAllMakeupBrands();
                    if (response2.IsSuccess)
                    {
                        BrandIdDdl.DataSource = response2.Payload;
                        BrandIdDdl.DataValueField = "MakeupBrandID";
                        BrandIdDdl.DataTextField = "MakeupBrandName";
                        BrandIdDdl.DataBind();
                    }
                }
            }
            else
            {
                Response.Redirect("~/Views/Home.aspx");
            }
        }

    

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string name = NameTxt.Text;
                string price = PriceTxt.Text;
                string weight = WeightTxt.Text;
                string typeid = TypeIdDdl.SelectedValue;
                string brandid = BrandIdDdl.SelectedValue;

                Response<Makeup> response = MakeupController.InsertMakeup(name, price, weight, typeid, brandid);
                if (response.IsSuccess)
                {
                    Response.Redirect("~/Views/ManageMakeup.aspx");
                }

                ErrorLbl.Text = response.Message;
                ErrorLbl.Visible = true;
            }
            catch (Exception error)
            {
                ErrorLbl.Text = error.Message;
                ErrorLbl.Visible = true;
            }
        }
    }
}