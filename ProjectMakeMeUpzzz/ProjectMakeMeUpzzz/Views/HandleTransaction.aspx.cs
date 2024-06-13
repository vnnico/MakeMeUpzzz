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
    public partial class HandleTransaction : System.Web.UI.Page
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

                if (!IsPostBack)
                {
                    Response<List<TransactionHeader>> responses = TransactionHeaderController.GetAllTransactionHeaders();
                    if (responses.IsSuccess)
                    {
                        GridViewHandleTransaction.DataSource = responses.Payload;
                        GridViewHandleTransaction.DataBind();
                    }
                }
            }
        }


        protected void GridViewHandleTransaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridViewHandleTransaction.SelectedRow;
            int id = Convert.ToInt32(row.Cells[0].Text);
            Response<TransactionHeader> responseTransaction = TransactionHeaderController.GetTransactionHeaderById(id);
            if (responseTransaction.IsSuccess)
            {

                Response<TransactionHeader> response = TransactionHeaderController.UpdateTransactionHeaderStatus(responseTransaction.Payload);
                if (response.IsSuccess)
                {

                    Response<List<TransactionHeader>> newTransactionHeaders = TransactionHeaderController.GetAllTransactionHeaders();
                    if (newTransactionHeaders.IsSuccess)
                    {
                        GridViewHandleTransaction.DataSource = newTransactionHeaders.Payload;
                        GridViewHandleTransaction.DataBind();
                    }

                }
            }

        }
    }
}