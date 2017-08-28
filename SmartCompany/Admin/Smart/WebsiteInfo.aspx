<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Smart/ManageSite.master" AutoEventWireup="true" CodeBehind="WebsiteInfo.aspx.cs" Inherits="SmartCompany.Admin.Smart.WebsiteInfo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>


<%@ Register src="Components/Home/WebsiteInfo.ascx" tagname="WebsiteInfo" tagprefix="MukhtarWebUIControl" %>


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
        <MukhtarWebUIControl:WebsiteInfo ID="WebsiteInfo1" runat="server" />
    </ContentTemplate>
</asp:UpdatePanel>

</asp:Content>
