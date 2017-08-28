<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContentList.ascx.cs" Inherits="SmartCompany.View.Content.ContentList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>

<div id="content_list">
<AjaxControlToolkit:ToolkitScriptManager ID="ToolkitScriptSmartSys" runat="server" />
    <asp:UpdatePanel ID="UpdatePanelSmartSys" runat="server">
    <ContentTemplate>
        <asp:Repeater ID="repeaterData" runat="server" onitemdatabound="repeaterData_ItemDataBound">
        <ItemTemplate>
            <div class="box">
                <asp:Image ID="imgShow" runat="server" ImageUrl='<%#SetImagePath(Eval("ImagePath").ToString())%>' />
                <h2><asp:Label ID="lbTitle" runat="server"><%#Eval("Title")%></asp:Label>
                <asp:HyperLink ID="hLnkTitle" runat="server" NavigateUrl='<%# Eval("Id", "~/Page.aspx?ID={0}") %>'><%#Eval("Title")%></asp:HyperLink></h2>
                <asp:HiddenField ID="hFiedlDesc" runat="server" Value='<%#Eval("Description")%>' />
                <p><%#SetSomeLongText(Eval("Description").ToString())%></p>
            </div>
        </ItemTemplate>
        </asp:Repeater>

        <div class="navigation"> 
            <asp:LinkButton ID="lnkBtnPrevious" runat="server" Text="Previous" onclick="lnkBtnPrevious_Click" />
            <asp:LinkButton ID="lnkBtnNext" runat="server" Text="Next" onclick="lnkBtnNext_Click" />
        </div>
        <div>
            <asp:UpdateProgress ID="UpdateProgressSmartSys" runat="server" AssociatedUpdatePanelID="UpdatePanelSmartSys" DisplayAfter="0">
            <ProgressTemplate>
                <asp:Image ID="imgLoading" runat="server" ImageUrl="~/App_Themes/Default/Images/spacer.gif" CssClass="loader" />
            </ProgressTemplate>
            </asp:UpdateProgress>
        </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</div>