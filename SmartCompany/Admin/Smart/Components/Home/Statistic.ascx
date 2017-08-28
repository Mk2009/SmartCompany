<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Statistic.ascx.cs" Inherits="SmartCompany.Admin.Smart.Components.Home.Statistic" %>

<!-- Show Box -->
<div class="box">
<!-- Box Head -->
<div class="box-head">
	<h2><asp:Label ID="lbBoxTitle" runat="server" Text="Statistic Information" 
            meta:resourcekey="lbBoxTitleResource1" /></h2>
</div><!-- End Box Head -->

<!-- Table -->
<div class="table">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <th><asp:Label ID="lbSubject" runat="server" Text="Subject" 
                    meta:resourcekey="lbSubjectResource1" /></th>
            <th><asp:Label ID="lbAll" runat="server" Text="All" 
                    meta:resourcekey="lbAllResource1" /></th>
            <th><asp:Label ID="lbActive" runat="server" Text="Active" 
                    meta:resourcekey="lbActiveResource1" /></th>
            <th><asp:Label ID="lbNotActive" runat="server" Text="Not Active" 
                    meta:resourcekey="lbNotActiveResource1" /></th>
        </tr>
        <tr>
            <td><asp:Label ID="lbContent" runat="server" Text="Content(s)" 
                    meta:resourcekey="lbContentResource1" /></td>
            <td><asp:Label ID="lbContentAll" runat="server" 
                    meta:resourcekey="lbContentAllResource1" /></td>
            <td><asp:Label ID="lbContentActive" runat="server" CssClass="active" 
                    meta:resourcekey="lbContentActiveResource1" /></td>
            <td><asp:Label ID="lbContentNotAct" runat="server" CssClass="noactive" 
                    meta:resourcekey="lbContentNotActResource1" /></td>
        </tr>
        <tr class="odd">
            <td><asp:Label ID="lbCategory" runat="server" Text="Category(ies)" 
                    meta:resourcekey="lbCategoryResource1" /></td>
            <td><asp:Label ID="lbCategoryAll" runat="server" 
                    meta:resourcekey="lbCategoryAllResource1" /></td>
            <td><asp:Label ID="lbCategoryActive" runat="server" CssClass="active" 
                    meta:resourcekey="lbCategoryActiveResource1" /></td>
            <td><asp:Label ID="lbCategoryNotAct" runat="server" CssClass="noactive" 
                    meta:resourcekey="lbCategoryNotActResource1" /></td>
        </tr>
        <tr>
            <td><asp:Label ID="lbService" runat="server" Text="Service(s)" 
                    meta:resourcekey="lbServiceResource1" /></td>
            <td><asp:Label ID="lbServiceAll" runat="server" 
                    meta:resourcekey="lbServiceAllResource1" /></td>
            <td><asp:Label ID="lbServiceActive" runat="server" CssClass="active" 
                    meta:resourcekey="lbServiceActiveResource1" /></td>
            <td><asp:Label ID="lbServiceNotAct" runat="server" CssClass="noactive" 
                    meta:resourcekey="lbServiceNotActResource1" /></td>
        </tr>
        <tr class="odd">
            <td><asp:Label ID="lbNews" runat="server" Text="News" 
                    meta:resourcekey="lbNewsResource1" /></td>
            <td><asp:Label ID="lbNewsAll" runat="server" 
                    meta:resourcekey="lbNewsAllResource1" /></td>
            <td><asp:Label ID="lbNewsActive" runat="server" CssClass="active" 
                    meta:resourcekey="lbNewsActiveResource1" /></td>
            <td><asp:Label ID="lbNewsNotAct" runat="server" CssClass="noactive" 
                    meta:resourcekey="lbNewsNotActResource1" /></td>
        </tr>
        <tr>
            <td><asp:Label ID="lbUsers" runat="server" Text="User(s)" 
                    meta:resourcekey="lbUsersResource1" /></td>
            <td><asp:Label ID="lbUsersAll" runat="server" 
                    meta:resourcekey="lbUsersAllResource1" /></td>
            <td><asp:Label ID="lbUsersActive" runat="server" CssClass="active" 
                    meta:resourcekey="lbUsersActiveResource1" /></td>
            <td><asp:Label ID="lbUsersNotAct" runat="server" CssClass="noactive" 
                    meta:resourcekey="lbUsersNotActResource1" /></td>
        </tr>
        <tr class="odd">
            <td><asp:Label ID="lbContacts" runat="server" Text="Contact(s)" 
                    meta:resourcekey="lbContactsResource1" /></td>
            <td><asp:Label ID="lbContactsAll" runat="server" 
                    meta:resourcekey="lbContactsAllResource1" /></td>
            <td><asp:Label ID="lbContactsActive" runat="server" CssClass="active" 
                    meta:resourcekey="lbContactsActiveResource1" /></td>
            <td><asp:Label ID="lbContactsNotAct" runat="server" CssClass="noactive" 
                    meta:resourcekey="lbContactsNotActResource1" /></td>
        </tr>
    </table>
</div><!-- End Table -->

<!-- End Box Head -->	
</div><!-- End Show Box -->