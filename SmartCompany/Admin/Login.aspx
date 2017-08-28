<%@ Page Title="" Language="C#" MasterPageFile="AdminSite.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SmartCompany.Admin.Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>

<%@ Register src="Smart/Components/Membership/LoginUser.ascx" tagname="LoginUser" tagprefix="MukhtarWebUIControl" %>
<%@ Register src="Smart/Components/Membership/EntryUser.ascx" tagname="EntryUser" tagprefix="MukhtarWebUIControl" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentPlaceHolderAdmin" runat="server">
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
            <div style="margin:20px 240px;">
                <MukhtarWebUIControl:LoginUser ID="mwcLoginUser" runat="server" />
                <MukhtarWebUIControl:EntryUser ID="mwcEntryUser" runat="server" Visible="false" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
