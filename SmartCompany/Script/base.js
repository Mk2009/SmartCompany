$(document).ready(function () {
    // Let me show multi action box when user just click on one of my repeater checkbox 
    $("input:checkbox").live('click', function () {
        // Call method - its below out of document ready area [id$='_btnMultiDeletes']
        countChecked();

        // if no checkbox is checked hide delete button
        if (countChecked() == 0) {
            $("#dvMultiBtn").fadeOut("medium");
        } else {

            if ($("#dvMultiBtn").is(":hidden")) {
                $("#dvMultiBtn").fadeIn("medium");
            }
        }
    });

    $("ul#topnav li").hover(function () { //Hover over event on list item
        $(this).css({ 'background': '#ba4c32 url(topnav_a.png) repeat-x' }); //Add background color + image on hovered list item
        $(this).find("span").show(); //Show the subnav
    }, function () { //on hover out...
        $(this).css({ 'background': 'none' }); //Ditch the background
        $(this).find("span").hide(); //Hide the subnav
    });

    // Image source Tabs  
    //$(".tabContents").hide(); // Hide all tab content divs by default
    //$(".tabContents:first").show(); // Show the first div of tab content by default

    //$(".tabContaier ul li a").click(function () { //Fire the click event
    //    alert('Welcom man');
    //    var activeTab = $(this).attr("href"); // Catch the click link
    //    $(".tabContaier ul li a").removeClass("active"); // Remove pre-highlighted link
    //    $(this).addClass("active"); // set clicked link to highlight state
    //    $(".tabContents").hide(); // hide currently visible tab content div
    //    $(activeTab).fadeIn(); // show the target tab content div by matching clicked link.

    //    return false; //prevent page scrolling on tab click
    //}); 

});// END $(document).ready(function () 

// The following method for hide show delete button when checkbox cheked
function countChecked() {
    return $("input:checked").length;
}
//0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
// Let's use a lowercase function name to keep with JavaScript conventions
function selectAllCheckBoxes(invoker) {
    // Since ASP.NET checkboxes are really HTML input elements
    //  let's get all the inputs 
    var inputElements = document.getElementsByTagName('input');

    for (var i = 0; i < inputElements.length; i++) {
        var myElement = inputElements[i];

        // Filter through the input types looking for checkboxes
        if (myElement.type === "checkbox") {

            // Use the invoker (our calling element) as the reference 
            //  for our checkbox status
            myElement.checked = invoker.checked;

        }
    }
} // end function
//0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000

//0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
// UPLOAD SYSTEM START
// Check the extension first 
function imageUploadStart(sender, args) {
    var fileName = args.get_fileName();
    var fileExt = fileName.substring(fileName.lastIndexOf(".") + 1);

    // Check the extension 
    if (fileExt == "png" || fileExt == "jpg" || fileExt == "jpeg" || fileExt == "gif") {
        initializeUpload();
        return true;
    } else {
        //To cancel the upload, throw an error, it will fire OnClientUploadError 
        var err = new Error();
        err.name = "Upload Error"; $("[id$='_err_msg_dv']").show();
        err.message = "\n" + $get("lbErrMsg").innerHTML;  //+ "\n" + $get("lbExtension").innerHTML; //"Please upload only Images files (.png, .jpg, .jpeg, .gif)";
        throw (err);

        return false;
    }
}
//-------------------------------------------------------------------------------------------------------
// when upload is complete
function imageUploadComplete(sender, args) {

    try {
        
        $get("lbUploadType").innerHTML = args.get_contentType(); //  + " - " + args.get_fileName() + " - " + args.get_contentType();
        $get("lbUploadSize").innerHTML = bytesToSize(args.get_length());
        $get("imgDisplay").src = $get("hFdImageFolder").value + args.get_fileName();
        $get("hFdFullPath").value = $get("hFdUploadFolder").value + args.get_fileName();
        $get("hFdFileName").value = args.get_fileName();
        $("[id$='_img_prview_dv']").show();
        $get("hFdHasFile").value = "true";
        $("[id$='_upload_dv']").hide(); 
    }
    catch (e) {
    }
}
// Hide some dvs befor uplaod
function initializeUpload() {
    $("[id$='_img_prview_dv']").hide();
    $("[id$='_err_msg_dv']").hide();
    $("[id$='_ok_del_msg_dv']").hide();
}
function uploadError() {
}

//-------------------------------------------------------------------------------------------------------
// Convert size from bytes to KB
function bytesToSize(bytes) {
    var sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB'];
    if (bytes == 0) return 'n/a';
    var i = parseInt(Math.floor(Math.log(bytes) / Math.log(1024)));
    return Math.round(bytes / Math.pow(1024, i), 2) + ' ' + sizes[[i]];
}
//-------------------------------------------------------------------------------------------------------
// Delete image file using jquery to handler.ashx
function deleteFile() {
    var res = confirm($get("hFdConfirmDeleteMsg").value);
    if (res == true) {
        var file = $get("hFdFullPath").value;
        $.ajax({
            url: "../Shared/Upload/UploadHandler.ashx?file=" + file,
            type: "GET",
            cache: false,
            async: true,
            success: function (html) {
                $("[id$='_img_prview_dv']").hide(); $("[id$='_err_msg_dv']").hide();
                $("[id$='_ok_del_msg_dv']").show();
                $("[id$='_upload_dv']").show();
                $get("hFdHasFile").value = "false";
            }
        });
    }
}
// END UPLOAD
//0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000

//-------------------------------------------------------------------------------------------------------
// JQuery Tool tip
// I put this code for Modal popout _ModalPopupExtender1 

// Show the ModalPopupExtAddBox - [ADD || EDIT] EX: add class, add level, add subject ... etc.
function showModalPopUpAddBox(sender, e) {
    $find$("[id$='_ModalPopupExtAddBox']").show();
}
// Hide the ModalPopupExtAddBox
function hideModalPopUpAddBox(sender, e) {
    $find$("[id$='_ModalPopupExtAddBox']").hide();
}
