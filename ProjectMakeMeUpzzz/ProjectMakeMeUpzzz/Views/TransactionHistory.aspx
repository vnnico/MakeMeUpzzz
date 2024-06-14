<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="ProjectMakeMeUpzzz.Views.TransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">

    <h1>Transaction History</h1>
    <asp:Label ID="lbl_error" runat="server" Text="" Visible="false"></asp:Label>
    <asp:GridView ID="GridViewTransactionHistory" runat="server" AutoGenerateColumns="False"  OnSelectedIndexChanged="gvTransactionsHs_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
                <asp:BoundField DataField="UserID" HeaderText="User ID" />
                <asp:BoundField DataField="TransactionDate" HeaderText="Date" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:CommandField ButtonType="Button" HeaderText="View Detail Transaction" ShowHeader="True" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
</asp:Content>
