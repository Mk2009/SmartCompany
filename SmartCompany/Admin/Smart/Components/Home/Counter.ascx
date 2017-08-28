<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Counter.ascx.cs" Inherits="SmartCompany.Admin.Smart.Components.Home.Counter" %>

<!-- Show Box -->
<div class="box">
<!-- Box Head -->
<div class="box-head">
	<h2><asp:Label ID="lbBoxTitle" runat="server" Text="Visitors Information" 
            meta:resourcekey="lbBoxTitleResource1" /></h2>
</div><!-- End Box Head -->
<!-- Table -->
<div class="table">
    <asp:Repeater ID="repeaterCounterData" runat="server">
        <HeaderTemplate>
            <table cellpadding="0" cellspacing="0" class="sTable3" width="100%">
                <thead>
                    <tr>
                        <th style="width:200px"><asp:Label ID="lbSubject" runat="server" Text="Subject" 
                                meta:resourcekey="lbSubjectResource1" /></th>
                        <th><asp:Label ID="lbForDay" runat="server" Text="Day" 
                                meta:resourcekey="lbForDayResource1"></asp:Label></th>
                        <th><asp:Label ID="lbForWeek" runat="server" Text="Week" 
                                meta:resourcekey="lbForWeekResource1"></asp:Label></th>
                        <th><asp:Label ID="lbForMonth" runat="server" Text="Month" 
                                meta:resourcekey="lbForMonthResource1"></asp:Label></th>
                        <th style="width:100px">
                            <asp:Label ID="lbForYear" runat="server" Text="Year" 
                                meta:resourcekey="lbForYearResource1"></asp:Label>
                        </th>
                        <th style="width:120px">
                            <asp:Label ID="lbForAll" runat="server" Text="All" 
                                meta:resourcekey="lbForAllResource1"></asp:Label>
                        </th>
                    </tr>
                </thead>
            <tbody>
        </HeaderTemplate>
        <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("TitlePage") %>
                    </td>
                    <td>
                        <%# Eval("Day") %>
                    </td>
                    <td>
                        <%# Eval("Week") %>
                    </td>
                    <td>
                        <%# Eval("Month") %>
                    </td>
                    <td>
                        <%# Eval("Year") %>
                    </td>
                    <td>
                        <%# Eval("AllVisitor") %>
                    </td>
                </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
        <tr class="odd">
            <td><%#Eval("TitlePage")%></td>
            <td><%#Eval("Day")%></td>
            <td><%#Eval("Week")%></td>
            <td><%#Eval("Month")%></td>
            <td><%#Eval("Year")%></td>
            <td><%#Eval("AllVisitor")%></td>
        </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
        </tbody></table>
        </FooterTemplate>
    </asp:Repeater>
</div><!-- End Table -->

</div><!-- End Show Box -->