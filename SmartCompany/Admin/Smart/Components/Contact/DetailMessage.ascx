<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DetailMessage.ascx.cs" Inherits="SmartCompany.Admin.Smart.Components.Contact.DetailMessage" %>

<!-- Box -->
<div class="box">
	<!-- Box Head -->
	<div class="box-head">
		<h2 class="title"><asp:Label ID="lbBoxName" runat="server" Text="Message Details" 
                meta:resourcekey="lbBoxNameResource1" /></h2>
		<div class="icon">
            <asp:ImageButton ID="imgBtnBack" runat="server" OnClick="imgBtnBack_Click" 
                CssClass="nav_icon back" ImageUrl="~/App_Themes/Admin/Images/spacer.gif" 
                ToolTip="Back" meta:resourcekey="imgBtnBackResource1" />
            <asp:ImageButton ID="imgBtnNewMessage" runat="server" 
                OnClick="imgBtnBack_Click" CssClass="nav_icon email_en" 
                ImageUrl="~/App_Themes/Admin/Images/spacer.gif" ToolTip="Send Email" 
                meta:resourcekey="imgBtnNewMessageResource1" />
            <asp:ImageButton ID="imgBtnPrint" runat="server" CssClass="nav_icon print" 
                OnClientClick="window.print();return false" 
                ImageUrl="~/App_Themes/Admin/Images/spacer.gif" ToolTip="Print" 
                meta:resourcekey="imgBtnPrintResource1" />
	    </div>
    </div>
	<!-- End Box Head -->
	<!-- Form dv -->
	<div class="form">
			<p>
                <asp:Label ID="lbfName" runat="server" Text="Name" CssClass="title" 
                    meta:resourcekey="lbfNameResource1" />
                <asp:Label ID="lbName" runat="server" CssClass="field size1" 
                    meta:resourcekey="lbNameResource1" />
			</p>	
								
			<p>
				<asp:Label ID="lbfEmail" runat="server" Text="Email" CssClass="title" 
                    meta:resourcekey="lbfEmailResource1" />
                <asp:Label ID="lbEmail" runat="server" CssClass="field size1" 
                    meta:resourcekey="lbEmailResource1" />
			</p>
            	
			<p>
				<asp:Label ID="lbfMessage" runat="server" Text="Message" CssClass="title" 
                    meta:resourcekey="lbfMessageResource1" />
                <asp:Label ID="lbMessage" runat="server" CssClass="field size1" 
                    meta:resourcekey="lbMessageResource1" />
			</p>	

            <p>
                <asp:Label ID="lbfSentDate" runat="server" CssClass="title" Text="Send Date" 
                    meta:resourcekey="lbfSentDateResource1" />
                <asp:Label ID="lbSentDate" runat="server" CssClass="field size1m" 
                    meta:resourcekey="lbSentDateResource1" />
            </p> 
            <p>
                <hr />
                <asp:Label ID="lbSentBy" runat="server" 
                meta:resourcekey="lbSentByResource1" />
            </p>
                       
    </div>
	<!-- End Form dv-->
						
</div>
<!-- End Box -->