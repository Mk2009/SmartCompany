using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartCompany.Properties;
using SmartCompany.Admin.Shared.Code;
using AjaxControlToolkit;

namespace SmartCompany.Admin.Smart.Components.CoService
{
    public partial class ShowService : System.Web.UI.UserControl
    {
        protected static SmartCompanyDataContext smartDb = new SmartCompanyDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                this.InitializeShowBox();
        }

        #region Part 3: Mukhtar Properties Code Area
        /// <summary>
        /// Set or Get the Category id
        /// </summary>
        protected int ServiceID
        {
            get
            {
                object obj = this.ViewState["ServiceID"];
                if (obj == null)
                    return 0; // Default value
                else
                    return (int)obj;
            }
            set
            {
                this.ViewState["ServiceID"] = value;
            }
        }

        // Get the keyword from txtSearch
        private string Keywrod
        {
            get { return txtSearch.Text.Trim(); }
        }
        /// <summary>
        /// Set, get ImagePath - !Important - I need this for deletion file from folder
        /// </summary>
        protected string ImagePath
        {
            get
            {
                object obj = this.ViewState["ImagePath"];
                if (obj == null)
                    return string.Empty; // Default value
                else
                    return (string)obj;
            }
            set
            {
                this.ViewState["ImagePath"] = value;
            }
        }

        #endregion

        #region Part 4: Mukhtar Buttons Click

        #region 1. Search Menu Buttons Click
        // Sreach Button
        protected void imgBtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            this.CurrentPageIndex = 1;
            this.LinqSearchData();
        }
        // Refresh Button
        protected void imgBtnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            this.LinqFetchData();
        }

        #endregion

        #region 2. Action Icons Buttons Click Event
        // Show Link
        protected void lnkBtnDetails_Click(object sender, EventArgs e)
        {
            //----------------------------------------------
            LinkButton lnkBtnDetails = (LinkButton)sender;
            //----------------------------------------------

            DetailService mwcDetail = (DetailService)Parent.FindControl("mwcDetail");
            mwcDetail.ServiceID = Convert.ToInt16(lnkBtnDetails.CommandArgument);
            mwcDetail.LinqFetchRowData();
            this.HideMukhtarWebUIPanels();
            mwcDetail.Visible = true;
            this.BtnNewActionManner("SHOW");
        }

        // Edit Icon
        protected void lnkBtnEdit_Click(object sender, EventArgs e)
        {
            //----------------------------------------------
            LinkButton lnkBtnEdit = (LinkButton)sender;
            //----------------------------------------------

            EntryService mwcEntry = (EntryService)Parent.FindControl("mwcEntry");
            mwcEntry.ServiceID = Convert.ToInt32(lnkBtnEdit.CommandArgument);
            mwcEntry.InitializeBox(false);
            this.HideMukhtarWebUIPanels();
            mwcEntry.Visible = true;
            this.BtnNewActionManner("SHOW");
        }
        // Delete Icon
        protected void lnkBtnDelete_Click(object sender, EventArgs e)
        {
            //----------------------------------------------
            LinkButton lnkBtnDelete = (LinkButton)sender;
            //----------------------------------------------

            this.ServiceID = Convert.ToInt16(lnkBtnDelete.CommandArgument);

            if (this.LinqDeleteData() == true)
            {
                this.LinqFetchData(); BaseSys.DeleteImageFile(this.ImagePath);
            }
            else
                BaseSys.NoAction(lbMultiActMsg, Properties.Resources.NoDelete);
        }
        #endregion

        #region 3. Multiple Actions Button Click Event
        // Multi Action [Active, NoActive & Delete] Button Click Event
        protected void btnExecuteMultiAction_Click(object sender, EventArgs e)
        {
            if (ddlMultiAction.Items.FindByValue("Delete").Selected == true)
            {
                this.DoMultiAction("DELETE");
            }
            else if (ddlMultiAction.Items.FindByValue("True").Selected == true)
            {
                this.DoMultiAction("ACTIVE", true);
            }
            else if (ddlMultiAction.Items.FindByValue("False").Selected == true)
            {
                this.DoMultiAction("ACTIVE", false);
            }
        }

        #region Mukhtar DoMultiAction Method
        /// <summary>
        /// Do multiple actions to selected (checked) records
        /// Actions such as Delete, Active, No active, Block, No block ...etc.
        /// </summary>
        /// <param name="manner">The action manner</param>
        /// <param name="value">True or False</param>
        /// <returns></returns>
        protected void DoMultiAction(string manner, bool value = false)
        {
            bool action = false; string message = null;

            foreach (RepeaterItem item in repeaterData.Items)
            {
                var checkBox = item.FindControl("checkBxSelector") as CheckBox;
                var lbIdValue = item.FindControl("lbIdValue") as Label;

                this.ServiceID = short.Parse(lbIdValue.Text);
                if (checkBox.Checked)// Check the checked CheckBoxes
                {
                    if (manner == "DELETE")
                    {
                        action = this.LinqDeleteData(true);
                        message = Properties.Resources.NoDelete;
                    }
                    else
                    {
                        action = this.LinqActiveData(value);
                        message = Properties.Resources.NoAction;
                    }
                }
            }
            // Checking the action
            if (action == true)
                this.LinqFetchData();
            else // Obstruct: Not allowed to Delete or No Data has been seleccted !IMPORTANT
            {
                BaseSys.NoAction(lbMultiActMsg, message);
            }
        }
        #endregion

        #endregion

        // How can I set the confirm text of delete icon to selected langugae - LOOK BELOW
        protected void repeaterData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ConfirmButtonExtender ConfirmButtonExtForDelete = (ConfirmButtonExtender)e.Item.FindControl("ConfirmButtonExtForDelete");
                ConfirmButtonExtForDelete.ConfirmText = Properties.Resources.ConfirmDeleteMessage;
            }
        }

        #endregion

        #region Part 5: Mukhtar LINQ Methods Controller Area

        #region 1. Fetch Data [SelectContent : Service]
        /// <summary>
        /// Fetch data using LINQ techniques
        /// </summary>
        public void LinqFetchData()
        {
            var serv = smartDb.SelectContent(BaseSys.CurrentCulture, BaseSys.SysUserID, BaseSys.PrivilegeID, true).ToList();

            var _pagedDataSource = new PagedDataSource
            {
                AllowCustomPaging = true,
                AllowPaging = true,
                PageSize = this.PageSize,
                DataSource = serv.Skip((this.CurrentPageIndex - 1) * this.PageSize)
            };
            // Get the total pages
            this.PageCount = BaseSys.CalculateTotalPages(serv.Count, this.PageSize);
            // Get the pager info
            BaseSys.GetPaginationInfo(lbPaginationInfo, this.CurrentPageIndex, this.PageCount, Properties.Resources.NewsCount, serv.Count);
            this.StylePageNagiation(serv.Count);
            // Fill Repeater Data from PagedDataSource
            repeaterData.DataSource = _pagedDataSource;
            repeaterData.DataBind();

            this.NavigationFor = "LoadingData";
        }
        #endregion

        #region 2. Search Keywork [SearchContent : Service]
        /// <summary>
        /// Search for data in xml file using both xsd dataset & LINQ techniques
        /// </summary>
        protected void LinqSearchData()
        {
            var serv = smartDb.SearchContent(BaseSys.CurrentCulture, BaseSys.SysUserID, BaseSys.PrivilegeID, this.Keywrod, true).ToList();

            var _pagedDataSource = new PagedDataSource
            {
                AllowCustomPaging = true,
                AllowPaging = true,
                PageSize = this.PageSize,
                DataSource = serv.Skip((this.CurrentPageIndex - 1) * this.PageSize)
            };

            this.PageCount = BaseSys.CalculateTotalPages(serv.Count, this.PageSize);
            BaseSys.GetPaginationInfo(lbPaginationInfo, this.CurrentPageIndex, this.PageCount, Properties.Resources.Search, serv.Count);

            this.StylePageNagiation(serv.Count);
            // Fill Repeater Data from PagedDataSource
            repeaterData.DataSource = _pagedDataSource;
            repeaterData.DataBind();

            // navibation pager will work for the following
            this.NavigationFor = "Search";

        }
        #endregion

        #region 3. Delete Data [DeleteContent]
        /// <summary>
        /// Delete data from xml file using LINQ techniques
        /// </summary>
        /// <returns></returns>
        protected bool LinqDeleteData(bool multi = false)
        {
            Service Service = (from p in smartDb.Services where p.Id == this.ServiceID select p).First();
            // get image path for delete image from directory
            this.ImagePath = Service.ImagePath;

            try
            {
                smartDb.DeleteContent(this.ServiceID, multi);
                return true;
            }
            catch { return false; }
        }
        #endregion

        #region 4. Active Data [Query to Services news]
        /// <summary>
        /// Active data using LINQ techniques
        /// </summary>
        /// <returns></returns>
        protected bool LinqActiveData(bool action)
        {
            var serv = (from n in smartDb.Services where n.Id == this.ServiceID select n).First();

            serv.Show = action;

            try
            {
                smartDb.SubmitChanges(); return true;
            }
            catch { return false; }
        }
        #endregion

        #endregion

        #region Part 6: Mukhtar Methods Area
        // Initialize the box
        private void InitializeShowBox()
        {
            this.GetDataFromXml();
            this.LinqFetchData();
        }
        // Set current culture depends on selected language
        private void GetDataFromXml()
        {
            //-----------------------------------------------------------------------------
            ConfirmButtonExtForMultiActions.ConfirmText = Properties.Resources.ConfirmMultipleActions;
            //-----------------------------------------------------------------------------
        }
        // Set only some long text on repeater column to save nice design view
        public string SetSomeLongText(string longText)
        {
            if (longText.Length >= 36)
            {
                return string.Format("{0}...", longText.Substring(0, 36));
            }
            else { return longText; }
        }
        // Set all long text, I will show this on ToolTip
        public string SetAllLongText(string longText)
        {
            return longText;
        }
        // Hide all Mukhtar web UI Panels
        private void HideMukhtarWebUIPanels()
        {
            Parent.FindControl("mwcEntry").Visible = false;
            Parent.FindControl("mwcShow").Visible = false;
            Parent.FindControl("mwcDetail").Visible = false;
        }
        // I need to change the btnNew action of the page
        private void BtnNewActionManner(string manner)
        {
            Button btnNew = (Button)Parent.FindControl("btnNew");
            btnNew.CommandName = manner;
            btnNew.Text = Properties.Resources.ShowData;
        }

        #endregion

        #region Part 7: Pagination Area

        #region CurrentPageIndex, PageCount & PageSize Protected Properties
        /// <summary>
        /// Current Page property
        /// </summary>
        protected int CurrentPageIndex
        {
            get
            {
                // Look for current page in ViewState
                object obj = this.ViewState["CurrnetPage"];
                if (obj == null)
                    return 1; // Default to showing the first page
                else
                    return (int)obj;
            }
            set
            {
                this.ViewState["CurrnetPage"] = value;
            }
        }
        /// <summary>
        /// Page Count property
        /// </summary>
        protected int PageCount
        {
            get
            {
                // Look for page count in ViewState
                object obj = this.ViewState["PageCount"];
                if (obj == null)
                    return 1; // Default to just 1 page
                else
                    return (int)obj;
            }
            set
            {
                this.ViewState["PageCount"] = value;
            }
        }

        /// <summary>
        /// Page Size
        /// </summary>
        protected int PageSize
        {
            get { return Properties.Settings.Default.PageSize; }
        }

        protected string NavigationFor
        {
            get
            {
                // Look for page count in ViewState
                object obj = this.ViewState["NavigationFor"];
                if (obj == null)
                    return string.Empty; // Default to just 1 page
                else
                    return (string)obj;
            }
            set
            {
                this.ViewState["NavigationFor"] = value;
            }
        }

        #endregion

        // Setting up Pager
        private void StylePageNagiation(int recordCount)
        {
            // Disable First/Previous buttons if necessary
            if (this.CurrentPageIndex == 1)
            {
                // First Button
                imgBtnFirst.Enabled = false;
                imgBtnFirst.CssClass = "nav_icon first_ds";
                // Previous Button
                imgBtnPrevious.Enabled = false;
                imgBtnPrevious.CssClass = "nav_icon prev_ds";
            }
            else
            {
                // First Button
                imgBtnFirst.Enabled = true;
                imgBtnFirst.CssClass = "nav_icon first_en";
                // Previous Button
                imgBtnPrevious.Enabled = true;
                imgBtnPrevious.CssClass = "nav_icon prev_en";
            }

            // Disable First/Previous buttons if necessary
            if (this.CurrentPageIndex == this.PageCount || recordCount == 0)
            {
                // Next Button
                imgBtnNext.Enabled = false;
                imgBtnNext.CssClass = "nav_icon next_ds";
                // Last Button
                imgBtnLast.Enabled = false;
                imgBtnLast.CssClass = "nav_icon last_ds";
            }
            else
            {
                // Next Button
                imgBtnNext.Enabled = true;
                imgBtnNext.CssClass = "nav_icon next_en";
                // Last Button
                imgBtnLast.Enabled = true;
                imgBtnLast.CssClass = "nav_icon last_en";
            }
        }

        #region First, Previous, Next & Last Click Event Buttons
        // Go First
        protected void imgBtnFirst_Click(object sender, ImageClickEventArgs e)
        {
            // Set ViewState variable to the first page
            this.CurrentPageIndex = 1;
            // Reload Data
            this.LoadingDataManner();
        }

        // Go Previous
        protected void imgBtnPrevious_Click(object sender, ImageClickEventArgs e)
        {
            // Set ViewState variable to the previous page
            this.CurrentPageIndex -= 1;
            // Reload Data
            this.LoadingDataManner();
        }
        // Go Next
        protected void imgBtnNext_Click(object sender, ImageClickEventArgs e)
        {
            // Set ViewState varibale to the next page
            this.CurrentPageIndex += 1;
            // Reload Data
            this.LoadingDataManner();
        }
        // Go Last
        protected void imgBtnLast_Click(object sender, ImageClickEventArgs e)
        {
            // Set ViewState varibale to the LAST page
            this.CurrentPageIndex = this.PageCount;
            // Reload Data
            this.LoadingDataManner();
        }

        #endregion

        // Get type fo data for
        private void LoadingDataManner()
        {
            if (this.NavigationFor == "LoadingData")
                this.LinqFetchData();
            else if (this.NavigationFor == "Search")
                this.LinqSearchData();
        }


        #endregion

    }// end class
}// end NS