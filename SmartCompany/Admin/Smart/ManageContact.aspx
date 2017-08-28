<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Smart/ManageSite.master" AutoEventWireup="true" CodeBehind="ManageContact.aspx.cs" Inherits="SmartCompany.Admin.Smart.ManageContact" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>

<%@ Register src="Components/Contact/ShowContact.ascx" tagname="ShowContact" tagprefix="MukhtarWebUIControl" %>
<%@ Register src="Components/Contact/DetailMessage.ascx" tagname="DetailMessage" tagprefix="MukhtarWebUIControl" %>
<%@ Register src="../Shared/WebUI/SendEmail.ascx" tagname="SendEmail" tagprefix="MukhtarWebUIControl" %>

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
        <div class="page_title"><asp:Label ID="lbPageTitle" runat="server" Text="Manage Contacts Page" /></div>
        <hr /><br /><br />

        <MukhtarWebUIControl:ShowContact ID="mwcShow" runat="server" />
        <MukhtarWebUIControl:DetailMessage ID="mwcDetail" runat="server" Visible="false" />
        <MukhtarWebUIControl:SendEmail ID="mwcSendEmail" runat="server" Visible="false" />
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>