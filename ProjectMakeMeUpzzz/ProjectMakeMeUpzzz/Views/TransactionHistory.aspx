<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="ProjectMakeMeUpzzz.Views.TransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">

    <h1>Transaction</h1>
    <h1>History</h1>
    <asp:Label ID="lbl_error" runat="server" Text="" Visible="false"></asp:Label>
    <asp:GridView ID="gvTransactionsHs" runat="server" AutoGenerateColumns="False" OnRowCommand="gvTransactionsHs_RowCommand">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
                <asp:BoundField DataField="UserID" HeaderText="User ID" />
                <asp:BoundField DataField="TransactionDate" HeaderText="Date" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:TemplateField  HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="btnViewDetail" runat="server" CommandName="ViewDetail" CommandArgument='<%# Eval("TransactionID") %>' Text="View Detail" />

                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
</asp:Content>
