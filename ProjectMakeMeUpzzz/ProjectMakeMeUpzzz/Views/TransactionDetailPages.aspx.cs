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
    public partial class TransactionDetailPages : System.Web.UI.Page
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



                if (!IsPostBack)
                {
                    String id = Request["ID"];
                    LabelError.Text = id;
                    int transactionID = Convert.ToInt32(id);
                    Response<List<TransactionDetail>> response = TransactionDetailController.GetTransactionDetailByTransactionId(transactionID);

                    if (response.IsSuccess)
                    {
                        List<TransactionDetail> transactionDetails = response.Payload;
                        GridViewTransactionDetail.DataSource = transactionDetails;
                        GridViewTransactionDetail.DataBind();


                    }
                    else
                    {
                        
                    }

                }
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/TransactionHistory.aspx");
        }
    }
}