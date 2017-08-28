<%@ Page Title="" Language="C#" MasterPageFile="~/WebSite.Master" AutoEventWireup="true" CodeBehind="OurBusiness.aspx.cs" Inherits="SmartCompany.OurBusiness" %>

<%@ Register src="View/Content/BusinessList.ascx" tagname="BusinessList" tagprefix="MukhtarWebUIControl" %>
<%@ Register src="View/Side/ServiceList.ascx" tagname="ServiceList" tagprefix="MukhtarWebUIControl" %>


<asp:Content ID="ContentHead" ContentPlaceHolderID="headWS" runat="server">
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentPlaceHolderWS" runat="server">

<section class="post">

<div class="content">
    <MukhtarWebUIControl:BusinessList ID="mwcBusinessList" runat="server" />
</div>

<div class="side">
    <MukhtarWebUIControl:ServiceList ID="mwcServiceSideList" runat="server" />
</div>   
<div class="cl">&nbsp;</div>
	
</section>
   
</asp:Content>
