<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Smart/ManageSite.master" AutoEventWireup="true" CodeBehind="CurrentUser.aspx.cs" Inherits="SmartCompany.Admin.Smart.CurrentUser" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>

<%@ Register src="Components/Membership/CurrentUser.ascx" tagname="CurrentUser" tagprefix="MukhtarWebUIControl" %>
<%@ Register src="Components/Membership/ChangePassword.ascx" tagname="ChangePassword" tagprefix="MukhtarWebUIControl" %>

<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentPlaceHolderSiteManage" runat="server">
<AjaxControlToolkit:ToolkitScriptManager ID="ToolkitScriptSmartSys" runat="server" />

<asp:UpdateProgress ID="UpdateProgressSmartSys" runat="server" DisplayAfter="0">
<ProgressTemplate>
    <asp:Panel ID="loadingPanel" runat="server" CssClass="loading">
        <asp:Image ID="imgLoading" runat="server" ImageUrl="~/App_Themes/Admin/Images/spacer.gif" />
        <AjaxControlToolkit:AlwaysVisibleControlExtender ID="imgLoading_AlwaysVisibleControlExtender" 
            runat="server" Enabled="True" HorizontalOffset="80" HorizontalSide="Center" 
            TargetControlID="loadingPanel" UseAnimation="True" VerticalSide="Middle" VerticalOffset="40">
        </AjaxControlToolkit:AlwaysVisibleControlExtender>
    </asp:Panel>
</ProgressTemplate>
</asp:UpdateProgress>

<asp:UpdatePanel ID="UpdatePanelSmartSys" runat="server">
    <ContentTemplate>
        <div class="page_title"><asp:Label ID="lbPageTitle" runat="server" Text="Current User Page" /></div>
        <hr />
        <div  class="box-content">
            <asp:Button ID="btnShowHide" runat="server" Text="Change your password"  
                CssClass="btn-3 btn-3b" CommandName="PASS" onclick="btnShowHide_Click" />
        </div>
        <MukhtarWebUIControl:CurrentUser ID="mwcCurrentUser" runat="server" />
        <MukhtarWebUIControl:ChangePassword ID="mwcChangePass" runat="server" Visible="false" />
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
