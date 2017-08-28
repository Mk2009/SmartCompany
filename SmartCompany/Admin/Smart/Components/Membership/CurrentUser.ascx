<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CurrentUser.ascx.cs" Inherits="SmartCompany.Admin.Smart.Components.Membership.CurrentUser" %>

<div class="box">
	<!-- Box Head -->
	<div class="box-head" style="height:40px;">
		<h2><asp:Label ID="lbBoxTitle" runat="server" Text="Current User" 
                meta:resourcekey="lbBoxTitleResource1" /></h2>
	</div>
	<!-- End Box Head -->
	<!-- Form dv -->
	<div class="form">
        <asp:HiddenField ID="hFieldID" runat="server" />
			<p>
                <asp:Label ID="lbfUserName" runat="server" Text="User Name" CssClass="title" 
                    meta:resourcekey="lbfUserNameResource1" />
                <asp:Label ID="lbUserName" runat="server" CssClass="field size1" 
                    meta:resourcekey="lbUserNameResource1" />
			</p>	
            <p>
                <asp:Label ID="lbfEmail" runat="server" CssClass="title" Text="Email" 
                    meta:resourcekey="lbfEmailResource1" />
                <asp:Label ID="lbEmail" runat="server" CssClass="field size1" 
                    meta:resourcekey="lbEmailResource1" />
            </p> 
            <p>
                <asp:Label ID="lbfPrivilege" runat="server" CssClass="title" Text="Privilege" 
                    meta:resourcekey="lbfPrivilegeResource1" />
                <asp:Label ID="lbPrivilege" runat="server" CssClass="field size3" 
                    meta:resourcekey="lbPrivilegeResource1" />
            </p> 
            <p>
				<asp:Label ID="lbfName" runat="server" Text="Name" CssClass="title" 
                    meta:resourcekey="lbfNameResource1" />
                <asp:Label ID="lbName" runat="server" CssClass="field size1" 
                    meta:resourcekey="lbNameResource1" />
			</p>	
            <p>
                <asp:Label ID="lbfMobile" runat="server" CssClass="title" Text="Mobile" 
                    meta:resourcekey="lbfMobileResource1" />
                <asp:Label ID="lbMobile" runat="server" CssClass="field size3" 
                    meta:resourcekey="lbMobileResource1" />
            </p> 
            <p>
                <asp:Label ID="lbfActive" runat="server" CssClass="title" Text="Active" 
                    meta:resourcekey="lbfActiveResource1" />
                <asp:Label ID="lbActive" runat="server" CssClass="field size4" 
                    meta:resourcekey="lbActiveResource1" />
            </p>                        
    </div>
	<!-- End Form dv-->
			

</div>