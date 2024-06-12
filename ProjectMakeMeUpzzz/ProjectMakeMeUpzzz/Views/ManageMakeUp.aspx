<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="ManageMakeUp.aspx.cs" Inherits="ProjectMakeMeUpzzz.Views.ManageMakeUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">

    <h1>Manage Makeup</h1>
    <div>    
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton>
</div>
    <div>

    <asp:GridView ID="InsertGrid" runat="server" AutoGenerateColumns="False" OnRowDeleting="InsertGrid_RowDeleting" OnRowEditing="InsertGrid_RowEditing" OnSelectedIndexChanged="InsertGrid_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="MakeupID" HeaderText="Makeup ID"  SortExpression="MakeupID" />
            <asp:BoundField DataField="MakeupName" HeaderText="MakeupName"  SortExpression="MakeupName" />
            <asp:BoundField DataField="MakeupPrice" HeaderText="Makeup Price"  SortExpression="MakeupPrice" />
             <asp:BoundField DataField="MakeupWeight" HeaderText="Makeup Weight(Gram)"  SortExpression="MakeupWeight" />
            <asp:BoundField DataField="MakeupTypeID" HeaderText="Makeup Type ID"  SortExpression="MakeupTypeID" />
            <asp:BoundField DataField="MakeupBrandID" HeaderText="Makeup Brand ID"  SortExpression="MakeupBrandID" />
            <asp:CommandField ButtonType="Button" HeaderText="Action" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
           
        </Columns>
    </asp:GridView>
 
        <br/>
        </div>
</asp:Content>
