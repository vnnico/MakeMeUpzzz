<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="ProjectMakeMeUpzzz.Views.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">

    <h1>User Profile</h1>
    <div>
        <asp:Label ID="Username" runat="server" Text="Username: "></asp:Label>
        <asp:Label ID="UsernameID" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label ID="Email" runat="server" Text="Email: "></asp:Label>
        <asp:Label ID="EmailID" runat="server" Text=""></asp:Label>
    </div>

    <div>
        <asp:Label ID="DOB" runat="server" Text="DOB: "></asp:Label>
        <asp:Label ID="DOBID" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label ID="Gender" runat="server" Text="Gender: "></asp:Label>
        <asp:Label ID="GenderID" runat="server" Text=""></asp:Label>
    </div>

    <div>
        <asp:Button ID="UpdateProfileBtn" runat="server" Text="Update Profile" OnClick="UpdateProfileBtn_Click" />
        <asp:Button ID="UpdatePassowrdBtn" runat="server" Text="Update Password" OnClick="UpdatePassowrdBtn_Click" />
    </div>
</asp:Content>
