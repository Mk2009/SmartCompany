<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Category.ascx.cs" Inherits="SmartCompany.View.Main.Category" %>

<asp:Repeater ID="repeaterData" runat="server" onitemdatabound="repeaterData_ItemDataBound">
<ItemTemplate>
    <div class="col">
        <asp:Image ID="imgShow" runat="server" ImageUrl='<%#Eval("ImagePath")%>' />
        <div class="col-cnt">
            <h2><asp:Label ID="lbTitle" runat="server"><%#Eval("Name")%></asp:Label></h2>
            <asp:HiddenField ID="hFiedlDesc" runat="server" Value='<%#Eval("Description")%>' />
            <p><%#SetSomeLongText(Eval("Description").ToString())%></p>
            <asp:HyperLink ID="hLnkTitle" runat="server" CssClass="more" Text="More Information" NavigateUrl='<%# Eval("Id", "~/Business.aspx?ID={0}") %>' />
        </div>
    </div>
</ItemTemplate>
</asp:Repeater>
<div class="cl">&nbsp;</div>

