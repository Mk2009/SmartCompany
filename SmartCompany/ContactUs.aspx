<%@ Page Title="" Language="C#" MasterPageFile="~/WebSite.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="SmartCompany.ContactUs" %>

<%@ Register src="View/Content/ContactUs.ascx" tagname="ContactUs" tagprefix="MukhtarWebUIControl" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="headWS" runat="server">
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentPlaceHolderWS" runat="server">

<section class="post">

<div class="content">
    <MukhtarWebUIControl:ContactUs ID="mwcContactUs" runat="server" />
</div>

<div class="side">
<h2><asp:Label ID="lbContactInfo" runat="server" Text="Contact Information" /></h2>
<div class="phone_info">
    <p><asp:Label ID="lbContact" runat="server" Text="Phone: 967-8475734 | Fax: 967-29948756" /></p>
    <p><asp:Label ID="lbMobile" runat="server" Text="Mobile: 9677765764756" /></p>
    <p><asp:Label ID="lbEmail" runat="server" Text="Email: youremail@company.com" /></p>
    <p><asp:Label ID="lbAddress" runat="server" Text="Address: Hada street, next to natco - Sana'a, Yemen" /></p>
</div>

</div>   
<div class="cl">&nbsp;</div>
	
</section>
</asp:Content>
