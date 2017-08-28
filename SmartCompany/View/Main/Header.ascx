<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="SmartCompany.View.Main.Header" %>

<h1 id="logo"><asp:Image ID="imgLogo" runat="server" ImageUrl="~/App_Themes/Default/Images/spacer.gif" /></h1>
<!-- search -->
<div class="search">
    <table>
    <tr>
        <td>
            <asp:DropDownList ID="ddlLanguage" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlLanguage_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
        <td>
            <span class="field"><asp:TextBox ID="txtSearch" runat="server" CssClass="field"></asp:TextBox></span>
        </td>
        <td><asp:ImageButton ID="imgBtnSearch" runat="server" CssClass="search-btn" ImageUrl="~/App_Themes/Default/Images/spacer.gif" /></td>
    </tr>
    </table>


</div>
<!-- end of search  value="keywords here ..."-->

