<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsList.ascx.cs" Inherits="SmartCompany.View.Side.NewsList" %>

<h2><asp:Label ID="lbBoxTitle" runat="server" Text="News and Activities" /><br /></h2>

<asp:Repeater ID="repeaterData" runat="server" onitemdatabound="repeaterData_ItemDataBound">
<ItemTemplate>
    <p><strong><asp:Label ID="lbTitle" runat="server"><%#Eval("Title")%></asp:Label>
       <asp:HyperLink ID="hLnkTitle" runat="server" NavigateUrl='<%# Eval("Id", "~/Page.aspx?ID={0}") %>'><%#Eval("Title")%></asp:HyperLink></strong>
        <asp:HiddenField ID="hFiedlDesc" runat="server" Value='<%#Eval("Description")%>' />
        <%#SetSomeLongText(Eval("Description").ToString())%>
    <br /><small><asp:Label ID="lbDate" runat="server" /><%#Eval("ModifiedDate")%></small></p>
</ItemTemplate>
</asp:Repeater>

<p><asp:HyperLink ID="hlnkMore" runat="server" Text="More news and activities" NavigateUrl="~/News.aspx" /></p>
        