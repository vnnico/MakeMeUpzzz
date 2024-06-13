<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="HandleTransaction.aspx.cs" Inherits="ProjectMakeMeUpzzz.Views.HandleTransaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">

    <h1>Handle Transaction</h1>
    <asp:GridView ID="GridViewHandleTransaction" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewHandleTransaction_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
            <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" />
            <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            <asp:CommandField ButtonType="Button" HeaderText="Handle Transaction" ShowHeader="True" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>


</asp:Content>
