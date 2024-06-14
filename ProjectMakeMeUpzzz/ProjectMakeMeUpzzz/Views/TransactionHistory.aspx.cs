using ProjectMakeMeUpzzz.Controllers;
using ProjectMakeMeUpzzz.Handlers;
using ProjectMakeMeUpzzz.Helpers;
using ProjectMakeMeUpzzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Util;

namespace ProjectMakeMeUpzzz.Views
{
    public partial class TransactionHistory : System.Web.UI.Page
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


                if (user.UserRole == "admin")
                {

                    if(!IsPostBack)
                    {
                        Response<List<TransactionHeader>> transactions = TransactionHeaderController.GetAllTransactionHeaders();
                        if (transactions.IsSuccess)
                        {
                            GridViewTransactionHistory.DataSource = transactions.Payload;
                            GridViewTransactionHistory.DataBind();
                        }
                    }
                }
                else
                {
                    if (!IsPostBack)
                    {
                        Response<List<TransactionHeader>> transactions = TransactionHeaderController.GetTransactionHeaderByUserId(user.UserID);
                        if (transactions.IsSuccess)
                        {
                            GridViewTransactionHistory.DataSource = transactions.Payload;
                            GridViewTransactionHistory.DataBind();
                        }
                    }
                }
            }
        }

        protected void gvTransactionsHs_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridViewTransactionHistory.SelectedRow;
            String id = row.Cells[0].Text.ToString();
            Response.Redirect("~/Views/TransactionDetailPages.aspx?ID=" + id);
        }
    }
}