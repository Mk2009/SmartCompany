<%@ Page Title="" Language="C#" MasterPageFile="~/WebSite.Master" AutoEventWireup="true" CodeBehind="Services.aspx.cs" Inherits="SmartCompany.Services" %>

<%@ Register src="View/Content/ContentList.ascx" tagname="ContentList" tagprefix="MukhtarWebUIControl" %>
<%@ Register src="View/Side/NewsList.ascx" tagname="NewsList" tagprefix="MukhtarWebUIControl" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="headWS" runat="server">
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentPlaceHolderWS" runat="server">

<section class="post">

<div class="content">
    <MukhtarWebUIControl:ContentList ID="mwcContentList" runat="server" />
</div>

<div class="side">
    <MukhtarWebUIControl:NewsList ID="mwcNewsList" runat="server" />
</div>   
<div class="cl">&nbsp;</div>
	
</section>
   
</asp:Content>
