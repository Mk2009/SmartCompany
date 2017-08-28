using System;
using System.Linq;
using SmartCompany.Admin.Shared.Code;
using SmartCompany.App_Data;
using System.IO;

namespace SmartCompany.Admin.Smart.Components.Category
{
    public partial class EntryCategory : System.Web.UI.UserControl
    {
        // Connect to xml DataSet to get data from [Home]
        Company.CategoryDataTable category = new Company.CategoryDataTable();
        Company.CategoryRow row;
        string xmlFile = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            xmlFile = BaseSys.GetXmlFilePath("Category.xml"); // !Important - Multilingual resource
            if (!IsPostBack)
            {
                mwcAsyncImageUpload.DestinationFolder = "Category/";
                mwcAsyncImageUpload.UploadTitle = Properties.Resources.CategoryImageUpload;
            }
        }

        #region Part 3: Mukhtar Properties Area
        /// <summary>
        /// Determine if this for add new reocrd or just edit current
        /// </summary>
        protected bool AddNew
        {
            get
            {
                object obj = this.ViewState["AddNew"];
                if (obj == null)
                    return false; // Default value
                else
                    return (bool)obj;
            }
            set
            {
                this.ViewState["AddNew"] = value;
            }
        }
        // Get the cate id for update a row
        public short CategoryID
        {
            get
            {
                object obj = this.ViewState["CategoryID"];
                if (obj == null)
                    return 0; // Default value
                else
                    return (short)obj;
            }
            set
            {
                this.ViewState["CategoryID"] = value;
            }
        }
        /// <summary>
        /// For checking found data 
        /// </summary>
        protected bool Found
        {
            get
            {
                object obj = this.ViewState["Found"];
                if (obj == null)
                    return false; // Default value
                else
                    return (bool)obj;
            }
            set
            {
                this.ViewState["Found"] = value;
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

        private string CategoryName
        {
            get { return txtName.Text.Trim(); }
        }
        private string Description
        {
            get { return txtDescription.Text.Trim(); }
        }
        private bool Active
        {
            get { return bool.Parse(ddlActive.SelectedValue); }
        }
        #endregion

        #region Part 4: Mukhtar Save Button Click Event Controller Area
        // Save Button
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (File.Exists(xmlFile))
            {
                if (Page.IsValid)
                {
                    bool action = false;

                    if (this.AddNew == true)
                        action = this.XmlInsertData();
                    else
                        action = this.LinqXmlUpdateData();

                    // Checking saving data..
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

        #region Part 5: XML Methods Controller [XmlInsertData, XmlUpdateData]
        /// <summary>
        /// Add new row to xml file using xmldataset techniques
        /// </summary>
        /// <returns></returns>
        protected bool XmlInsertData()
        {
            row = category.NewCategoryRow(); // Create new row

            row.Id = this.LinqAutoNumber();
            row.Name = this.CategoryName;
            row.Description = this.Description;
            row.Active = this.Active;
            row.ImagePath = this.FullPath;

            try
            {
                category.AddCategoryRow(row);
                category.WriteXml(xmlFile);
                return true;
            }
            catch { return false; }
        }
        /// <summary>
        /// Update row to xml file using linq to xml techniques
        /// </summary>
        /// <returns></returns>
        protected bool LinqXmlUpdateData()
        {
            category.ReadXml(xmlFile);
            var cateRow = (from c in category where c.Id == this.CategoryID select c).First();

            cateRow.Name = this.CategoryName;
            cateRow.Description = this.Description;
            cateRow.Active = this.Active;
            // Check first if the user add a new image or just keep the old once
            if (mwcAsyncImageUpload.HasFile == true)
                cateRow.ImagePath = this.FullPath; 

            try
            {
                category.AcceptChanges();
                category.WriteXml(xmlFile);
                return true;
            }
            catch { return false; }
        }

        // Fetch row data from xml file using linq to xml techniques
        protected void LinqXmlFetchRowData()
        {
            category.ReadXml(xmlFile);
            var cateRow = (from c in category where c.Id == this.CategoryID select c).First();

            hFieldID.Value = cateRow.Id.ToString();
            txtName.Text = cateRow.Name;
            txtDescription.Text = cateRow.Description;
            mwcAsyncImageUpload.InitializeUploadBox(false, cateRow.ImagePath);

            //ddlActive.ClearSelection();
            //ddlActive.Items.FindByValue(cateRow.Active.ToString()).Selected = true;
            lbBoxTitle.Text = string.Format("{0} - {1}", Properties.Resources.CategoryEntry, Properties.Resources.Edit);
        }

        // Auto number for new category row
        private short LinqAutoNumber()
        {
            category.ReadXml(xmlFile);
            var maxId = category.Max(c => c.Id + 1);

            return short.Parse(maxId.ToString());
        }

        #endregion

        #region Part 6: Other Methods Controller
        // Initialize the box for new data or just edit existed data
        public void InitializeBox(bool newData)
        {
            this.AddNew = newData;
            msgPanel.Visible = false;
            txtName.Focus();

            if (newData == false)
                this.LinqXmlFetchRowData();
            else
            {
                BaseSys.ClearPanelControl(addPanel);
                lbBoxTitle.Text = string.Format("{0} - {1}", Properties.Resources.CategoryEntry, Properties.Resources.New);
                mwcAsyncImageUpload.InitializeUploadBox(true);
            }
        }
        #endregion


    }// end class
}// end NS