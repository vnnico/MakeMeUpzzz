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
    public partial class OrderMakeUp : System.Web.UI.Page
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
                    Response<List<Makeup>> responses = MakeupController.GetAllMakeups();
                    if (responses.IsSuccess)
                    {
                        GridViewOrder.DataSource = responses.Payload;
                        GridViewOrder.DataBind();

                        Response<List<Cart>> cartResponse = CartController.GetCartByUserId(user.UserID);
                        if (cartResponse.IsSuccess)
                        {
                            GridViewCart.DataSource = cartResponse.Payload;
                            GridViewCart.DataBind();
                        }
                    }
                }
            }

        }
        protected void ButtonAddToCart_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow row = (GridViewRow)button.NamingContainer;
            int makeupID = Convert.ToInt32(button.CommandArgument);
            TextBox textBoxQuantity = (TextBox)row.FindControl("TextBoxQuantity");
            int quantity = Convert.ToInt32(textBoxQuantity.Text);

            

            Response<Cart> response = CartController.InsertCart(user.UserID, makeupID, quantity);
            if (response.IsSuccess)
            {
                Response<List<Cart>> newCart = CartController.GetCartByUserId(user.UserID);
                if (newCart.IsSuccess)
                {
                    GridViewCart.DataSource = newCart.Payload;
                    GridViewCart.DataBind();
                }
            }
        }

        protected void ButtonClearCart_Click(object sender, EventArgs e)
        {
            clearAllCarts();
        }

        protected void clearAllCarts()
        {
            User user = (User)Session["user"];
            List<int> cartIDs = new List<int>();
            Response<List<Cart>> carts = CartController.GetCartByUserId(user.UserID);
            if (carts.IsSuccess)
            {
                foreach (Cart cart in carts.Payload)
                {
                    cartIDs.Add(cart.CartID);
                }

                Response<List<Cart>> response = CartController.RemoveCartsById(cartIDs);
                if (response.IsSuccess)
                {
                    Response.Redirect("~/Views/OrderMakeUp.aspx");
                }
            }
        }

        protected void ButtonCheckout_Click(object sender, EventArgs e)
        {

            Response<List<Cart>> carts = CartController.GetCartByUserId(user.UserID);
            
            if (carts.IsSuccess)
            {
                LabelDebug.Text = Convert.ToString(carts.Payload);
                Response<TransactionHeader> response = TransactionHeaderController.CheckoutCart(carts.Payload);
                if (response.IsSuccess)
                {
                    clearAllCarts();
                }
            }
        }
    }
}