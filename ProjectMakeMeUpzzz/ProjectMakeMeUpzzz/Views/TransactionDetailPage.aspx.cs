using ProjectMakeMeUpzzz.Controllers;
using ProjectMakeMeUpzzz.Helpers;
using ProjectMakeMeUpzzz.Models;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Util;

namespace ProjectMakeMeUpzzz.Views
{
    public partial class TransactionDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindTransactionDetailData();
            }
        }

        private void BindTransactionDetailData()
        {
            var user = (ProjectMakeMeUpzzz.Models.User)Session["User"];
            int userId = user.UserID;
            string userRole = user.UserRole;
            string transactionId = Request.QueryString["transactionId"];
            int transactionIdInt = int.Parse(transactionId);

            Response<List<ProjectMakeMeUpzzz.Models.TransactionDetail>> Responses = null;
            if (userRole == "admin")
            {
                Responses = TransactionDetailController.GetTransactionDetailById(transactionIdInt);

            }
            else if (userRole == "user")
            {
                Responses = TransactionDetailController.GetTransactionDetailById(transactionIdInt);
        
            }
            if (Responses != null)
            {
                gvTransactionDetail.DataSource = Responses.Payload;
                gvTransactionDetail.DataBind();
            }
            else if (Responses == null)
            {
                lbl_error.Text = "No Data Available";
                lbl_error.Visible = true;

            }
        }

        protected void goBackToTransactionHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/TransactionHistory.aspx");
        }
    }
}