<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="InsertMakeUpType.aspx.cs" Inherits="ProjectMakeMeUpzzz.Views.InsertMakeUpType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>Insert Makeup Type</h1>
    <div>
        <asp:Label ID="lbl_Name" runat="server" Text="Name:"></asp:Label>
        <asp:TextBox ID="txt_Name" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lbl_Error" runat="server" Text="[Error Label]" Visible="false"></asp:Label>
    </div>
    <div>
        <asp:Button ID="submitMakeUpType" runat="server" Text="Submit" OnClick="submitMakeUpType_Click" />
    </div>
</asp:Content>
