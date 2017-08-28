using System;
using AjaxControlToolkit;

namespace SmartCompany.Admin.Shared.Upload
{
    public partial class AsyncImageUpload : System.Web.UI.UserControl
    {
        const string MainUploadFolder = "~/Uploads/Images/";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hFdImageFolder.Value = this.ImageFolderPath;// For show image
                hFdUploadFolder.Value = this.FolderPath;// For delete image
                this.GetCultureInfo(); // Multilingual purposes
                // If no image to display keep it ready to upload - New manner
                if (string.IsNullOrEmpty(imgDisplay.ImageUrl))
                    this.InitializeUploadBox(true);
            }
        }

        #region Part 2: Mukhtar Properties Area
        /// <summary>
        /// Set, get the upload title
        /// </summary>
        public string UploadTitle
        {
            get { return lbUploadTitle.Text; }
            set { lbUploadTitle.Text = value; }
        }
        /// <summary>
        /// The destination folder of upload image or file
        /// </summary>
        public string DestinationFolder
        {
            get
            {
                object obj = this.ViewState["DestinationFolder"];
                if (obj == null)
                    return string.Empty; // Default value
                else
                    return (string)obj;
            }
            set
            {
                this.ViewState["DestinationFolder"] = value;
            }
        }
        // Get the url folder path: Image preveiew purposes
        private string ImageFolderPath
        {
            get { return string.Format("{0}{1}", MainUploadFolder.Replace("~/", "../../../"), this.DestinationFolder); }
        }
        /// <summary>
        /// Get the physical folder path: Save in or Delete from  purposes
        /// </summary>
        public string FolderPath
        {
            get { return string.Format("{0}{1}", MainUploadFolder, this.DestinationFolder); }
        }
        /// <summary>
        /// Get the physical full path: Save in database purposes
        /// </summary>
        public string FullPath
        {
            get 
            {
                if (this.HasFile == true)
                    return string.Format("{0}{1}{2}", MainUploadFolder, this.DestinationFolder, hFdFileName.Value);
                else
                    return txtUrl.Text;
            }
        }
        /// <summary>
        /// I want to check if the user has been uploaded image, will send value in jquery method
        /// </summary>
        public bool HasFile
        {
            get { return Convert.ToBoolean(hFdHasFile.Value); }
        }
 
        /// <summary>
        /// Get the shown image url 
        /// I need this for edit purposes when user doesn't like to change the uploaded image, so save it again
        /// </summary>
        public string ShownImageUrl
        {
            get { return imgDisplay.ImageUrl; }
        }

        #endregion

        #region Part 3: Upload Controller [asyncImgUpload_UploadedComplete]
        // Save uploaded image or file to uplaod folder
        protected void asyncImgUpload_UploadedComplete(object sender, AsyncFileUploadEventArgs e)
        {
            string filename = System.IO.Path.GetFileName(asyncImgUpload.FileName);
            asyncImgUpload.SaveAs(Server.MapPath(this.FolderPath) + filename);
        }
        #endregion

        #region Part 4: Other Methods
        // Initialize the upload box for both add or edit data
        public void InitializeUploadBox(bool newManner, string imageUrl=null)
        {
            if (newManner == true)
            {
                upload_dv.Style.Add("display", "block");
                img_prview_dv.Style.Add("display", "none");
                imgDisplay.ImageUrl = string.Empty;
            }
            else
            {
                upload_dv.Style.Add("display", "none");
                img_prview_dv.Style.Add("display", "block");
                imgDisplay.ImageUrl = imageUrl;
                hFdFullPath.Value = imgDisplay.ImageUrl;// For delete old image - Edit manner
            }
        }
        // Get culture info. - this method will be called out of PostBack
        private void GetCultureInfo()
        {
            hFdConfirmDeleteMsg.Value = Properties.Resources.ConfirmDeleteImage;
            lbUrlTitle.Text = Properties.Resources.ImageUrl;
        }

        #endregion

    }// end class
}// end NS