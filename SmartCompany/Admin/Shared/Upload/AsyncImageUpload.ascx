<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AsyncImageUpload.ascx.cs" Inherits="SmartCompany.Admin.Shared.Upload.AsyncImageUpload" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>

<div id="upload_image">

    <asp:Label ID="lbUploadTip" runat="server" Text="[.png, .jpg, .jpeg, .gif]" CssClass="req" />
    <asp:Label ID="lbUploadTitle" runat="server" CssClass="title" />

    <div id="upload_dv" runat="server">
        <AjaxControlToolkit:AsyncFileUpload ID="asyncImgUpload" runat="server" 
            onuploadedcomplete="asyncImgUpload_UploadedComplete" 
            OnClientUploadStarted="imageUploadStart" 
            OnClientUploadComplete="imageUploadComplete" Width="312" 
            ClientIDMode="Static" />
    </div>

    <div id="err_msg_dv" runat="server" class="upload_box" style="display:none;">
        <asp:Label ID="lbErrMsg" runat="server" Text="Please select image format [.png, .jpg, .jpeg, .gif] with max size of 2MB." ClientIDMode="Static" ForeColor="Red" />
    </div>

    <div id="img_prview_dv" runat="server" style="display:none;">
        <div class="upload_box">
            <asp:Image ID="imgDisplay" runat="server" Width="300" Height="150" ClientIDMode="Static" />
        </div>
        <div class="upload_box">
            <table width="100%">
            <tr>
                <td><asp:Label ID="lbUploadType" runat="server" ClientIDMode="Static" /></td>
                <td><asp:Label ID="lbUploadSize" runat="server" ClientIDMode="Static" /></td>
                <td width="22">
                <asp:ImageButton ID="imgUploadDelete" runat="server" 
                        ImageUrl="~/App_Themes/Admin/Images/spacer.gif"
                        OnClientClick="deleteFile(); return false;" ToolTip="Delete this image" 
                        CssClass="delete_icon" />
                </td>
            </tr>
            </table>
        </div>
    </div>

    <div id="ok_del_msg_dv" runat="server" class="upload_box" style="display:none;">
        <asp:Label ID="lbDelete" runat="server" Text="Image has been deleted successfully" ClientIDMode="Static" ForeColor="Green" />
    </div>
    <div>
        <p>
            <asp:Label ID="lbUrlTip" runat="server" Text="[.png, .jpg, .jpeg, .gif]" CssClass="req" />
            <asp:Label ID="lbUrlTitle" runat="server" CssClass="title" />
            <asp:TextBox ID="txtUrl" runat="server" CssClass="field size1m" />
        </p>

    </div>
    <asp:HiddenField ID="hFdUploadFolder" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hFdImageFolder" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hFdFileName" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hFdFullPath" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hFdConfirmDeleteMsg" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hFdHasFile" runat="server" ClientIDMode="Static" Value="False" />
</div>
