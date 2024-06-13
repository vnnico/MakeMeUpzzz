<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeFile="UpdateMakeUp.aspx.cs" Inherits="ProjectMakeMeUpzzz.Views.UpdateMakeUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
        <h1>Update Make Up</h1>
    <div>
        <asp:Label ID="MNameLbl" runat="server" Text="Makeup Name: "></asp:Label>
    <asp:TextBox ID="UNameTxt" runat="server"></asp:TextBox>
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
    <asp:DropDownList ID="MakeUpTypeIdDdl" runat="server"></asp:DropDownList>
</div>
<div>
    <asp:Label ID="MBrandIDLbl" runat="server" Text="Brand ID"></asp:Label>
    <asp:DropDownList ID="MakeUpBrandIdDdl" runat="server"></asp:DropDownList>
</div>
<div>
        <asp:Label ID="ErrorValidationLabel" runat="server" Text=""></asp:Label>
    </div>
<div>
    <asp:Button ID="Button1" runat="server" Text="Back" OnClick="Button1_Click" />
    <asp:Button ID="UpdateButton" runat="server" Text="Update" OnClick="UpdateButton_Click" />
</div>

</asp:Content>
