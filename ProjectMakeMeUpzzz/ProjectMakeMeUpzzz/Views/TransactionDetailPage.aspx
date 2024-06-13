<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="ProjectMakeMeUpzzz.Views.TransactionDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>Transaction Detail</h1>
    <asp:Button ID="goBackToTransactionHistory" runat="server" Text="Back" OnClick="goBackToTransactionHistory_Click" />
    <asp:Label ID="lbl_error" runat="server" Text=""></asp:Label>
    <asp:GridView ID="gvTransactionDetail" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="TransactionDetailId" HeaderText="Transaction Detail ID" />
            <asp:BoundField DataField="TransactionId" HeaderText="Transaction ID" />
            <asp:BoundField DataField="MakeupId" HeaderText="Makeup ID" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
        </Columns>
    </asp:GridView>

</asp:Content>
