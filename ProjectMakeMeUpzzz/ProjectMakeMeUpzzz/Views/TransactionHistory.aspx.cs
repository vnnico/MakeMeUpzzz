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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTransactionData();
            }
        }

        private void BindTransactionData()
        {
            var user = (User)Session["User"];
            int userId = user.UserID;
            string userRole = user.UserRole;

            Response<List<TransactionHeader>> Responses = null;
            if (userRole == "admin")
            {
                Responses = TransactionHeaderController.GetAllTransactionHeaders();
            }
            else if (userRole == "user")
            {
                Responses = TransactionHeaderController.GetTransactionHeaderByUserId(userId);
            }
            if(Responses != null)
            {
            gvTransactionsHistory.DataSource = Responses.Payload;
            gvTransactionsHistory.DataBind();
            }else if(Responses == null)
            {
                lbl_error.Text = "No Data Available";
                lbl_error.Visible = true;
            }
        }
        protected void gvTransactionsHistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetail")
            {
                string transactionId = e.CommandArgument.ToString();
                Response.Redirect($"TransactionDetail.aspx?transactionId={transactionId}");
            }
        }
    }
}