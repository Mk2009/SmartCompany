<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SlideShow.ascx.cs" Inherits="SmartCompany.View.Main.SlideShow" %>

<div class="slider-holder" dir="ltr">
	<span class="slider-shadow"></span>
	<span class="slider-b"></span>
	<div class="slider flexslider">

    <asp:Repeater ID="repeaterData" runat="server" onitemdatabound="repeaterData_ItemDataBound">
    <HeaderTemplate>
        <ul class="slides">
    </HeaderTemplate>
    <ItemTemplate>
		<li>
			<div class="img-holder">
				<asp:Image ID="imgShow" runat="server" ImageUrl='<%#Eval("ImagePath")%>' />
			</div>
			<div class="slide-cnt">
				<h2><asp:Label ID="lbTitle" runat="server"><%#Eval("Title")%></asp:Label></h2>
				<div class="box-cnt">
                <asp:HiddenField ID="hFiedlDesc" runat="server" Value='<%#Eval("Description")%>' />
					<p><%#SetSomeLongText(Eval("Description").ToString())%></p>
				</div>
                <asp:HyperLink ID="hLnkTitle" runat="server" CssClass="grey-btn" Text="More Information" NavigateUrl='<%# Eval("Id", "~/Page.aspx?ID={0}") %>' />
			</div>
		</li>    
    </ItemTemplate>
    <FooterTemplate></ul></FooterTemplate>
    </asp:Repeater>
    <!--
		<ul class="slides">
			<li>
				<div class="img-holder">
					<img src="../../Upload/Images/1.jpg" alt="" />
				</div>
				<div class="slide-cnt">
					<h2>Your Title Here</h2>
					<div class="box-cnt">
						<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus eget augue quis lorem ipsum dolor sit amet, consectetur adipiscing elit. llus eget augue quis lorem ipsum dolor sit amet, free css templates</p>
					</div>
					<a href="#" class="grey-btn">request a demo</a>
				</div>
			</li>
			<li>
				<div class="img-holder">
					<img src="../../Upload/Images/2.jpg" alt="" />
				</div>
				<div class="slide-cnt">
					<h2>Your Title Here</h2>
					<div class="box-cnt">
						<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus eget augue quis lorem ipsum dolor sit amet, consectetur adipiscing elit. llus eget augue quis lorem ipsum dolor sit amet, free css templates</p>
					</div>
					<a href="#" class="grey-btn">request a demo</a>
				</div>
			</li>
			<li>
				<div class="img-holder">
					<img src="../../Upload/Images/3.jpg" alt="" />
				</div>
				<div class="slide-cnt">
					<h2>Your Title Here</h2>
					<div class="box-cnt">
						<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus eget augue quis lorem ipsum dolor sit amet, consectetur adipiscing elit. llus eget augue quis lorem ipsum dolor sit amet, free css templates</p>
					</div>
					<a href="#" class="grey-btn">request a demo</a>
				</div>
			</li>
		</ul>
        -->
	</div>
</div>
