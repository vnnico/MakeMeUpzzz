<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="ProjectMakeMeUpzzz.Views.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
            
            <div>
                <asp:Label ID="LabelPassword" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>            
            
            <div>
                <asp:Label ID="LabelConfirmPassword" runat="server" Text="Confirm Password"></asp:Label>
                <asp:TextBox ID="TextBoxConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>        

            <asp:Label ID="LabelError" runat="server" Text="Error Label"></asp:Label>

            <div>

            <asp:Button ID="ButtonRegister" runat="server" Text="Sign Up" OnClick="ButtonRegister_Click" />
            </div>

        </div>
    </form>
</body>
</html>
