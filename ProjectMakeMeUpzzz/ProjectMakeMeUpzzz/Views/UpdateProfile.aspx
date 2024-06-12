<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="ProjectMakeMeUpzzz.Views.UpdateProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">

    <h1>Update Profile</h1>
        <div>
        <asp:Label ID="LabelUsername" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="TextBoxUsername" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="LabelEmail" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="TextBoxEmail" runat="server" TextMode="Email"></asp:TextBox>
    </div>            
    
    <div>
        <asp:Label ID="LabelGender" runat="server" Text="Gender"></asp:Label>
        <asp:RadioButtonList ID="RadioButtonListGender" runat="server">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:RadioButtonList>
    </div>            

     <div>
        <asp:Label ID="LabelDOB" runat="server" Text="Date of Birth"></asp:Label>
        <asp:TextBox ID="TextBoxDOB" TextMode="Date" runat="server"></asp:TextBox>
    </div>
    
       

    <asp:Label ID="LabelError" runat="server" Text=""></asp:Label>

    <div>

    <asp:Button ID="ButtonUpdate" runat="server" Text="Update Profile" OnClick="ButtonUpdate_Click" />
    </div>
    <asp:Label ID="errorlabel" runat="server" Text=""></asp:Label>

 
   


</asp:Content>
