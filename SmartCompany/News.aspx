<%@ Page Title="" Language="C#" MasterPageFile="~/WebSite.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="SmartCompany.News" %>

<%@ Register src="View/Content/ContentList.ascx" tagname="ContentList" tagprefix="MukhtarWebUIControl" %>
<%@ Register src="View/Side/ServiceList.ascx" tagname="ServiceList" tagprefix="MukhtarWebUIControl" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="headWS" runat="server">
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentPlaceHolderWS" runat="server">

<section class="post">

<div class="content">
    <MukhtarWebUIControl:ContentList ID="mwcContentList" runat="server" />
</div>

<div class="side">
    <MukhtarWebUIControl:ServiceList ID="mwcServiceSideList" runat="server" />
</div>   
<div class="cl">&nbsp;</div>
	
</section>
   
</asp:Content>
