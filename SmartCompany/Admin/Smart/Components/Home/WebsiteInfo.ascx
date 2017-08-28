<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebsiteInfo.ascx.cs" Inherits="SmartCompany.Admin.Smart.Components.Home.WebsiteInfo" %>

<%@ Register src="../../../Shared/Upload/AsyncImageUpload.ascx" tagname="AsyncImageUpload" tagprefix="MukhtarWebUIControl" %>

<asp:Panel ID="msgPanel" runat="server" meta:resourcekey="msgPanelResource1">
    <p><strong><asp:Label ID="lbMsg" runat="server" meta:resourcekey="lbMsgResource1" /></strong></p>
</asp:Panel>
<!-- Box -->
<div class="box">
	<!-- Box Head -->
	<div class="box-head">
		<h2><asp:Label ID="lbBoxTitle" runat="server" Text="Website Information" 
                meta:resourcekey="lbBoxTitleResource1" /></h2>
	</div>
	<!-- End Box Head -->

		<!-- Form dv-->
		<div class="form">								
				<p>
					<asp:Label ID="lbCompanyTip" runat="server" Text="Max 30 symbols" 
                        CssClass="req" meta:resourcekey="lbCompanyTipResource1" />
					<asp:Label ID="lbfCompany" runat="server" Text="Company name" CssClass="title" 
                        meta:resourcekey="lbfCompanyResource1" />
                    <asp:RequiredFieldValidator ID="RFvCompany" runat="server" 
                        ErrorMessage="Please enter the name" ControlToValidate="txtCompany" 
                        CssClass="val_err" Display="Dynamic" SetFocusOnError="True" 
                        meta:resourcekey="RFvCompanyResource1" />
                    
                    <asp:TextBox ID="txtCompany" runat="server" CssClass="field size1_a" 
                        MaxLength="30" meta:resourcekey="txtCompanyResource1" />
				</p>	
				<p>
					<asp:Label ID="lbTitleTip" runat="server" Text="Max 30 symbols" CssClass="req" 
                        meta:resourcekey="lbTitleTipResource1" />
					<asp:Label ID="lbfTitle" runat="server" Text="Title" CssClass="title" 
                        meta:resourcekey="lbfTitleResource1" />
                    <asp:RequiredFieldValidator ID="RFvTitle" runat="server" 
                        ErrorMessage="Please enter the name" ControlToValidate="txtTitle" 
                        CssClass="val_err" Display="Dynamic" SetFocusOnError="True" 
                        meta:resourcekey="RFvTitleResource1" />
                    
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="field size1_a" 
                        MaxLength="30" meta:resourcekey="txtTitleResource1" />
				</p>
				<p>
				    &nbsp;<MukhtarWebUIControl:AsyncImageUpload ID="mwcAsyncImageUpload" runat="server" />
        </div>
		<!-- End Form dv-->
						
		<!-- Form Buttons -->
		<div class="buttons">
            <asp:Button ID="btnSave" runat="server" Text="Submit" CssClass="button" 
                onclick="btnSave_Click" meta:resourcekey="btnSaveResource1" />
		</div>
		<!-- End Form Buttons -->
</div>
<!-- End Box -->
