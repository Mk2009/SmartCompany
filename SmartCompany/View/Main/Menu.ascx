<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="SmartCompany.View.Main.Menu" %>

<ul>
	<li id="liHome" runat="server" class="active"><asp:HyperLink ID="hlItem1" runat="server" NavigateUrl="~/Default.aspx" /></li>
	<li id="liBusiness" runat="server"><asp:HyperLink ID="hlItem2" runat="server" NavigateUrl="~/OurBusiness.aspx" /></li>
	<li id="liServices" runat="server"><asp:HyperLink ID="hlItem3" runat="server" NavigateUrl="~/Services.aspx" /></li>
	<li id="liNews" runat="server"><asp:HyperLink ID="hlItem4" runat="server" NavigateUrl="~/News.aspx" /></li>
	<li id="liAbout" runat="server"><asp:HyperLink ID="hlItem5" runat="server" NavigateUrl="~/About.aspx" /></li>
	<li id="liContact" runat="server"><asp:HyperLink ID="hlItem6" runat="server" NavigateUrl="~/ContactUs.aspx" /></li>
</ul>

<asp:Label ID="lbMsg" runat="server" Text="Xml data file does not exist!" ForeColor="Red" Visible="False" />
