<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AboutInfo.ascx.cs" Inherits="SmartCompany.Admin.Smart.Components.Home.AboutInfo" %>

<asp:Panel ID="msgPanel" runat="server" meta:resourcekey="msgPanelResource1">
    <p><strong><asp:Label ID="lbMsg" runat="server" meta:resourcekey="lbMsgResource1" /></strong></p>
</asp:Panel>
<!-- Box -->
<div class="box">
	<!-- Box Head -->
	<div class="box-head">
		<h2><asp:Label ID="lbBoxTitle" runat="server" Text="About Company" 
                meta:resourcekey="lbBoxTitleResource1" /></h2>
	</div>
	<!-- End Box Head -->
										
		<!-- Form -->
		<div class="form">								
				<p>
					<asp:Label ID="lbInfoTip" runat="server" Text="Max 560 symbols" CssClass="req" 
                        meta:resourcekey="lbInfoTipResource1" />
					<asp:Label ID="lbfWhoAreWe" runat="server" Text="Who Are We" CssClass="title" 
                        meta:resourcekey="lbfWhoAreWeResource1" />
                    <asp:RequiredFieldValidator ID="RFvWhoAreWe" runat="server" 
                        ErrorMessage="Please enter the information" ControlToValidate="txtWhoAreWe" 
                        CssClass="val_err" Display="Dynamic" SetFocusOnError="True" 
                        meta:resourcekey="RFvWhoAreWeResource1" />
                    <asp:RegularExpressionValidator ID="REvWhoAreWe" runat="server" 
                        ErrorMessage="Please enter a maximum of 560 characters" 
                        ValidationExpression="^[\s\S]{0,560}$" ControlToValidate="txtWhoAreWe" 
                        CssClass="val_err" Display="Dynamic" SetFocusOnError="True" 
                        meta:resourcekey="REvWhoAreWeResource1" />
                    <asp:TextBox ID="txtWhoAreWe" runat="server" CssClass="field size1_a" 
                        TextMode="MultiLine" Rows="10" Columns="30" MaxLength="560" 
                        meta:resourcekey="txtWhoAreWeResource1" />
				</p>	

				<p>
					<asp:Label ID="lbProfileTip" runat="server" Text="Max 600 symbols" 
                        CssClass="req" meta:resourcekey="lbProfileTipResource1" />
					<asp:Label ID="lbfProfile" runat="server" Text="Profile" CssClass="title" 
                        meta:resourcekey="lbfProfileResource1" />
                    <asp:RequiredFieldValidator ID="RFvProfile" runat="server" 
                        ErrorMessage="Please enter the Profile" ControlToValidate="txtProfile" 
                        CssClass="val_err" Display="Dynamic" SetFocusOnError="True" 
                        meta:resourcekey="RFvProfileResource1" />
                    <asp:RegularExpressionValidator ID="REvProfile" runat="server" 
                        ErrorMessage="Please enter a maximum of 600 characters" 
                        ValidationExpression="^[\s\S]{0,600}$" ControlToValidate="txtProfile" 
                        CssClass="val_err" Display="Dynamic" SetFocusOnError="True" 
                        meta:resourcekey="REvProfileResource1" />
                    <asp:TextBox ID="txtProfile" runat="server" CssClass="field size1_a" 
                        TextMode="MultiLine" MaxLength="600" meta:resourcekey="txtProfileResource1" />
				</p>
				<p>
                    <asp:Label ID="lbManagerTip" runat="server" Text="Max 20 symbols" 
                        CssClass="req" meta:resourcekey="lbManagerTipResource1" />
                    <asp:Label ID="lbfManager" runat="server" Text="Manager" CssClass="title" 
                        meta:resourcekey="lbfManagerResource1" />
                    <asp:RequiredFieldValidator ID="RFvManager" runat="server" 
                        ErrorMessage="Please enter the Manager" ControlToValidate="txtManager" 
                        CssClass="val_err" SetFocusOnError="True" 
                        meta:resourcekey="RFvManagerResource1" />
                    <asp:TextBox ID="txtManager" runat="server" CssClass="field size3" 
                        MaxLength="20" meta:resourcekey="txtManagerResource1" />
				</p>	
        </div>
		<!-- End Form -->
						
		<!-- Form Buttons -->
		<div class="buttons">
            <asp:Button ID="btnSave" runat="server" Text="Submit" CssClass="button" 
                onclick="btnSave_Click" meta:resourcekey="btnSaveResource1" />
		</div>
		<!-- End Form Buttons -->
</div>
<!-- End Box -->
