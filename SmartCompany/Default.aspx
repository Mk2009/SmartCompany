<%@ Page Title="" Language="C#" MasterPageFile="~/WebSite.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="SmartCompany.Default" %>

<%@ Register Src="View/Main/Category.ascx" TagName="Category" TagPrefix="MukhtarWebUIControl" %>

<%@ Register src="View/Content/GoogleMap.ascx" tagname="GoogleMap" tagprefix="MukhtarWebUIControl" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="headWS" runat="server">
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentPlaceHolderWS" runat="server">
<!--Category area-->
<section class="cols">
    <MukhtarWebUIControl:Category ID="mwcCategory" runat="server" />
</section>

<section class="post">					

<div class="map-holder">
    <MukhtarWebUIControl:GoogleMap ID="mwcGoogleMap" runat="server" />
</div>

<div class="post-cnt">
	<h2><asp:Label ID="lbMainTitle" runat="server" Text="Our Company" /></h2>

	<p>
        <strong><asp:Label ID="lbTitle" runat="server" /></strong>
        <asp:Label ID="lbInformation" runat="server" />
    </p>
</div>

<div class="cl">&nbsp;</div>
</section>

<section class="testimonial">
	<h2><asp:Label ID="lbVisionTitle" runat="server" Text="Our Vision" /></h2>
    <p><asp:Label ID="lbVision" runat="server" /></p>
    <asp:TextBox ID="TextBox1" runat="server" Width="260px"></asp:TextBox>
</section>
<section class="testimonial">
	<h2><asp:Label ID="lbMissionTitle" runat="server" Text="Our Mission" /></h2>
    <p><asp:Label ID="lbMission" runat="server" /></p>
</section>
</asp:Content>
