<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuBox.ascx.cs" Inherits="SmartCompany.Admin.Shared.WebUI.MenuBox" %>

<div class="icon_box">
<table>
<tr>
    <td><asp:Label ID="lbUserInfo" runat="server" meta:resourcekey="lbUserInfoResource1" /></td>
    <td>
        <asp:DropDownList ID="ddlLanguage" runat="server" CssClass="field small-field" 
            AutoPostBack="True" 
            onselectedindexchanged="ddlLanguage_SelectedIndexChanged" 
            meta:resourcekey="ddlLanguageResource1">
        </asp:DropDownList>
    </td>
    <td><asp:ImageButton ID="imgBtnCurrent" runat="server" 
            ImageUrl="~/App_Themes/Admin/Images/spacer.gif" CssClass="nav_icon current" 
            meta:resourcekey="imgBtnCurrentResource1" /></td>
    <td><asp:ImageButton ID="imgBtnLogout" runat="server" 
            ImageUrl="~/App_Themes/Admin/Images/spacer.gif" CssClass="nav_icon logout" 
            meta:resourcekey="imgBtnLogoutResource1" /></td>
</tr>
</table>  
</div>

<div style="margin-bottom:100px;">
<ul id="topnav">
    <li>
        <asp:HyperLink ID="hlnkDashboard" runat="server" Text="Dashboard" 
            meta:resourcekey="hlnkDashboardResource1" />
    </li>
    <li>
        <asp:HyperLink ID="hlnkCompany" runat="server" Text="Company" 
            meta:resourcekey="hlnkCompanyResource1" />
        <span>
            <asp:HyperLink ID="hlnkCoInfo" runat="server" Text="Main Information" meta:resourcekey="hlnkCoInfoResource1" /> |
            <asp:HyperLink ID="hlnkAboutCoInfo" runat="server" Text="About Company Info." meta:resourcekey="hlnkAboutCoInfoResource1" /> |
            <asp:HyperLink ID="hlnkCoContactInfo" runat="server" Text="Contacts Info." meta:resourcekey="hlnkCoContactInfoResource1" /> |
            <asp:HyperLink ID="hlnkWebsiteInfo" runat="server" Text="Website Mian Info." meta:resourcekey="hlnkWebsiteInfoResource1" />
        </span>
    </li>
    
    <li>
        <asp:HyperLink ID="hlnkNews" runat="server" Text="News and Activities" 
            meta:resourcekey="hlnkNewsResource1" />
    </li>
    <li>
        <asp:HyperLink ID="hlnkBusiness" runat="server" Text="Business" 
            meta:resourcekey="hlnkBusinessResource1" />
        <span>
            <asp:HyperLink ID="hlnkCategory" runat="server" Text="Category" 
            meta:resourcekey="hlnkCategoryResource1" /> |
            <asp:HyperLink ID="hlnkServices" runat="server" Text="Services" 
            meta:resourcekey="hlnkServicesResource1" />
        </span>
    </li>
    <li><asp:HyperLink ID="hlnkContacts" runat="server" Text="Contacts" meta:resourcekey="hlnkContactsResource1" /></li>
    <li><asp:HyperLink ID="hlnkUsers" runat="server" Text="Users" meta:resourcekey="hlnkUsersResource1" /></li>
</ul>
</div>

