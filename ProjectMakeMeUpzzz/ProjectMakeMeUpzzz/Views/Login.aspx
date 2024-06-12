<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProjectMakeMeUpzzz.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <h1>Login</h1>
            <div>
                <asp:Label ID="LabelUsername" runat="server" Text="Username"></asp:Label>
                <asp:TextBox ID="TextBoxUsername" runat="server"></asp:TextBox>
            </div>            
            
            <div>
                <asp:Label ID="LabelPassword" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>

            <asp:CheckBox ID="CheckBox" runat="server" />

            <asp:Label ID="LabelError" runat="server" Text=""></asp:Label>
            <asp:Button ID="ButtonLogin" runat="server" Text="Login" OnClick="ButtonLogin_Click" />

            <div>
                <asp:Label ID="LabelRegister" runat="server" Text="Don't have an account?"></asp:Label>
                <asp:LinkButton ID="LinkButtonRegister" runat="server" OnClick="LinkButtonRegister_Click">Sign Up Here</asp:LinkButton>
            </div>
        </div>
    </form>
</body>
</html>
