<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StackholderList.ascx.cs" Inherits="SmartCompany.View.Content.StackholderList" %>

<asp:Label ID="lbStackholder" runat="server" />

<asp:Repeater ID="repeaterData" runat="server">
<ItemTemplate>
    <asp:Label ID="lbName" runat="server"><%#Eval("Name")%></asp:Label>
</ItemTemplate>
</asp:Repeater>
