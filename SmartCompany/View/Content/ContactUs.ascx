<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContactUs.ascx.cs" Inherits="SmartCompany.View.Content.ContactUs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>

<%@ Register src="../../Admin/Shared/WebUI/Captcha/Captcha.ascx" tagname="Captcha" tagprefix="MukhtarWebUIControl" %>

<div id="contact-box">

    <AjaxControlToolkit:ToolkitScriptManager ID="ToolkitScriptSmartSys" 
        runat="server" CombineScripts="True" />
    <asp:UpdatePanel ID="UpdatePanelSmartSys" runat="server">
    <ContentTemplate>
        <asp:Panel ID="msgPanel" runat="server" Visible="False" 
            meta:resourcekey="msgPanelResource1">
            <h2><asp:Label ID="lbMsg" runat="server" CssClass="show_msg" 
                    meta:resourcekey="lbMsgResource1" /></h2>
        </asp:Panel>

        <asp:Panel ID="contactusPanel" runat="server" 
            meta:resourcekey="contactusPanelResource1">
        <h2><asp:Label ID="lbBoxTitle" runat="server" Text="Contact us Form" 
                meta:resourcekey="lbBoxTitleResource1" /></h2>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbForName" runat="server" Text="Name" 
                        meta:resourcekey="lbForNameResource1" />
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" MaxLength="30" 
                        meta:resourcekey="txtNameResource1"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RFvName" runat="server" 
                        ControlToValidate="txtName" CssClass="val-error" 
                        meta:resourcekey="RFvNameResource1"><asp:Image ID="iconName" runat="server" 
                        ImageUrl="~/App_Themes/Default/Images/spacer.gif" 
                        ToolTip="Please enter your name" meta:resourcekey="iconNameResource1" />
</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbForEmail" runat="server" Text="Email" 
                        meta:resourcekey="lbForEmailResource1" />
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" MaxLength="80" 
                        meta:resourcekey="txtEmailResource1"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RFvEmail" runat="server" 
                        ControlToValidate="txtEmail" CssClass="val-error" Display="Dynamic" 
                        meta:resourcekey="RFvEmailResource1"><asp:Image ID="iconEmail" 
                        runat="server" ImageUrl="~/App_Themes/Default/Images/spacer.gif" 
                        ToolTip="Please enter your email" meta:resourcekey="iconEmailResource1" />
</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="REvEmail" runat="server" 
                            ControlToValidate="txtEmail" CssClass="val-error" Display="Dynamic" SetFocusOnError="True" 
                            ValidationExpression="^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$" 
                            ValidationGroup="SendMsg" meta:resourcekey="REvEmailResource1"><asp:Image 
                        ID="iconValidEmail" runat="server" 
                        ImageUrl="~/App_Themes/Default/Images/spacer.gif" 
                        ToolTip="Please enter valid email" meta:resourcekey="iconValidEmailResource1" />
</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbForMessage" runat="server" Text="Message" 
                        meta:resourcekey="lbForMessageResource1" />
                </td>
                <td>
                    <asp:TextBox ID="txtMessage" runat="server" MaxLength="200" Height="60px" 
                        TextMode="MultiLine" Width="200px" meta:resourcekey="txtMessageResource1"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RFvMessage" runat="server" 
                        ControlToValidate="txtMessage" CssClass="val-error" 
                        meta:resourcekey="RFvMessageResource1"><asp:Image ID="iconMessage" 
                        runat="server" ImageUrl="~/App_Themes/Default/Images/spacer.gif" 
                        ToolTip="Please enter your message" meta:resourcekey="iconMessageResource1" />
</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <MukhtarWebUIControl:Captcha ID="mwcCaptcha" runat="server" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbFortxtCaptchaCode" runat="server" Text="Security code" 
                        meta:resourcekey="lbFortxtCaptchaCodeResource1" />
                </td>
                <td>
                    <asp:TextBox ID="txtCaptchaCode" runat="server" MaxLength="6" 
                        meta:resourcekey="txtCaptchaCodeResource2"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RFvSecCode" runat="server" 
                        ControlToValidate="txtCaptchaCode" CssClass="val-error" 
                        meta:resourcekey="RFvSecCodeResource1"><asp:Image ID="iconCode" 
                        runat="server" ImageUrl="~/App_Themes/Default/Images/spacer.gif" 
                        ToolTip="Please enter above security code" 
                        meta:resourcekey="iconCodeResource1" />
</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnSend" runat="server" Text="Send message" 
                        onclick="btnSend_Click" meta:resourcekey="btnSendResource1" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:UpdateProgress ID="UpdateProgressSmartSys" runat="server" AssociatedUpdatePanelID="UpdatePanelSmartSys" DisplayAfter="0">
                    <ProgressTemplate>
                        <asp:Image ID="imgLoading" runat="server" 
                            ImageUrl="~/App_Themes/Default/Images/spacer.gif" CssClass="loader" 
                            meta:resourcekey="imgLoadingResource1" />
                    </ProgressTemplate>
                    </asp:UpdateProgress>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        </asp:Panel>
    </ContentTemplate>
    </asp:UpdatePanel>
</div>

