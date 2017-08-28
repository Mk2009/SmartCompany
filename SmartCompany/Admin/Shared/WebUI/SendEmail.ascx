<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SendEmail.ascx.cs" Inherits="SmartCompany.Admin.Shared.WebUI.SendEmail" %>



<asp:Panel ID="msgPanel" runat="server" meta:resourcekey="msgPanelResource1">
    <p><strong><asp:Label ID="lbMsg" runat="server" meta:resourcekey="lbMsgResource1" /></strong></p>
</asp:Panel>
<!-- Box -->
<asp:Panel ID="addPanel" runat="server" CssClass="box" 
    meta:resourcekey="addPanelResource1">
	<!-- Box Head -->
	<div class="box-head">
		<h2><asp:Label ID="lbBoxTitle" runat="server" Text="New Message" 
                meta:resourcekey="lbBoxTitleResource1" /></h2>
	</div>
	<!-- End Box Head -->
	<!-- Form dv -->
	<div class="form">
        <asp:HiddenField ID="hFieldID" runat="server" />

			<p>
                <asp:Label ID="lbfToEmail" runat="server" Text="To Email" CssClass="title" 
                    meta:resourcekey="lbfToEmailResource1" />
                <asp:Label ID="lbToEmail" runat="server" CssClass="field size1" 
                    meta:resourcekey="lbToEmailResource1" />
			</p>

			<p>
                <asp:Label ID="lbSubjectTip" runat="server" Text="Max 160 symbols" 
                    CssClass="req" meta:resourcekey="lbSubjectTipResource1" />
                <asp:Label ID="lbfSubject" runat="server" Text="Subject" CssClass="title" 
                    meta:resourcekey="lbfSubjectResource1" />
                <asp:RequiredFieldValidator ID="RFvSubject" runat="server" 
                    ErrorMessage="Please enter the Subject" ControlToValidate="txtSubject" 
                    CssClass="val_err" SetFocusOnError="True" ValidationGroup="SavingData" 
                    meta:resourcekey="RFvSubjectResource1" />
                <asp:TextBox ID="txtSubject" runat="server" CssClass="field size1" MaxLength="160" 
                    ValidationGroup="SavingData" meta:resourcekey="txtSubjectResource1" />
			</p>	
								
			<p>
				<asp:Label ID="lbMsgTip" runat="server" Text="Max 500 symbols" CssClass="req" 
                    meta:resourcekey="lbMsgTipResource1" />
				<asp:Label ID="lbfMessage" runat="server" Text="Content" CssClass="title" 
                    meta:resourcekey="lbfMessageResource1" />
                <asp:RequiredFieldValidator ID="RFvMessage" runat="server" 
                    ErrorMessage="Please enter the description" ControlToValidate="txtMessage" 
                    CssClass="val_err" Display="Dynamic" SetFocusOnError="True" 
                    ValidationGroup="SavingData" meta:resourcekey="RFvMessageResource1" />
                <asp:RegularExpressionValidator ID="REvMessage" runat="server" 
                    ErrorMessage="Please enter a maximum of 500 characters" 
                    ValidationExpression="^[\s\S]{0,500}$" ControlToValidate="txtMessage" 
                    CssClass="val_err" Display="Dynamic" SetFocusOnError="True" 
                    ValidationGroup="SavingData" meta:resourcekey="REvMessageResource1" />
                <asp:TextBox ID="txtMessage" runat="server" CssClass="field size1_a" 
                    TextMode="MultiLine" Rows="10" Columns="60" MaxLength="500" 
                    ValidationGroup="SavingData" meta:resourcekey="txtMessageResource1" />
			</p>	

    </div>
	<!-- End Form dv-->
						
	<!-- Form Buttons -->
	<div class="buttons">
        <asp:Button ID="btnSave" runat="server" Text="Send" CssClass="button" 
            onclick="btnSave_Click" ValidationGroup="SavingData" 
            meta:resourcekey="btnSaveResource1" />
	</div>
	<!-- End Form Buttons -->
</asp:Panel>
<!-- End Box -->

