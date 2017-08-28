<%@ Page Title="" Language="C#" MasterPageFile="~/WebSite.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="SmartCompany.About" %>

<%@ Register src="View/Content/StackholderList.ascx" tagname="StackholderList" tagprefix="MukhtarWebUIControl" %>
<%@ Register src="View/Content/AlbumBox.ascx" tagname="AlbumBox" tagprefix="MukhtarWebUIControl" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="headWS" runat="server">

<link href="App_Themes/Default/album.css" rel="stylesheet" type="text/css" />
<script type='text/javascript' src='Script/album/jquery.min.js'></script>
<!--[if !IE]><!--><script type='text/javascript' src='Script/album/jquery.mobile-1.0rc2.customized.min.js'></script><!--<![endif]-->
<script type='text/javascript' src='Script/album/jquery.easing.1.3.js'></script> 
<script type='text/javascript' src='Script/album/jquery.hoverIntent.minified.js'></script> 
<script type='text/javascript' src='Script/album/diapo.js'></script> 

<script>
    $(function () {
        $('.pix_diapo').diapo();
    });

</script>
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentPlaceHolderWS" runat="server">

<section class="post">
    <div class="post-cnt">
	    <h2><asp:Label ID="lbMainTitle" runat="server" Text="Who Are We" /></h2>

	    <p><asp:Label ID="lbWhoAreWe" runat="server" /></p>
        <p><asp:Label ID="lbManager" runat="server" /></p>
        <p>
            <MukhtarWebUIControl:StackholderList ID="mwcStackholderList" runat="server" />
        </p>
    </div>
    <div class="map-holder">
        <MukhtarWebUIControl:AlbumBox ID="AlbumBox1" runat="server" Visible="false" />
    </div>
    <div class="cl">&nbsp;</div>
</section>

<section class="testimonial">
	<h2><asp:Label ID="lbProfileTitle" runat="server" Text="Our Profile" /></h2>
    <p><asp:Label ID="lbProfile" runat="server" /></p>
</section>

</asp:Content>