<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="ManageMakeUp.aspx.cs" Inherits="ProjectMakeMeUpzzz.Views.ManageMakeUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">

    <h1>Manage Makeup</h1>

    <div>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Insert a Make Up</asp:LinkButton>
    </div>
    <div>
        <asp:LinkButton ID="InsertMBrandLink" runat="server" OnClick="InsertMBrandLink_Click">Insert a Make Up Brand</asp:LinkButton>
    </div>

    <div>

        <asp:GridView ID="InsertGrid" runat="server" AutoGenerateColumns="False" OnRowDeleting="InsertGrid_RowDeleting" OnRowEditing="InsertGrid_RowEditing" OnSelectedIndexChanged="InsertGrid_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="MakeupID" HeaderText="Makeup ID" SortExpression="MakeupID" />
                <asp:BoundField DataField="MakeupName" HeaderText="MakeupName" SortExpression="MakeupName" />
                <asp:BoundField DataField="MakeupPrice" HeaderText="Makeup Price" SortExpression="MakeupPrice" />
                <asp:BoundField DataField="MakeupWeight" HeaderText="Makeup Weight(Gram)" SortExpression="MakeupWeight" />
                <asp:BoundField DataField="MakeupTypeID" HeaderText="Makeup Type ID" SortExpression="MakeupTypeID" />
                <asp:BoundField DataField="MakeupBrandID" HeaderText="Makeup Brand ID" SortExpression="MakeupBrandID" />
            </Columns>
        </asp:GridView>

        <asp:GridView ID="GridType" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridType_RowDeleting" OnRowEditing="GridType_RowEditing" OnSelectedIndexChanged="GridType_SelectedIndexChanged1">
            <Columns>
                <asp:BoundField DataField="MakeupTypeID" HeaderText="MakeupType ID" SortExpression="MakeupTypeID" />
                <asp:BoundField DataField="MakeupTypeName" HeaderText="Makeup Type Name" SortExpression="MakeupName" />
                <asp:CommandField ButtonType="Button" HeaderText="Action" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>


        <asp:GridView ID="BrandGV" runat="server" AutoGenerateColumns="False" OnRowDeleting="BrandGV_RowDeleting" OnRowEditing="BrandGV_RowEditing" OnSelectedIndexChanged="BrandGV_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="MakeUpBrandId" HeaderText="Make Up Brand ID" SortExpression="MakeUpBrandId" />
                <asp:BoundField DataField="MakeUpBrandName" HeaderText="Make Up Brand Name" SortExpression="MakeUpBrandName" />
                <asp:BoundField DataField="MakeUpBrandRating" HeaderText="Make Up Brand Rating" SortExpression="MakeUpBrandRating" />
                <asp:CommandField ButtonType="Button" HeaderText="Action" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>

        <br />
    </div>
</asp:Content>

 
  
