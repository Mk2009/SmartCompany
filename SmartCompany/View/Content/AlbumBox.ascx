<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AlbumBox.ascx.cs" Inherits="SmartCompany.View.Content.AlbumBox" %>

<div>
        <section> 
    
    	<div style="overflow:hidden; width:960px; margin: 100px auto; padding:0 20px;"> 
                <div class="pix_diapo">

                    <div data-thumb="images/slides/megamind1048.jpg">
                        <img src="../../images/album/1.jpg">
                        <div class="caption elemHover fromLeft">
                            This is a simple sliding image with caption. You can have more than one caption and decide the layout of the caption via css.
                        </div>
                    </div>
                    
<%--                    <div data-thumb="images/slides/megamind_07.jpg">
                        <img src="../../images/album/2.jpg"> 
                        <div class="caption elemHover fromRight" style="bottom:65px; padding-bottom:5px; color:#ff0; text-transform:uppercase">
                            Here you can see two captions.
                        </div>
                        <div class="caption elemHover fromLeft" style="padding-top:5px;">
                            The first are loaded immediately before than the second one
                        </div>
                    </div>
--%>
                    <div>
                        <img src="../../images/album/3.jpg">
                        <div class="caption elemHover fromLeft">
                            This is a simple sliding image with caption. You can have more than one caption and decide the layout of the caption via cssMuk.
                        </div>
                    </div>                  
                    <div>
                        <img src="../../images/album/4.jpg">
                        <div class="caption elemHover fromLeft">
                            This is a simple sliding image with caption. You can have more than one caption and decide the layout of the caption via cssMuk2.
                        </div>
                    </div>                  
               </div><!-- #pix_diapo -->
                
        </div>
    
    
    </section> 
    </div>