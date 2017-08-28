<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EntryService.ascx.cs" Inherits="SmartCompany.Admin.Smart.Components.CoService.EntryService" %>
<%@ Register src="../../../Shared/Upload/AsyncImageUpload.ascx" tagname="AsyncImageUpload" tagprefix="MukhtarWebUIControl" %>


<asp:Panel ID="msgPanel" runat="server" meta:resourcekey="msgPanelResource1">
    <p><strong><asp:Label ID="lbMsg" runat="server" meta:resourcekey="lbMsgResource1" /></strong></p>
</asp:Panel>
<!-- Box -->
<asp:Panel ID="addPanel" runat="server" CssClass="box" 
    meta:resourcekey="addPanelResource1">
	<!-- Box Head -->
	<div class="box-head">
		<h2><asp:Label ID="lbBoxTitle" runat="server" Text="Activities Entry" 
                meta:resourcekey="lbBoxTitleResource1" /></h2>
	</div>
	<!-- End Box Head -->
	<!-- Form dv -->
	<div class="form">
        <asp:HiddenField ID="hFieldID" runat="server" />
			<p>
                <asp:Label ID="lbTitleTip" runat="server" Text="Max 60 symbols" CssClass="req" 
                    meta:resourcekey="lbTitleTipResource1" />
                <asp:Label ID="lbfTitle" runat="server" Text="Title" CssClass="title" 
                    meta:resourcekey="lbfTitleResource1" />
                <asp:RequiredFieldValidator ID="RFvTitle" runat="server" 
                    ErrorMessage="Please enter the Title" ControlToValidate="txtTitle" 
                    CssClass="val_err" SetFocusOnError="True" ValidationGroup="SavingData" 
                    meta:resourcekey="RFvTitleResource1" />
                <asp:TextBox ID="txtTitle" runat="server" CssClass="field size1" MaxLength="60" 
                    ValidationGroup="SavingData" meta:resourcekey="txtTitleResource1" />
			</p>	
			<p>
                <asp:Label ID="lbfCate" runat="server" Text="Category" CssClass="title" 
                    meta:resourcekey="lbfCateResource1" />
                <asp:CompareValidator ID="CvCategory" runat="server" ControlToValidate="ddlCategory" 
                        CssClass="val_err" ErrorMessage="Please select category" Operator="NotEqual" 
                        ValidationGroup="SavingData" ValueToCompare="0" SetFocusOnError="True" 
                        meta:resourcekey="CvGenderResource1" />
                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="field size2" 
                    ValidationGroup="Saving" meta:resourcekey="ddlCategoryResource1">
                </asp:DropDownList>
			</p>					
			<p>
				<asp:Label ID="lbDescTip" runat="server" Text="Max 500 symbols" CssClass="req" 
                    meta:resourcekey="lbDescTipResource1" />
				<asp:Label ID="lbfDescription" runat="server" Text="Content" CssClass="title" 
                    meta:resourcekey="lbfDescriptionResource1" />
                <asp:RequiredFieldValidator ID="RFvDescription" runat="server" 
                    ErrorMessage="Please enter the description" ControlToValidate="txtDescription" 
                    CssClass="val_err" Display="Dynamic" SetFocusOnError="True" 
                    ValidationGroup="SavingData" meta:resourcekey="RFvDescriptionResource1" />
                <asp:RegularExpressionValidator ID="REvDescription" runat="server" 
                    ErrorMessage="Please enter a maximum of 500 characters" 
                    ValidationExpression="^[\s\S]{0,500}$" ControlToValidate="txtDescription" 
                    CssClass="val_err" Display="Dynamic" SetFocusOnError="True" 
                    ValidationGroup="SavingData" meta:resourcekey="REvDescriptionResource1" />
                <asp:TextBox ID="txtDescription" runat="server" CssClass="field size1_a" 
                    TextMode="MultiLine" Rows="10" Columns="60" MaxLength="500" 
                    ValidationGroup="SavingData" meta:resourcekey="txtDescriptionResource1" />
			</p>	
			<p>
                <MukhtarWebUIControl:AsyncImageUpload ID="mwcAsyncImageUpload" runat="server" />
            </p>
            <p>
                <asp:Label ID="lbfSlide" runat="server" CssClass="title" meta:resourcekey="lbfSlideResource1" Text="Slide Show" />
                <asp:DropDownList ID="ddlSlideShow" runat="server" meta:resourcekey="ddlSlideShowResource1">
                    <asp:ListItem meta:resourcekey="ListItemResource1" Text="No" Value="False" />
                    <asp:ListItem meta:resourcekey="ListItemResource2" Text="Yes" Value="True" />
                </asp:DropDownList>
            </p>
            <p>
                <asp:Label ID="lbfActive" runat="server" CssClass="title" meta:resourcekey="lbfActiveResource1" Text="Show" />
                <asp:DropDownList ID="ddlActive" runat="server" meta:resourcekey="ddlActiveResource1">
                    <asp:ListItem meta:resourcekey="ListItemResource3" Text="Yes" Value="True" />
                    <asp:ListItem meta:resourcekey="ListItemResource4" Text="No" Value="False" />
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


