<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeFile="InsertMakeUp.aspx.cs" Inherits="ProjectMakeMeUpzzz.Views.InsertMakeUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    
    <h1>Insert Make Up</h1>
    <div>
        <asp:Label ID="MNameLbl" runat="server" Text="Makeup Name: "></asp:Label>
    <asp:TextBox ID="NameTxt" runat="server"></asp:TextBox>
</div>
<div>
    <asp:Label ID="MPriceLbl" runat="server" Text="Price: "></asp:Label>
    <asp:TextBox ID="PriceTxt" runat="server" TextMode="Number"></asp:TextBox>
</div>
<div>
    <asp:Label ID="MWeightLbl" runat="server" Text="Weight (Max 1500): "></asp:Label>
    <asp:TextBox ID="WeightTxt" runat="server" TextMode="Number"></asp:TextBox>
</div>
<div>
    <asp:Label ID="MTypeIDLbl" runat="server" Text="Type ID: "></asp:Label>
    <asp:DropDownList ID="MakeUpTypeIdDdl" runat="server"></asp:DropDownList>
</div>
<div>
    <asp:Label ID="MBrandIDLbl" runat="server" Text="Brand ID: "></asp:Label>
    <asp:DropDownList ID="MakeUpBrandIdDdl" runat="server"></asp:DropDownList>
</div>
<div>
        <asp:Label ID="ErrorValidationLabel" runat="server" Text=""></asp:Label>
    </div>
<div>
    <asp:Button ID="backButton" runat="server" Text="Back" OnClick="backButton_Click" />
    <asp:Button ID="InsertButton" runat="server" Text="Insert" OnClick="InsertBtn_Click" />
</div>


</asp:Content>
