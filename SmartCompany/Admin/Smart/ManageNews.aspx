<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Smart/ManageSite.master" AutoEventWireup="true" CodeBehind="ManageNews.aspx.cs" Inherits="SmartCompany.Admin.Smart.ManageNews" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>

<%@ Register src="Components/News/ShowNews.ascx" tagname="ShowNews" tagprefix="MukhtarWebUIControl" %>
<%@ Register src="Components/News/EntryNews.ascx" tagname="EntryNews" tagprefix="MukhtarWebUIControl" %>
<%@ Register src="Components/News/DetailNews.ascx" tagname="DetailNews" tagprefix="MukhtarWebUIControl" %>

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
        <div class="page_title"><asp:Label ID="lbPageTitle" runat="server" Text="Manage Activities Page" /></div>
        <hr />
        <div  class="box-content">
            <asp:Button ID="btnNew" runat="server" Text="Add new activity" 
                CssClass="btn-3 btn-3b" onclick="btnNew_Click" CommandName="ADD" />
        </div>
        <MukhtarWebUIControl:ShowNews ID="mwcShow" runat="server" />
        <MukhtarWebUIControl:EntryNews ID="mwcEntry" runat="server" Visible="false" />
        <MukhtarWebUIControl:DetailNews ID="mwcDetail" runat="server" Visible="false" />        
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
