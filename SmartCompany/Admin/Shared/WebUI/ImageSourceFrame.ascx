<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImageSourceFrame.ascx.cs" Inherits="SmartCompany.Admin.Shared.WebUI.ImageSourceFrame" %>

<%@ Register src="../Upload/AsyncImageUpload.ascx" tagname="AsyncImageUpload" tagprefix="uc1" %>

<div class="tabContaier">
	<ul>
    	<li><a class="active" href="#tab1"><asp:Label ID="Label1" runat="server" Text="Internet Url" /></a></li>
    	<li><a href="#tab2"><asp:Label ID="Label2" runat="server" Text="Upload from Pc" /></a></li>
    </ul><!-- //Tab buttons -->
    <div class="tabDetails">
    	<div id="tab1" class="tabContents">
            <div>
                <table>
                    <tr>
                        <td><asp:Label ID="Label3" runat="server" Text="Url" /></td>
                        <td><asp:TextBox ID="TextBox1" runat="server" /></td>
                    </tr>
                </table>
            </div>
        </div><!-- //tab1 -->
    	<div id="tab2" class="tabContents">
            <div>
                <uc1:AsyncImageUpload ID="AsyncImageUpload1" runat="server" />
            </div>
        </div><!-- //tab2 -->
    </div><!-- //tab Details -->
</div><!-- //Tab Container -->


<%--<script src="../../../Script/Jquery/jquery-1.8.0.min.js"></script>--%>
<script type="text/javascript">
    //$(document).ready(function () {
    //    $(".tabContents").hide(); // Hide all tab content divs by default
    //    $(".tabContents:first").show(); // Show the first div of tab content by default

    //    $(".tabContaier ul li a").click(function () { //Fire the click event

    //        var activeTab = $(this).attr("href"); // Catch the click link
    //        $(".tabContaier ul li a").removeClass("active"); // Remove pre-highlighted link
    //        $(this).addClass("active"); // set clicked link to highlight state
    //        $(".tabContents").hide(); // hide currently visible tab content div
    //        $(activeTab).fadeIn(); // show the target tab content div by matching clicked link.

    //        return false; //prevent page scrolling on tab click
    //    });
    //});
</script>	

