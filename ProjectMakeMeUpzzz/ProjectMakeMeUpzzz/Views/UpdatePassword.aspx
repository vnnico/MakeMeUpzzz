<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="UpdatePassword.aspx.cs" Inherits="ProjectMakeMeUpzzz.Views.UpdatePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>Change Password</h1>

    <div>
        <asp:Label ID="OldPasswordTxt" runat="server" Text="Old Password: "></asp:Label>
        <asp:TextBox ID="OldPassword" runat="server" TextMode="Password"></asp:TextBox>
    </div>

     <div>
     <asp:Label ID="NewPasswordtxt" runat="server" Text="New Password: "></asp:Label>
     <asp:TextBox ID="NewPassword" runat="server" TextMode="Password"></asp:TextBox>
 </div>

    <div>
            <asp:Button ID="UpdatePasswordBtn" runat="server" Text="UpdatePassword: " OnClick="UpdatePasswordBtn_Click" />

    </div>
    <asp:Label ID="errorlabel" runat="server" Text=""></asp:Label>
</asp:Content>
