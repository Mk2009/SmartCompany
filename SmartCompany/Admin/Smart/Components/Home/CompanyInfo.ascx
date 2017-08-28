<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CompanyInfo.ascx.cs" Inherits="SmartCompany.Admin.Smart.Components.Home.CompanyInfo" %>

<asp:Panel ID="msgPanel" runat="server" meta:resourcekey="msgPanelResource1">
    <p><strong><asp:Label ID="lbMsg" runat="server" meta:resourcekey="lbMsgResource1" /></strong></p>
</asp:Panel>
<!-- Box -->
<div class="box">
	<!-- Box Head -->
	<div class="box-head">
		<h2><asp:Label ID="lbBoxTitle" runat="server" Text="Company Information" 
                meta:resourcekey="lbBoxTitleResource1" /></h2>
<%--        <div>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0">
                <ProgressTemplate>
                    <asp:Image ID="imgLoading" runat="server" ImageUrl="~/App_Themes/Default/Images/spacer.gif" CssClass="loader" />
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>--%>
	</div>
	<!-- End Box Head -->

		<!-- Form -->
		<div class="form">
				<p>
                    <asp:Label ID="lbTitleTip" runat="server" Text="Max 50 symbols" CssClass="req" 
                        meta:resourcekey="lbTitleTipResource1" />
                    <asp:Label ID="lbfTitle" runat="server" Text="Title" CssClass="title" 
                        meta:resourcekey="lbfTitleResource1" />
                    <asp:RequiredFieldValidator ID="RFvTitle" runat="server" 
                        ErrorMessage="Please enter the title" ControlToValidate="txtTitle" 
                        CssClass="val_err" SetFocusOnError="True" 
                        meta:resourcekey="RFvTitleResource1" />
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="field size1" MaxLength="50" 
                        meta:resourcekey="txtTitleResource1" />
				</p>	
								
				<p>
					<asp:Label ID="lbInfoTip" runat="server" Text="Max 560 symbols" CssClass="req" 
                        meta:resourcekey="lbInfoTipResource1" />
					<asp:Label ID="lbfInformation" runat="server" Text="Content" CssClass="title" 
                        meta:resourcekey="lbfInformationResource1" />
                    <asp:RequiredFieldValidator ID="RFvInformation" runat="server" 
                        ErrorMessage="Please enter the title" ControlToValidate="txtInformation" 
                        CssClass="val_err" Display="Dynamic" SetFocusOnError="True" 
                        meta:resourcekey="RFvInformationResource1" />
                    <asp:RegularExpressionValidator ID="REvInformation" runat="server" 
                        ErrorMessage="Please enter a maximum of 560 characters" 
                        ValidationExpression="^[\s\S]{0,560}$" ControlToValidate="txtInformation" 
                        CssClass="val_err" Display="Dynamic" SetFocusOnError="True" 
                        meta:resourcekey="REvInformationResource1" />
                    <asp:TextBox ID="txtInformation" runat="server" CssClass="field size1_a" 
                        TextMode="MultiLine" Rows="10" Columns="30" MaxLength="560" 
                        meta:resourcekey="txtInformationResource1" />
				</p>	

				<p>
					<asp:Label ID="lbVisionTip" runat="server" Text="Max 280 symbols" 
                        CssClass="req" meta:resourcekey="lbVisionTipResource1" />
					<asp:Label ID="lbfVision" runat="server" Text="Vision" CssClass="title" 
                        meta:resourcekey="lbfVisionResource1" />
                    <asp:RequiredFieldValidator ID="RFvVision" runat="server" 
                        ErrorMessage="Please enter the vision" ControlToValidate="txtVision" 
                        CssClass="val_err" Display="Dynamic" SetFocusOnError="True" 
                        meta:resourcekey="RFvVisionResource1" />
                    <asp:RegularExpressionValidator ID="REvVision" runat="server" 
                        ErrorMessage="Please enter a maximum of 280 characters" 
                        ValidationExpression="^[\s\S]{0,280}$" ControlToValidate="txtVision" 
                        CssClass="val_err" Display="Dynamic" SetFocusOnError="True" 
                        meta:resourcekey="REvVisionResource1" />
                    <asp:TextBox ID="txtVision" runat="server" CssClass="field size1_b" 
                        TextMode="MultiLine" MaxLength="280" meta:resourcekey="txtVisionResource1" />
				</p>
				<p>
					<asp:Label ID="lbMissionTip" runat="server" Text="Max 280 symbols" 
                        CssClass="req" meta:resourcekey="lbMissionTipResource1" />
					<asp:Label ID="lbfMission" runat="server" Text="Mission" CssClass="title" 
                        meta:resourcekey="lbfMissionResource1" />
                    <asp:RequiredFieldValidator ID="RFvMission" runat="server" 
                        ErrorMessage="Please enter the mission" ControlToValidate="txtMission" 
                        CssClass="val_err" Display="Dynamic" SetFocusOnError="True" 
                        meta:resourcekey="RFvMissionResource1" />
                    <asp:RegularExpressionValidator ID="REvMission" runat="server" 
                        ErrorMessage="Please enter a maximum of 280 characters" 
                        ValidationExpression="^[\s\S]{0,280}$" ControlToValidate="txtMission" 
                        CssClass="val_err" Display="Dynamic" SetFocusOnError="True" 
                        meta:resourcekey="REvMissionResource1" />
                    <asp:TextBox ID="txtMission" runat="server" CssClass="field size1_b" 
                        TextMode="MultiLine" MaxLength="280" meta:resourcekey="txtMissionResource1" />
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
