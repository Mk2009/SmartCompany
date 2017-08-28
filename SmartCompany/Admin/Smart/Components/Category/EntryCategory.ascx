<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EntryCategory.ascx.cs" Inherits="SmartCompany.Admin.Smart.Components.Category.EntryCategory" %>


<%@ Register src="../../../Shared/Upload/AsyncImageUpload.ascx" tagname="AsyncImageUpload" tagprefix="MukhtarWebUImagePathtrol" %>

<asp:Panel ID="msgPanel" runat="server" meta:resourcekey="msgPanelResource1">
    <p><strong><asp:Label ID="lbMsg" runat="server" meta:resourcekey="lbMsgResource1" /></strong></p>
</asp:Panel>
<!-- Box -->
<asp:Panel ID="addPanel" runat="server" CssClass="box" 
    meta:resourcekey="addPanelResource1">
	<!-- Box Head -->
	<div class="box-head">
		<h2><asp:Label ID="lbBoxTitle" runat="server" Text="Category Entry" 
                meta:resourcekey="lbBoxTitleResource1" /></h2>
	</div>
	<!-- End Box Head -->
	<!-- Form dv -->
	<div class="form">
        <asp:HiddenField ID="hFieldID" runat="server" />
			<p>
                <asp:Label ID="lbNameTip" runat="server" Text="Max 30 symbols" CssClass="req" 
                    meta:resourcekey="lbNameTipResource1" />
                <asp:Label ID="lbfName" runat="server" Text="Name" CssClass="title" 
                    meta:resourcekey="lbfNameResource1" />
                <asp:RequiredFieldValidator ID="RFvName" runat="server" 
                    ErrorMessage="Please enter the Name" ControlToValidate="txtName" 
                    CssClass="val_err" SetFocusOnError="True" ValidationGroup="SavingData" 
                    meta:resourcekey="RFvNameResource1" />
                <asp:TextBox ID="txtName" runat="server" CssClass="field size1" MaxLength="30" 
                    ValidationGroup="SavingData" meta:resourcekey="txtNameResource1" />
			</p>	
								
			<p>
				<asp:Label ID="lbDescTip" runat="server" Text="Max 300 symbols" CssClass="req" 
                    meta:resourcekey="lbDescTipResource1" />
				<asp:Label ID="lbfDescription" runat="server" Text="Content" CssClass="title" 
                    meta:resourcekey="lbfDescriptionResource1" />
                <asp:RequiredFieldValidator ID="RFvDescription" runat="server" 
                    ErrorMessage="Please enter the description" ControlToValidate="txtDescription" 
                    CssClass="val_err" Display="Dynamic" SetFocusOnError="True" 
                    ValidationGroup="SavingData" meta:resourcekey="RFvDescriptionResource1" />
                <asp:RegularExpressionValidator ID="REvDescription" runat="server" 
                    ErrorMessage="Please enter a maximum of 300 characters" 
                    ValidationExpression="^[\s\S]{0,300}$" ControlToValidate="txtDescription" 
                    CssClass="val_err" Display="Dynamic" SetFocusOnError="True" 
                    ValidationGroup="SavingData" meta:resourcekey="REvDescriptionResource1" />
                <asp:TextBox ID="txtDescription" runat="server" CssClass="field size1_a" 
                    TextMode="MultiLine" Rows="10" Columns="30" MaxLength="300" 
                    ValidationGroup="SavingData" meta:resourcekey="txtDescriptionResource1" />
			</p>	

			<p>
                &nbsp;<MukhtarWebUImagePathtrol:AsyncImageUpload ID="mwcAsyncImageUpload" runat="server" />
                <p>
                    <asp:Label ID="lbActive" runat="server" CssClass="title" 
                        meta:resourcekey="lbActiveResource1" Text="Active" />
                    <asp:DropDownList ID="ddlActive" runat="server" 
                        meta:resourcekey="ddlActiveResource1">
                        <asp:ListItem meta:resourcekey="ListItemResource1" Text="Yes" Value="True" />
                        <asp:ListItem meta:resourcekey="ListItemResource2" Text="No" Value="False" />
                    </asp:DropDownList>
                </p>
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
