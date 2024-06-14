<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="UpdateMakeUpType.aspx.cs" Inherits="ProjectMakeMeUpzzz.Views.UpdateMakeUpType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>Update Makeup Type</h1>
 
    <div>
        <asp:Label ID="lbl_MakeUpTypeName" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="txt_MakeUpTypeName" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lbl_Error" runat="server" Text="[Error Label]" Visible="false"></asp:Label>
    </div>
    <div>
        <asp:Button ID="gobackBtn" runat="server" Text="Back" OnClick="gobackBtn_Click" />
        <asp:Button ID="UpdateMakeUpTypeBtn" runat="server" Text="Update" OnClick="UpdateMakeUpTypeBtn_Click" />
    </div>

</asp:Content>
