<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Smart/ManageSite.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SmartCompany.Admin.Smart.Default" %>

<%@ Register src="Components/Home/Statistic.ascx" tagname="Statistic" tagprefix="MukhtarWebUIControl" %>
<%@ Register src="Components/Home/Counter.ascx" tagname="Counter" tagprefix="MukhtarWebUIControl" %>

<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentPlaceHolderSiteManage" runat="server">
    
    <MukhtarWebUIControl:Statistic ID="mwwcStatistic" runat="server" />
    <MukhtarWebUIControl:Counter ID="mwcCounter" runat="server" />

</asp:Content>
