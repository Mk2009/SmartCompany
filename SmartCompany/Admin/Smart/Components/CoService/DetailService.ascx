<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DetailService.ascx.cs" Inherits="SmartCompany.Admin.Smart.Components.CoService.DetailService" %>
<!-- Box -->
<div class="box">
	<!-- Box Head -->
	<div class="box-head">
		<h2 class="title"><asp:Label ID="lbBoxTitle" runat="server" 
                Text="Service Description" meta:resourcekey="lbBoxTitleResource1" /></h2>
		<div class="search">
            <asp:ImageButton ID="imgBtnEditDet" runat="server" OnClick="imgBtnEditDet_Click" CssClass="nav_icon edit_en" 
                ImageUrl="~/App_Themes/Admin/Images/spacer.gif" ToolTip="Edit" 
                meta:resourcekey="imgBtnEditDetResource1" />
            <asp:ImageButton ID="imgBtnPrint" runat="server" CssClass="nav_icon print" 
                OnClientClick="window.print();return false" 
                ImageUrl="~/App_Themes/Admin/Images/spacer.gif" ToolTip="Print" 
                meta:resourcekey="imgBtnPrintResource1" />
	    </div>
    </div>
	<!-- End Box Head -->
	<!-- Form dv -->
	<div class="form">
        <asp:HiddenField ID="hFieldID" runat="server" />
			<p>
                <asp:Label ID="lbfTitle" runat="server" Text="Title" CssClass="title" 
                    meta:resourcekey="lbfTitleResource1" />
                <asp:Label ID="lbTitle" runat="server" CssClass="field size1" 
                    meta:resourcekey="lbTitleResource1" />
			</p>	
            <p>
                <asp:Label ID="lbfCategory" runat="server" CssClass="title" Text="Category" 
                    meta:resourcekey="lbfCategoryResource1" />
                <asp:Label ID="lbCategory" runat="server" CssClass="field size2" 
                    meta:resourcekey="lbCategoryResource1" />
            </p> 			<p>
				<asp:Label ID="lbfDescription" runat="server" Text="Content" CssClass="title" 
                    meta:resourcekey="lbfDescriptionResource1" />
                <asp:Label ID="lbDescription" runat="server" CssClass="field size1" 
                    meta:resourcekey="lbDescriptionResource1" />
			</p>	

			<p>
                <asp:Label ID="lbfUploaded" runat="server" CssClass="title" 
                    Text="Uploaded Image" meta:resourcekey="lbfUploadedResource1" />
                <asp:Image ID="imgUploaded" runat="server" CssClass="field size1" Width="540px" 
                    Height="346px" meta:resourcekey="imgUploadedResource1" />
            </p>
            <p>
                <asp:Label ID="lbfSlide" runat="server" CssClass="title" Text="Slide" 
                    meta:resourcekey="lbfSlideResource1" />
                <asp:Label ID="lbSlide" runat="server" CssClass="field size4" 
                    meta:resourcekey="lbSlideResource1" />
            </p> 
            <p>
                <asp:Label ID="lbfShow" runat="server" CssClass="title" Text="Show" 
                    meta:resourcekey="lbfShowResource1" />
                <asp:Label ID="lbShow" runat="server" CssClass="field size4" 
                    meta:resourcekey="lbShowResource1" />
            </p> 
            <p>
                <hr />
                <asp:Label ID="lbDoneBy" runat="server" 
            meta:resourcekey="lbDoneByResource1" />
            </p>
                       
    </div>
	<!-- End Form dv-->
						
</div>
<!-- End Box -->