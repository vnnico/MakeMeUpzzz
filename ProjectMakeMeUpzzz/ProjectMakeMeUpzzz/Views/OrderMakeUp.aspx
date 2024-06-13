<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="OrderMakeUp.aspx.cs" Inherits="ProjectMakeMeUpzzz.Views.OrderMakeUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
        <h1>Order Make Up</h1>

<asp:Label ID="LabelDebug" runat="server" Text="Label"></asp:Label>

    <asp:GridView ID="GridViewOrder" runat="server" AutoGenerateColumns="False" >
        <Columns>
            <asp:BoundField DataField="MakeupID" HeaderText="MakeUp ID" SortExpression="MakeupID" />
            <asp:BoundField DataField="MakeupName" HeaderText="MakeUp Name" SortExpression="MakeupName" />
            <asp:BoundField DataField="MakeupPrice" HeaderText="Makeup Price" SortExpression="MakeupPrice" />
            <asp:BoundField DataField="MakeupWeight" HeaderText="Makeup Weight (in gram)" SortExpression="MakeupWeight" />
            <asp:BoundField DataField="MakeupType.MakeupTypeName" HeaderText="Makeup Type" SortExpression="MakeupType.MakeupTypeName" />
            <asp:BoundField DataField="MakeupBrand.MakeupBrandName" HeaderText="Makeup Brand" SortExpression="MakeupBrand.MakeupBrandName" />
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <div>
                        <asp:TextBox ID="TextBoxQuantity" runat="server" TextMode="Number"></asp:TextBox>
                        <asp:Button ID="ButtonAddToCart" runat="server" Text="Add to cart" CommandArgument='<%# Eval("MakeupID") %>' OnClick="ButtonAddToCart_Click" />
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <h5>Cart</h5>
    <asp:GridView ID="GridViewCart" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="CartID" HeaderText="Cart ID" SortExpression="CartID" />
            <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" />
            <asp:BoundField DataField="MakeupID" HeaderText="Makeup ID" SortExpression="MakeupID" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
        </Columns>
    </asp:GridView>

    <asp:Button ID="ButtonClearCart" runat="server" Text="Clear Cart" OnClick="ButtonClearCart_Click" />
    <asp:Button ID="ButtonCheckout" runat="server" Text="Check Out" OnClick="ButtonCheckout_Click" />

</asp:Content>
