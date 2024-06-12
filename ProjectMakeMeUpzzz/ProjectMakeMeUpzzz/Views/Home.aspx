<%@ Page Title="Home" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="ProjectMakeMeUpzzz.Views.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>Home</h1>

    <h3>Welcome <%= user.Username %></h3>

    <% if (user.UserRole == "admin") {  %>
        <h5>Role : Admin</h5>
    <asp:GridView ID="GridViewCustomer" runat="server" ></asp:GridView>
    <%} %>
    
    

</asp:Content>
