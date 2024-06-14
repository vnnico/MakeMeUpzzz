<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="TransactionDetailPages.aspx.cs" Inherits="ProjectMakeMeUpzzz.Views.TransactionDetailPages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">

    <h1>Transaction Detail</h1>
    <asp:Button ID="ButtonBack" runat="server" Text="Button" OnClick="ButtonBack_Click" />
    <asp:Label ID="LabelError" runat="server" Text="Label"></asp:Label>
    <asp:GridView ID="GridViewTransactionDetail" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
            <asp:BoundField DataField="MakeupID" HeaderText="Makeup ID" SortExpression="MakeupID" />
            <asp:BoundField DataField="Makeup.MakeupName" HeaderText="Makeup Name" SortExpression="Makeup.MakeupName" />
            <asp:BoundField DataField="Makeup.MakeupPrice" HeaderText="Makeup Price" SortExpression="Makeup.MakeupPrice" />
            <asp:BoundField DataField="Makeup.MakeupWeight" HeaderText="Makeup Weight" SortExpression="Makeup.MakeupWeight" />
            <asp:BoundField DataField="Makeup.MakeupType.MakeupTypeName" HeaderText="Makeup Type" SortExpression="Makeup.MakeupType.MakeupTypeName" />
            <asp:BoundField DataField="Makeup.MakeupBrand.MakeupBrandName" HeaderText="Makeup Brand" SortExpression="Makeup.MakeupBrand.MakeupBrandName" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
        </Columns>
       
    </asp:GridView>
</asp:Content>
