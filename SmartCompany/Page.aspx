<%@ Page Title="" Language="C#" MasterPageFile="~/WebSite.Master" AutoEventWireup="true" CodeBehind="Page.aspx.cs" Inherits="SmartCompany.Page" %>

<%@ Register src="View/Side/NewsList.ascx" tagname="NewsList" tagprefix="MukhtarWebUIControl" %>
<%@ Register src="View/Side/ServiceList.ascx" tagname="ServiceList" tagprefix="MukhtarWebUIControl" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="headWS" runat="server">
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentPlaceHolderWS" runat="server">

<section class="post">

<div class="content">
    <asp:Panel ID="msgPanel" runat="server" CssClass="msg">
        <asp:Label ID="lbMsg" runat="server" />
    </asp:Panel>
    <asp:Panel ID="contentPanel" runat="server">
        <h2><asp:Label ID="lbTitle" runat="server" /></h2>
        <p><asp:Image ID="imgShow" runat="server" Width="200" Height="150" CssClass="alignleft" /></p>
        <p style="text-align:justify;"><asp:Label ID="lbDescription" runat="server" /></p> 
        <small><asp:Label ID="lbDate" runat="server" /></small>       
    </asp:Panel>
</div>

<div class="side">
    <MukhtarWebUIControl:NewsList ID="mwcNewsList" runat="server" Visible="False" />
    <MukhtarWebUIControl:ServiceList ID="mwcServiceSideList" runat="server" Visible="False" />
</div>   
<div class="cl">&nbsp;</div>
	
</section>
</asp:Content>
