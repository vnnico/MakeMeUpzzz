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
    public partial class UpdateMakeUp : System.Web.UI.Page
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
                    if (int.TryParse(Request.QueryString["id"], out int id))
                    {
                        Response<Makeup> response3 = MakeupController.GetMakeupById(id);
                        if (response3.IsSuccess)
                        {
                            Makeup makeup = response3.Payload;
                            if (makeup != null)
                            {
                                UNameTxt.Text = makeup.MakeupName;
                                PriceTxt.Text = makeup.MakeupPrice.ToString();
                                WeightTxt.Text = makeup.MakeupWeight.ToString();
                                MakeUpTypeIdDdl.SelectedValue = makeup.MakeupTypeID.ToString();
                                MakeUpBrandIdDdl.SelectedValue = makeup.MakeupBrandID.ToString();
                                ViewState["MakeupID"] = id;
                            }
                        }
                        else
                        {
                            ErrorValidationLabel.Text = response.Message;
                            ErrorValidationLabel.Visible = true;
                        }
                    }
                    else
                    {
                        ErrorValidationLabel.Text = "Invalid ID.";
                        ErrorValidationLabel.Visible = true;
                    }
                }
            }
        }



        protected void UpdateButton_Click(object sender, EventArgs e)
        {



            try
            {
                string id = Request.QueryString["Id"];
                string name = UNameTxt.Text;
                string price = PriceTxt.Text;
                string weight = WeightTxt.Text;
                string typeid = MakeUpTypeIdDdl.SelectedValue;
                string brandid = MakeUpBrandIdDdl.SelectedValue;

                Response<Makeup> response = MakeupController.Update(id, name, price, weight, typeid, brandid);
                if (response.IsSuccess)
                {
                    Response.Redirect("~/Views/ManageMakeUp.aspx");
                }

                ErrorValidationLabel.Text = response.Message;
                ErrorValidationLabel.Visible = true;
            }
            catch (Exception error)
            {
                ErrorValidationLabel.Text = error.Message;
                ErrorValidationLabel.Visible = true;

            }





        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageMakeUp.aspx");
        }
    }
}