using System;
using SmartCompany.App_Data;
using System.IO;
using SmartCompany.Admin.Shared.Code;

namespace SmartCompany.Admin.Smart.Components.Home
{
    public partial class WebsiteInfo : System.Web.UI.UserControl
    {
        // Connect to xml DataSet to get data from [Home]
        Company.WebsiteDataTable about = new Company.WebsiteDataTable();
        Company.WebsiteRow row;
        string xmlFile = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            xmlFile = BaseSys.GetXmlFilePath("Website.xml"); // !Important - Multilingual resource
            if (!IsPostBack)
            {
                this.XmlFetchRowData();
                mwcAsyncImageUpload.UploadTitle = Properties.Resources.LogoImageUpload;
            }
        }

        /// <summary>
        /// If AsyncImageUpload has a file return that file full path if not return null
        /// </summary>
        protected string FullPath
        {
            get
            {
                return mwcAsyncImageUpload.FullPath;
            }
        }

        #region Part 2: Mukhtar XML Methods Controller Area
        // Fetch row data from xml using xml dataset
        protected void XmlFetchRowData()
        {
            if (File.Exists(this.xmlFile))
            {
                // Get data from xml file
                about.ReadXml(this.xmlFile);
                row = (Company.WebsiteRow)about.Rows[0];

                txtCompany.Text = row.Company;
                txtTitle.Text = row.Title;
                mwcAsyncImageUpload.InitializeUploadBox(false, row.Logo);
            }
            else
            {
                BaseSys.ShowMsg(msgPanel, lbMsg, Properties.Resources.XmlFileNotFound, "error");
            }
        }

        // Save new data to xml file using xml dataset techniques
        protected bool XmlSaveData()
        {
            about.ReadXml(this.xmlFile);
            row = (Company.WebsiteRow)about.Rows[0];

            row.Company = txtCompany.Text;
            row.Title = txtTitle.Text;
            row.Logo = this.FullPath;

            try
            {
                about.AcceptChanges();
                about.WriteXml(this.xmlFile);
                return true;
            }
            catch { return false; }
        }

        #endregion

        #region Part 3: Mukhtar Save Button Click Event Controller Area
        // Save Button
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (File.Exists(this.xmlFile))
            {
                if (Page.IsValid)
                {
                    bool action = this.XmlSaveData();

                    if (action == true)
                        BaseSys.ShowMsg(msgPanel, lbMsg, Properties.Resources.Success, "ok");
                    else
                        BaseSys.ShowMsg(msgPanel, lbMsg, Properties.Resources.Failure, "error");
                }
                else { BaseSys.ShowMsg(msgPanel, lbMsg, Properties.Resources.FailureValid, "error"); }
            }
            else { BaseSys.ShowMsg(msgPanel, lbMsg, Properties.Resources.XmlFileNotFound, "error"); }
        }
        #endregion


    }// end class
}// end NS