using System;
using System.Linq;
using SmartCompany.Properties;
using SmartCompany.Admin.Shared.Code;

namespace SmartCompany.Admin.Smart.Components.News
{
    public partial class EntryNews : System.Web.UI.UserControl
    {
        protected static SmartCompanyDataContext smartDb = new SmartCompanyDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mwcAsyncImageUpload.DestinationFolder = "News/";
                mwcAsyncImageUpload.UploadTitle = Properties.Resources.NormalImageUpload;
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
        /// <summary>
        /// Set or Get the id
        /// </summary>
        public int TitleID
        {
            get
            {
                object obj = this.ViewState["TitleID"];
                if (obj == null)
                    return 0; // Default value
                else
                    return (int)obj;
            }
            set
            {
                this.ViewState["TitleID"] = value;
            }
        }
        // Get the cate id for update a row
        public int NewsID
        {
            get
            {
                object obj = this.ViewState["NewsID"];
                if (obj == null)
                    return 0; // Default value
                else
                    return (int)obj;
            }
            set
            {
                this.ViewState["NewsID"] = value;
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

        private string NewsTitle
        {
            get { return txtTitle.Text.Trim(); }
        }
        private string Description
        {
            get { return txtDescription.Text.Trim(); }
        }
        private bool Show
        {
            get { return bool.Parse(ddlActive.SelectedValue); }
        }
        #endregion

        #region Part 4: Mukhtar Save Button Click Event Controller Area
        // Save Button
        protected void btnSave_Click(object sender, EventArgs e)
        {
            msgPanel.Visible = false;
            string successMsg = string.Format("{0} <b>{1}</b> {2}", Properties.Resources.Save, this.NewsTitle, Properties.Resources.Successfully);
            bool action = false;

            if (Page.IsValid)
            {
                if (this.AddNew == true)
                    action = this.LinqInsertData();
                else
                    action = this.LinqUpdateData();

                // Check Saving data..
                if (this.Found == true)
                    BaseSys.ShowMsg(msgPanel, lbMsg, Properties.Resources.Found, "error");
                else
                {
                    if (action == true)
                        BaseSys.ShowMsg(msgPanel, lbMsg, successMsg, "ok");
                    else
                        BaseSys.ShowMsg(msgPanel, lbMsg, Properties.Resources.Failure, "error");
                }

            }
            else { BaseSys.ShowMsg(msgPanel, lbMsg, Properties.Resources.FailureValid, "error"); }

        }
        #endregion

        #region Part 5: Mukhtar LINQ Methods Controller Area

        /// <summary>
        /// Insert Data using LINQ techniques
        /// </summary>
        /// <returns></returns>
        protected bool LinqInsertData()
        {
            // Send  all values of course to  InsertCourse() storedprocedure
            //this.NewsID = smartDb.
            this.NewsID = smartDb.InsertContent
            (
                false,
                null,
                this.NewsTitle,
                this.Description,
                BaseSys.CurrentCulture,
                this.FullPath,
                false,
                BaseSys.SysUserID,
                DateTime.Now,
                this.Show
            );

            // Check if the data is already found
            if (this.NewsID == 0) this.Found = true; else this.Found = false;

            try
            {
                smartDb.SubmitChanges(); return true; // Save data and return true
            }
            catch { return false; }

        }

        /// <summary>
        /// Update Data using LINQ techniques
        /// </summary>
        /// <returns></returns>
        protected bool LinqUpdateData()
        {
            ServiceTitle title = (from t in smartDb.ServiceTitles where t.Id == this.TitleID select t).First();

            title.Title = this.NewsTitle;
            title.Description = this.Description;

            Service news = (from n in smartDb.Services where n.Id == this.NewsID select n).First();

            // Check first if the user add a new image or just keep the old once
            if (mwcAsyncImageUpload.HasFile == true)
                news.ImagePath = this.FullPath;
            
            news.EditedBy_Id = BaseSys.SysUserID;
            news.ModifiedDate = DateTime.Now;
            news.Show = this.Show;

            try
            {
                smartDb.SubmitChanges(); return true; // Save data and return true
            }
            catch { return false; }

        }

        /// <summary>
        /// Just I need to get one row from db - I need this for both edit and show details
        /// </summary>
        protected void LinqFetchRowData()
        {
            var news = (from t in smartDb.ServiceTitles
                        join s in smartDb.Services on t.Service_Id equals s.Id
                        where s.Id == this.NewsID
                        select new { s.Id, t.Title, t.Description, s.ImagePath, s.CategoryID, s.Slide, s.Show }).First();

            txtTitle.Text = news.Title;
            txtDescription.Text = news.Description;
            mwcAsyncImageUpload.InitializeUploadBox(false, news.ImagePath);

            ddlActive.ClearSelection();
            ddlActive.Items.FindByValue(news.Show.ToString()).Selected = true;

            lbBoxTitle.Text = string.Format("{0} - {1}", Properties.Resources.ActivityEntry, Properties.Resources.Edit);
        }

        #endregion

        #region Part 6: Other Methods Controller
        // Initialize the box for new data or just edit existed data
        public void InitializeBox(bool newData)
        {
            this.AddNew = newData;
            msgPanel.Visible = false;
            txtTitle.Focus();

            if (newData == false)
                this.LinqFetchRowData();
            else
            {
                BaseSys.ClearPanelControl(addPanel);
                lbBoxTitle.Text = string.Format("{0} - {1}", Properties.Resources.ActivityEntry, Properties.Resources.New);
                mwcAsyncImageUpload.InitializeUploadBox(true);
            }
        }
        #endregion

    }// end class
}// end NS