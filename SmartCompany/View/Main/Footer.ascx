<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="SmartCompany.View.Main.Footer" %>


<%@ Register src="Menu.ascx" tagname="Menu" tagprefix="MukhtarWebUIControl" %>


<div class="footer-bottom">
	<nav class="footer-nav">
        <MukhtarWebUIControl:Menu ID="mwcMenu" runat="server" />
	</nav>
	<p class="copy">&copy;<asp:Label ID="lbCopyright" runat="server" /><span>|</span><strong><i><asp:Label ID="lbDoneBy" runat="server" /></i></strong></p>
	<div class="cl">&nbsp;</div>
</div>
