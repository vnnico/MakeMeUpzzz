<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="UpdateMakeUpBrand.aspx.cs" Inherits="ProjectMakeMeUpzzz.Views.UpdateMakeUpBrand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>Update Make Up Brand</h1>
    Make Up Brand ID:
    <asp:Label ID="CurrentMBrandIDLbl" runat="server"></asp:Label>
    <div>
        <asp:Label ID="UpdateMBrandNameLbl" runat="server" Text="Make Up Brand Name"></asp:Label>
        <asp:TextBox ID="UpdateMBrandNameTB" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="UpdateMBrandRatingLbl" runat="server" Text="Make Up Brand Rating (0 - 100)"></asp:Label>
        <asp:TextBox ID="UpdateMBrandRatingTB" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="UpdateMBrandErrorLbl" runat="server" Text="Error Label" Visible="false" CssClass="error"></asp:Label>
    </div>
    <div>
        <asp:Button ID="BacktoManageMakeUpBtn" runat="server" Text="Back" OnClick="BacktoManageMakeUpBtn_Click" />
        <asp:Button ID="UpdateMBrandBtn" runat="server" Text="Update" OnClick="UpdateMBrandBtn_Click" />
    </div>
</asp:Content>
