<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContactInfo.ascx.cs" Inherits="SmartCompany.Admin.Smart.Components.Home.ContactInfo" %>

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
					<asp:Label ID="lbAddressTip" runat="server" Text="Max 50 symbols" 
                        CssClass="req" meta:resourcekey="lbAddressTipResource1" />
					<asp:Label ID="lbfAddress" runat="server" Text="Address" 
                        CssClass="title" meta:resourcekey="lbfAddressResource1" />
                    <asp:RequiredFieldValidator ID="RFvAddress" runat="server" 
                        ErrorMessage="Please enter the address" ControlToValidate="txtAddress" 
                        CssClass="val_err" Display="Dynamic" SetFocusOnError="True" 
                        meta:resourcekey="RFvAddressResource1" />
                    
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="field size1_a" 
                        MaxLength="50" meta:resourcekey="txtAddressResource1" />
				</p>	
				<p>
					<asp:Label ID="lbPhoneTip" runat="server" Text="Max 25 symbols" CssClass="req" 
                        meta:resourcekey="lbPhoneTipResource1" />
					<asp:Label ID="lbfPhone" runat="server" Text="Phone" CssClass="title" 
                        meta:resourcekey="lbfPhoneResource1" />
                    <asp:RequiredFieldValidator ID="RFvPhone" runat="server" 
                        ErrorMessage="Please enter the phone" ControlToValidate="txtPhone" 
                        CssClass="val_err" Display="Dynamic" SetFocusOnError="True" 
                        meta:resourcekey="RFvPhoneResource1" />
                    
                    <asp:TextBox ID="txtPhone" runat="server" CssClass="field size1_a" 
                        MaxLength="25" meta:resourcekey="txtPhoneResource1" />
				</p>
				<p>
					<asp:Label ID="lbFaxTip" runat="server" Text="Max 25 symbols" CssClass="req" 
                        meta:resourcekey="lbFaxTipResource1" />
					<asp:Label ID="lbfFax" runat="server" Text="Fax" CssClass="title" 
                        meta:resourcekey="lbfFaxResource1" />
                    
                    <asp:TextBox ID="txtFax" runat="server" CssClass="field size1_a" MaxLength="25" 
                        meta:resourcekey="txtFaxResource1" />
				</p>
				<p>
					<asp:Label ID="lbMobileTip" runat="server" Text="Max 25 symbols" CssClass="req" 
                        meta:resourcekey="lbMobileTipResource1" />
					<asp:Label ID="lbfMobile" runat="server" Text="Mobile" CssClass="title" 
                        meta:resourcekey="lbfMobileResource1" />
                    
                    <asp:TextBox ID="txtMobile" runat="server" CssClass="field size1_a" 
                        MaxLength="25" meta:resourcekey="txtMobileResource1" />
				</p>
				<p>
					<asp:Label ID="lbEmailTip" runat="server" Text="Max 25 symbols" CssClass="req" 
                        meta:resourcekey="lbEmailTipResource1" />
					<asp:Label ID="lbfEmail" runat="server" Text="Email" CssClass="title" 
                        meta:resourcekey="lbfEmailResource1" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="Please enter the email" ControlToValidate="txtEmail" 
                        CssClass="val_err" Display="Dynamic" SetFocusOnError="True" 
                        meta:resourcekey="RequiredFieldValidator1Resource1" />
                    
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="field size1_a" 
                        MaxLength="25" meta:resourcekey="txtEmailResource1" />
				</p>        </div>
		<!-- End Form dv-->
						
		<!-- Form Buttons -->
		<div class="buttons">
            <asp:Button ID="btnSave" runat="server" Text="Submit" CssClass="button" 
                onclick="btnSave_Click" meta:resourcekey="btnSaveResource1" />
		</div>
		<!-- End Form Buttons -->
</div>
<!-- End Box -->
