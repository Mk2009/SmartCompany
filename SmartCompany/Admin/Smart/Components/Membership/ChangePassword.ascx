<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.ascx.cs" Inherits="SmartCompany.Admin.Smart.Components.Membership.ChangePassword" %>

<div class="box">

    <asp:Panel ID="msgPanel" runat="server" meta:resourcekey="msgPanelResource1">
        <p><strong><asp:Label ID="lbMsg" runat="server" meta:resourcekey="lbMsgResource1" /></strong></p>
    </asp:Panel>

	<!-- Box Head -->
	<div class="box-head" style="height:40px;">
        <asp:Label ID="lbBoxTitle" runat="server" Text="Current User" meta:resourcekey="lbBoxTitleResource1" />
	</div>
	<!-- End Box Head -->

    <!-- Form dv -->
	<div class="form">
			<p>
                <asp:Label ID="lbPasswordTip" runat="server" Text="Max 16 symbols" 
                    CssClass="req" meta:resourcekey="lbPasswordTipResource1" />
                <asp:Label ID="lbfPassword" runat="server" Text="Password" CssClass="title" 
                    meta:resourcekey="lbfPasswordResource1" />
                <asp:RequiredFieldValidator ID="RFvPassword" runat="server" 
                    ErrorMessage="Please enter the Password" ControlToValidate="txtPassword" 
                    CssClass="val_err" SetFocusOnError="True" ValidationGroup="SavingData" 
                    meta:resourcekey="RFvPasswordResource1" />
                <asp:TextBox ID="txtPassword" runat="server" CssClass="field size1" MaxLength="16" 
                    ValidationGroup="SavingData" TextMode="Password" 
                    meta:resourcekey="txtPasswordResource1" />
			</p>
			<p>
                <asp:Label ID="lbNewPasswordTip" runat="server" Text="Max 16 symbols" 
                    CssClass="req" meta:resourcekey="lbNewPasswordTipResource1" />
                <asp:Label ID="lbfNewPassword" runat="server" Text="New Password" 
                    CssClass="title" meta:resourcekey="lbfNewPasswordResource1" />
                <asp:RequiredFieldValidator ID="RFvNewPassword" runat="server" 
                    ErrorMessage="Please enter the NewPassword" ControlToValidate="txtNewPassword" 
                    CssClass="val_err" SetFocusOnError="True" ValidationGroup="SavingData" 
                    meta:resourcekey="RFvNewPasswordResource1" />
                <asp:TextBox ID="txtNewPassword" runat="server" CssClass="field size1" MaxLength="16" 
                    ValidationGroup="SavingData" TextMode="Password" 
                    meta:resourcekey="txtNewPasswordResource1" />
            </p>
			<p>
                <asp:Label ID="lbRePasswordTip" runat="server" Text="Max 16 symbols" 
                    CssClass="req" meta:resourcekey="lbRePasswordTipResource1" />
                <asp:Label ID="lbfRePassword" runat="server" Text="RePassword" CssClass="title" 
                    meta:resourcekey="lbfRePasswordResource1" />
                <asp:RequiredFieldValidator ID="RFvRePassword" runat="server" 
                    ErrorMessage="Please enter the RePassword" ControlToValidate="txtRePassword" 
                    CssClass="val_err" SetFocusOnError="True" ValidationGroup="SavingData" 
                    meta:resourcekey="RFvRePasswordResource1" />
                <asp:CompareValidator ID="CvPassword" runat="server" ControlToCompare="txtNewPassword"
                    ControlToValidate="txtRePassword" CssClass="val_err" ErrorMessage="Passwords don't match!"
                    ValidationGroup="SavingData" Display="Dynamic" 
                    meta:resourcekey="CvPasswordResource1" />			
                <asp:TextBox ID="txtRePassword" runat="server" CssClass="field size1" MaxLength="16" 
                    ValidationGroup="SavingData" TextMode="Password" 
                    meta:resourcekey="txtRePasswordResource1" />
            </p>		
    </div>
    <!-- End Form dv-->

    <!-- Form Buttons -->
	<div class="buttons">
        <asp:Button ID="btnSave" runat="server" Text="Submit" CssClass="button" 
            onclick="btnSave_Click" ValidationGroup="SavingData" 
            meta:resourcekey="btnSaveResource1" />
	</div>
	<!-- End Form Buttons -->	
</div>

