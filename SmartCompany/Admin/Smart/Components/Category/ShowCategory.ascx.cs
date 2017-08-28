using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartCompany.App_Data;
using SmartCompany.Admin.Shared.Code;
using System.Xml.Linq;
using AjaxControlToolkit;

namespace SmartCompany.Admin.Smart.Components.Category
{
    public partial class ShowCategory : System.Web.UI.UserControl
    {
        // Connect to xml DataSet to get data from [Category]
        Company.CategoryDataTable category = new Company.CategoryDataTable();
        //Company.CategoryRow row;
        string xmlFile = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                this.InitializeShowBox();
        }

        #region Part 3: Mukhtar Properties Code Area
        /// <summary>
        /// Set or Get the Category id
        /// </summary>
        protected short CategoryID
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
            this.LinqSearchXmlData();
        }
        // Refresh Button
        protected void imgBtnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            this.LinqFetchXmlData();
        }

        #endregion

        #region 2. Action ImagePaths Buttons Click Event
        // Show Link
        protected void lnkBtnDetails_Click(object sender, EventArgs e)
        {
            //----------------------------------------------
            LinkButton lnkBtnDetails = (LinkButton)sender;
            //----------------------------------------------

            DetailCategory mwcDetail = (DetailCategory)Parent.FindControl("mwcDetail");

            mwcDetail.CategoryID = Convert.ToInt16(lnkBtnDetails.CommandArgument);
            mwcDetail.LinqXmlFetchRowData();
            this.HideMukhtarWebUIPanels();
            mwcDetail.Visible = true;
            this.BtnNewActionManner("SHOW");
        }

        // Edit ImagePath
        protected void lnkBtnEdit_Click(object sender, EventArgs e)
        {
            //----------------------------------------------
            LinkButton lnkBtnEdit = (LinkButton)sender;
            //----------------------------------------------

            EntryCategory mwcEntry = (EntryCategory)Parent.FindControl("mwcEntry");
            mwcEntry.CategoryID = Convert.ToInt16(lnkBtnEdit.CommandArgument);
            mwcEntry.InitializeBox(false);
            this.HideMukhtarWebUIPanels();
            mwcEntry.Visible = true;
            this.BtnNewActionManner("SHOW");
        }
        // Delete ImagePath
        protected void lnkBtnDelete_Click(object sender, EventArgs e)
        {
            //----------------------------------------------
            LinkButton lnkBtnDelete = (LinkButton)sender;
            //----------------------------------------------

            this.CategoryID = Convert.ToInt16(lnkBtnDelete.CommandArgument);

            if (this.LinqDeleteXmlData() == true)
            {
                this.LinqFetchXmlData(); BaseSys.DeleteImageFile(this.ImagePath);
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
            else if (ddlMultiAction.Items.FindByValue("Active").Selected == true)
            {
                this.DoMultiAction("ACTIVE", true);
            }
            else if (ddlMultiAction.Items.FindByValue("NoActive").Selected == true)
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

                this.CategoryID = short.Parse(lbIdValue.Text);
                if (checkBox.Checked)// Check the checked CheckBoxes
                {
                    if (manner == "DELETE")
                    {
                        action = this.LinqDeleteXmlData(true);
                        message = Properties.Resources.NoDelete;
                    }
                    else
                    {
                        action = this.LinqActiveXmlData(value);
                        message = Properties.Resources.NoAction;
                    }
                }
            }
            // Checking the action
            if (action == true)
                this.LinqFetchXmlData();
            else // Obstruct: Not allowed to Delete or No Data has been seleccted !IMPORTANT
            {
                BaseSys.NoAction(lbMultiActMsg, message);
            }
        }
        #endregion

        #endregion

        // How can I set the confirm text of delete ImagePath to selected langugae - LOOK BELOW
        protected void repeaterData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ConfirmButtonExtender ConfirmButtonExtForDelete = (ConfirmButtonExtender)e.Item.FindControl("ConfirmButtonExtForDelete");
                ConfirmButtonExtForDelete.ConfirmText = Properties.Resources.ConfirmDeleteMessage;
            }
        }

        #endregion

        #region Part 5: Mukhtar LINQ Methods Controller Area [Get Data From Xml]

        #region 1. Fetch Data [Query to (category)]
        /// <summary>
        /// Fetch xml data using both xsd dataset & LINQ techniques
        /// </summary>
        protected void LinqFetchXmlData()
        {
            category.ReadXml(xmlFile);
            var cates = (from c in category select c).ToList();

            var _pagedDataSource = new PagedDataSource
            {
                AllowCustomPaging = true,
                AllowPaging = true,
                PageSize = this.PageSize,
                DataSource = category.Skip((this.CurrentPageIndex - 1) * this.PageSize)
            };
            // Get the total pages
            decimal decimalPages = Decimal.Divide((decimal)category.Count, (decimal)_pagedDataSource.PageSize);
            this.PageCount = (int)(Math.Ceiling(decimalPages));
            // Get the pager info
            BaseSys.GetPaginationInfo(lbPaginationInfo, this.CurrentPageIndex, this.PageCount, Properties.Resources.CategoryCount, category.Count);

            //lbPaginationInfo.Text = string.Format("{0} {1} {2} {3}", Properties.Resources.Page, this.CurrentPageIndex, Properties.Resources.Of, this.PageCount);
            this.StylePageNagiation(category.Count);

            // Fill Repeater Data from PagedDataSource
            repeaterData.DataSource = _pagedDataSource;
            repeaterData.DataBind();

            this.NavigationFor = "LoadingData";
        }
        #endregion

        #region 2. Search Keywork [Query to (category)]
        /// <summary>
        /// Search for data in xml file using both xsd dataset & LINQ techniques
        /// </summary>
        protected void LinqSearchXmlData()
        {
            category.ReadXml(xmlFile);

            // Note: using [select new] below is most important for showing them in repeater, otherwise we cannot.
            // !Important: c.Element("id") -> <name>1</name> - c.Element("id").Value -> 1 - same for active
            var cates = (from c in category
                         where c.Name.Contains(this.Keywrod) || c.Description.Contains(this.Keywrod)
                         select c).ToList();
            //select new { Id = c.Element("id").Value, Name = c.Element("name"), Description = c.Element("description"), Active = c.Element("active").Value }).ToList();

            var _pagedDataSource = new PagedDataSource
            {
                AllowCustomPaging = true,
                AllowPaging = true,
                PageSize = this.PageSize,
                DataSource = category.Skip((this.CurrentPageIndex - 1) * this.PageSize)
            };

            decimal decimalPages = Decimal.Divide((decimal)category.Count, (decimal)_pagedDataSource.PageSize);
            this.PageCount = (int)(Math.Ceiling(decimalPages));
            // Get the pager info
            BaseSys.GetPaginationInfo(lbPaginationInfo, this.CurrentPageIndex, this.PageCount, Properties.Resources.Search, category.Count);

            this.StylePageNagiation(category.Count);

            // Fill Repeater Data from PagedDataSource
            repeaterData.DataSource = _pagedDataSource;
            repeaterData.DataBind();

            // navibation pager will work for the following
            this.NavigationFor = "Search";

        }
        #endregion

        #region 3. Delete Data [Query to (category)]
        /// <summary>
        /// Delete data from xml file using LINQ techniques
        /// </summary>
        /// <returns></returns>
        protected bool LinqDeleteXmlData(bool multi = false)
        {
            // category.ReadXml(xmlFile);
            XDocument xmlDoc = XDocument.Load(xmlFile);

            if (multi == true)
            {
                xmlDoc.Element("DocumentElement").Elements("Category").Where(c => c.Element("Id").Value.Trim() == this.CategoryID.ToString() && c.Element("ImagePath").Value == string.Empty).Remove();
                try
                {
                    xmlDoc.Save(xmlFile); return true;
                }
                catch { return false; }
            }
            else
            {
                category.ReadXml(xmlFile);
                var cateRow = (from c in category where c.Id == this.CategoryID select c).First();
                this.ImagePath = cateRow.ImagePath;
                xmlDoc.Element("DocumentElement").Elements("Category").Where(c => c.Element("Id").Value.Trim() == this.CategoryID.ToString()).Remove();
                try
                {
                    xmlDoc.Save(xmlFile); return true;
                }
                catch { return false; }
            }
        }
        #endregion

        #region 4. Active Data [Query to (category)]
        /// <summary>
        /// Active data using LINQ techniques
        /// </summary>
        /// <returns></returns>
        protected bool LinqActiveXmlData(bool action)
        {
            category.ReadXml(xmlFile);
            var cateRow = (from c in category where c.Id == this.CategoryID select c).First();
            cateRow.Active = action;
            try
            {
                category.AcceptChanges();
                category.WriteXml(xmlFile);
                return true;
            }
            catch { return false; }
        }
        #endregion

        #endregion

        #region Part 6: Mukhtar Methods Area
        // Initialize the box
        public void InitializeShowBox()
        {
            xmlFile = BaseSys.GetXmlFilePath("Category.xml");

            this.GetDataFromXml();
            this.LinqFetchXmlData();
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
                return longText.Substring(0, 36);
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
                imgBtnFirst.CssClass = "nav_ImagePath first_ds";
                // Previous Button
                imgBtnPrevious.Enabled = false;
                imgBtnPrevious.CssClass = "nav_ImagePath prev_ds";
            }
            else
            {
                // First Button
                imgBtnFirst.Enabled = true;
                imgBtnFirst.CssClass = "nav_ImagePath first_en";
                // Previous Button
                imgBtnPrevious.Enabled = true;
                imgBtnPrevious.CssClass = "nav_ImagePath prev_en";
            }

            // Disable First/Previous buttons if necessary
            if (this.CurrentPageIndex == this.PageCount || recordCount == 0)
            {
                // Next Button
                imgBtnNext.Enabled = false;
                imgBtnNext.CssClass = "nav_ImagePath next_ds";
                // Last Button
                imgBtnLast.Enabled = false;
                imgBtnLast.CssClass = "nav_ImagePath last_ds";
            }
            else
            {
                // Next Button
                imgBtnNext.Enabled = true;
                imgBtnNext.CssClass = "nav_ImagePath next_en";
                // Last Button
                imgBtnLast.Enabled = true;
                imgBtnLast.CssClass = "nav_ImagePath last_en";
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
                this.LinqFetchXmlData();
            else if (this.NavigationFor == "Search")
                this.LinqSearchXmlData();
        }


        #endregion

    }// end class
}// end NS