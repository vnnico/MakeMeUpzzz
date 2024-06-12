<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="InsertMakeUpBrand.aspx.cs" Inherits="ProjectMakeMeUpzzz.Views.InsertMakeUpBrand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>Insert Make Up Brand</h1>
    <div>
        <asp:Label ID="InsertMBrandNameLbl" runat="server" Text="Make Up Brand Name"></asp:Label>
        <asp:TextBox ID="InsertMBrandNameTB" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="InsertMBrandRatingLbl" runat="server" Text="Make Up Brand Rating (0 - 100)"></asp:Label>
        <asp:TextBox ID="InsertMBrandRatingTB" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="InsertMBrandErrorLbl" runat="server" Text="Error Label" Visible="false" CssClass="error"></asp:Label>
    </div>
    <div>
        <asp:Button ID="InsertMBrandBtn" runat="server" Text="Insert" OnClick="InsertMBrandBtn_Click" />
    </div>
</asp:Content>
