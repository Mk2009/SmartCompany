<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ServiceList.ascx.cs" Inherits="SmartCompany.View.Side.ServiceList" %>

<h2><asp:Label ID="lbBoxTitle" runat="server" Text="Our Services" /><br /></h2>

<asp:Repeater ID="repeaterData" runat="server" onitemdatabound="repeaterData_ItemDataBound">
<ItemTemplate>
    <p><strong><asp:Label ID="lbTitle" runat="server"><%#Eval("Title")%></asp:Label>
       <asp:HyperLink ID="hLnkTitle" runat="server" NavigateUrl='<%# Eval("Id", "~/Page.aspx?ID={0}") %>'><%#Eval("Title")%></asp:HyperLink></strong></p>
        <asp:HiddenField ID="hFiedlDesc" runat="server" Value='<%#Eval("Description")%>' />
        <%#SetSomeLongText(Eval("Description").ToString())%>
</ItemTemplate>
</asp:Repeater>

<p><asp:HyperLink ID="hlnkMore" runat="server" Text="More services" NavigateUrl="~/Services.aspx" /></p>
        