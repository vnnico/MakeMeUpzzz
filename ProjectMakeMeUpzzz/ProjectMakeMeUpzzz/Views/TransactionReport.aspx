<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="TransactionReport.aspx.cs" Inherits="ProjectMakeMeUpzzz.Views.TransactionReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>Transaction Report</h1>
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
    
    <CR:CrystalReportViewer ID="CrystalReportViewer2" runat="server" AutoDataBind="true" />

</asp:Content>
    