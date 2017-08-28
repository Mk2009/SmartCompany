<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EntryUser.ascx.cs" Inherits="SmartCompany.Admin.Smart.Components.Membership.EntryUser" %>

<asp:Panel ID="msgPanel" runat="server" meta:resourcekey="msgPanelResource1">
    <p><strong><asp:Label ID="lbMsg" runat="server" meta:resourcekey="lbMsgResource1" /></strong></p>
</asp:Panel>
<!-- Box -->
<asp:Panel ID="addPanel" runat="server" CssClass="box" 
    meta:resourcekey="addPanelResource1">
	<!-- Box Head -->
	<div class="box-head">
		<h2><asp:Label ID="lbBoxTitle" runat="server" Text="User Name Entry" 
                meta:resourcekey="lbBoxTitleResource1" /></h2>
	</div>
	<!-- End Box Head -->
	<!-- Form dv -->
	<div class="form">
        <asp:HiddenField ID="hFieldID" runat="server" />
			<p>
                <asp:Label ID="lbUserNameTip" runat="server" Text="Max 30 symbols" 
                    CssClass="req" meta:resourcekey="lbUserNameTipResource1" />
                <asp:Label ID="lbfUserName" runat="server" Text="UserName" CssClass="title" 
                    meta:resourcekey="lbfUserNameResource1" />
                <asp:RequiredFieldValidator ID="RFvUserName" runat="server" 
                    ErrorMessage="Please enter the User name" ControlToValidate="txtUserName" 
                    CssClass="val_err" SetFocusOnError="True" ValidationGroup="SavingData" 
                    meta:resourcekey="RFvUserNameResource1" />
                <asp:TextBox ID="txtUserName" runat="server" CssClass="field size1m" MaxLength="30" 
                    ValidationGroup="SavingData" meta:resourcekey="txtUserNameResource1" />
			</p>	
			<p>
                <asp:Label ID="lbPasswordTip" runat="server" Text="Max 16 symbols" 
                    CssClass="req" meta:resourcekey="lbPasswordTipResource1" />
                <asp:Label ID="lbfPassword" runat="server" Text="Password" CssClass="title" 
                    meta:resourcekey="lbfPasswordResource1" />
                <asp:RequiredFieldValidator ID="RFvPassword" runat="server" 
                    ErrorMessage="Please enter the Password" ControlToValidate="txtPassword" 
                    CssClass="val_err" SetFocusOnError="True" ValidationGroup="SavingData" 
                    meta:resourcekey="RFvPasswordResource1" />
                <asp:TextBox ID="txtPassword" runat="server" CssClass="field size1m" MaxLength="16" 
                    ValidationGroup="SavingData" TextMode="Password" 
                    meta:resourcekey="txtPasswordResource1" />
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
                <asp:CompareValidator ID="CvPassword" runat="server" ControlToCompare="txtPassword"
                    ControlToValidate="txtRePassword" CssClass="val_err" ErrorMessage="Passwords don't match!"
                    ValidationGroup="SavingData" Display="Dynamic" 
                    meta:resourcekey="CvPasswordResource1" />			
                <asp:TextBox ID="txtRePassword" runat="server" CssClass="field size1m" MaxLength="16" 
                    ValidationGroup="SavingData" TextMode="Password" 
                    meta:resourcekey="txtRePasswordResource1" />
            </p>		
			<p>
                <asp:Label ID="lbEmailTip" runat="server" Text="Max 80 symbols" CssClass="req" 
                    meta:resourcekey="lbEmailTipResource1" />
                <asp:Label ID="lbfEmail" runat="server" Text="Email" CssClass="title" 
                    meta:resourcekey="lbfEmailResource1" />
                <asp:RequiredFieldValidator ID="RFvEmail" runat="server" 
                    ErrorMessage="Please enter the email" ControlToValidate="txtEmail" 
                    CssClass="val_err" SetFocusOnError="True" ValidationGroup="SavingData" 
                    meta:resourcekey="RFvEmailResource1" />
                <asp:RegularExpressionValidator ID="REvEmail" runat="server" ControlToValidate="txtEmail"
                    CssClass="val_err" Display="Dynamic" ErrorMessage="Sorry, email is not valid"
                    SetFocusOnError="True" ValidationExpression="^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$"
                    ValidationGroup="SavingData" meta:resourcekey="REvEmailResource1" />                
                <asp:TextBox ID="txtEmail" runat="server" CssClass="field size1m" MaxLength="80" 
                    ValidationGroup="SavingData" meta:resourcekey="txtEmailResource1" />
			</p>
            <br /><br />
			<p>
                <asp:Label ID="lbFirstNameTip" runat="server" Text="Max 30 symbols" 
                    CssClass="req" meta:resourcekey="lbFirstNameTipResource1" />
                <asp:Label ID="lbfFirstName" runat="server" Text="FirstName" CssClass="title" 
                    meta:resourcekey="lbfFirstNameResource1" />
                <asp:RequiredFieldValidator ID="RFvFirstName" runat="server" 
                    ErrorMessage="Please enter the First name" ControlToValidate="txtFirstName" 
                    CssClass="val_err" SetFocusOnError="True" ValidationGroup="SavingData" 
                    meta:resourcekey="RFvFirstNameResource1" />
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="field size1m" MaxLength="30" 
                    ValidationGroup="SavingData" meta:resourcekey="txtFirstNameResource1" />
			</p>
			<p>
                <asp:Label ID="lbLastNameTip" runat="server" Text="Max 30 symbols" 
                    CssClass="req" meta:resourcekey="lbLastNameTipResource1" />
                <asp:Label ID="lbfLastName" runat="server" Text="LastName" CssClass="title" 
                    meta:resourcekey="lbfLastNameResource1" />
                <asp:RequiredFieldValidator ID="RFvLastName" runat="server" 
                    ErrorMessage="Please enter the Last name" ControlToValidate="txtLastName" 
                    CssClass="val_err" SetFocusOnError="True" ValidationGroup="SavingData" 
                    meta:resourcekey="RFvLastNameResource1" />
                <asp:TextBox ID="txtLastName" runat="server" CssClass="field size1m" MaxLength="30" 
                    ValidationGroup="SavingData" meta:resourcekey="txtLastNameResource1" />
			</p>
			<p>
                <asp:Label ID="lbMobileTip" runat="server" Text="Max 25 symbols" CssClass="req" 
                    meta:resourcekey="lbMobileTipResource1" />
                <asp:Label ID="lbfMobile" runat="server" Text="Mobile" CssClass="title" 
                    meta:resourcekey="lbfMobileResource1" />
                <asp:TextBox ID="txtMobile" runat="server" CssClass="field size1m" 
                    MaxLength="25" meta:resourcekey="txtMobileResource1" />
			</p>
            <br />	
            <p>
                <asp:Label ID="lbfPrivilege" runat="server" CssClass="title" Text="Privilege" 
                    meta:resourcekey="lbfPrivilegeResource1" />
                <asp:DropDownList ID="ddlPrivilege" runat="server" meta:resourcekey="ddlPrivilegeResource1">
                </asp:DropDownList>
                <asp:CompareValidator ID="CvPrivilege" runat="server" 
                    ControlToValidate="ddlPrivilege" ErrorMessage="Please select from the list" 
                    Operator="NotEqual" ValueToCompare="0" CssClass="val_err" Type="Integer" 
                    ValidationGroup="SavingData" />
            </p>
            <p>
                <asp:Label ID="lbfActive" runat="server" CssClass="title" Text="Show" 
                    meta:resourcekey="lbfActiveResource1" />
                <asp:DropDownList ID="ddlActive" runat="server" 
                    meta:resourcekey="ddlActiveResource1">
                    <asp:ListItem Text="Yes" Value="True" meta:resourcekey="ListItemResource1" />
                    <asp:ListItem Text="No" Value="False" meta:resourcekey="ListItemResource2" />
                </asp:DropDownList>                
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
</asp:Panel>
<!-- End Box -->


