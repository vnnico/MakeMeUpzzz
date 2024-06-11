<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertMakeUp.aspx.cs" Inherits="ProjectMakeMeUpzzz.Views.InsertMakeUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
    <asp:Label ID="MNameLbl" runat="server" Text="Name"></asp:Label>
    <asp:TextBox ID="NameTxt" runat="server"></asp:TextBox>
</div>
<div>
    <asp:Label ID="MPriceLbl" runat="server" Text="Price"></asp:Label>
    <asp:TextBox ID="PriceTxt" runat="server" TextMode="Number"></asp:TextBox>
</div>
<div>
    <asp:Label ID="MWeightLbl" runat="server" Text="Weight"></asp:Label>
    <asp:TextBox ID="WeightTxt" runat="server" TextMode="Number"></asp:TextBox>
</div>
<div>
    <asp:Label ID="MTypeIDLbl" runat="server" Text="Type ID"></asp:Label>
    <asp:DropDownList ID="TypeIdDdl" runat="server"></asp:DropDownList>
</div>
<div>
    <asp:Label ID="MBrandIDLbl" runat="server" Text="Brand ID"></asp:Label>
    <asp:DropDownList ID="BrandIdDdl" runat="server"></asp:DropDownList>
</div>
<div>
    <asp:Label ID="ErrorLbl" runat="server" Text="[Error Label]" Visible="false"></asp:Label>
</div>
<div>
    <asp:Button ID="InsertButton" runat="server" Text="Insert" OnClick="InsertBtn_Click" />
</div>
        </div>
    </form>
</body>
</html>
