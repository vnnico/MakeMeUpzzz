<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="ManageMakeUp.aspx.cs" Inherits="ProjectMakeMeUpzzz.Views.ManageMakeUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">

    <h1>Manage Makeup</h1>




























































    <asp:GridView ID="GridType" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridType_RowDeleting" OnRowEditing="GridType_RowEditing" OnSelectedIndexChanged="GridType_SelectedIndexChanged1">
        <Columns>
            <asp:BoundField DataField="MakeupTypeID" HeaderText="MakeupType ID"  SortExpression="MakeupTypeID" />
            <asp:BoundField DataField="MakeupTypeName" HeaderText="Makeup Type Name"  SortExpression="MakeupName" />
            <asp:CommandField ButtonType="Button" HeaderText="Action" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
           
        </Columns>
    </asp:GridView>
 
        <br/>
        </div>
</asp:Content>