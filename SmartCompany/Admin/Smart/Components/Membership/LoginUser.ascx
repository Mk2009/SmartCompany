<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginUser.ascx.cs" Inherits="SmartCompany.Admin.Smart.Components.Membership.LoginUser" %>

<asp:Panel ID="msgPanel" runat="server" meta:resourcekey="msgPanelResource1">
    <p><strong><asp:Label ID="lbMsg" runat="server" meta:resourcekey="lbMsgResource1" /></strong></p>
</asp:Panel>
<!-- Box -->
<div class="box">
	<!-- Box Head -->
	<div class="box-head">
		<h2><asp:Label ID="lbBoxTitle" runat="server" Text="User Login Form" 
                meta:resourcekey="lbBoxTitleResource1" /></h2>
	</div>
	<!-- End Box Head -->
	<!-- Form dv -->
	<div class="form">
        <asp:HiddenField ID="hFieldLoginTryId" runat="server" Value="0" />
			<p>
                <asp:Label ID="lbfUserName" runat="server" Text="UserName" CssClass="title" 
                    meta:resourcekey="lbfUserNameResource1" />
                <asp:RequiredFieldValidator ID="RFvUserName" runat="server" 
                    ErrorMessage="Please enter the User name" ControlToValidate="txtUserName" 
                    CssClass="val_err" SetFocusOnError="True" ValidationGroup="SavingData" 
                    meta:resourcekey="RFvUserNameResource1" />
                <asp:TextBox ID="txtUserName" runat="server" CssClass="field size1m" MaxLength="30" 
                    ValidationGroup="SavingData" meta:resourcekey="txtUserNameResource1" >Mukhtar2011</asp:TextBox>
			</p>	
			<p>
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
                <asp:Label ID="lbfLanguage" runat="server" CssClass="title" Text="Language" 
                    meta:resourcekey="lbfLanguageResource1" />
                <asp:DropDownList ID="ddlLanguage" runat="server" CssClass="field small-field" 
                    meta:resourcekey="ddlLanguageResource1">
                </asp:DropDownList>
            </p>
    </div>
	<!-- End Form dv-->
						
	<!-- Form Buttons -->
	<div class="buttons">
        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="button" 
            ValidationGroup="SavingData" onclick="btnLogin_Click" 
            meta:resourcekey="btnLoginResource1" />
	</div>
	<!-- End Form Buttons -->
</div>
<!-- End Box -->

