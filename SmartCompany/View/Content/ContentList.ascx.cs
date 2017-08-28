using System;
using System.Linq;
using System.Web.UI.WebControls;
using SmartCompany.Properties;
using SmartCompany.Admin.Shared.Code;

namespace SmartCompany.View.Content
{
    public partial class ContentList : System.Web.UI.UserControl
    {
        protected static SmartCompanyDataContext smartDb = new SmartCompanyDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #region Part 2: Mukhtar LINQ Methods Controller Area
        /// <summary>
        /// Fetch company services
        /// </summary>
        public void LinqFetchServiceData()
        {
            var list = smartDb.SelectContentList(BaseSys.CurrentCulture, true).ToList();
            // Declare paged data source for pagging in repeater
            var _pagedDataSource = new PagedDataSource
            {
                AllowCustomPaging = true,
                AllowPaging = true,
                PageSize = this.PageSize,
                DataSource = list.Skip((CurrentPageIndex - 1) * this.PageSize)
            };
            // Get the total pages
            decimal decimalPages = Decimal.Divide((decimal)list.Count, (decimal)_pagedDataSource.PageSize);
            this.PageCount = (int)(Math.Ceiling(decimalPages));

            this.StylePageNagiation(list.Count);

            repeaterData.DataSource = _pagedDataSource;
            repeaterData.DataBind();

            this.NavigationFor = "LoadingData";
        }
        /// <summary>
        /// Fetch company news and activities
        /// </summary>
        public void LinqFetchNewsData()
        {
            var list = smartDb.SelectContentList(BaseSys.CurrentCulture, false).ToList();
            // Declare paged data source for pagging in repeater
            var _pagedDataSource = new PagedDataSource
            {
                AllowCustomPaging = true,
                AllowPaging = true,
                PageSize = this.PageSize,
                DataSource = list.Skip((CurrentPageIndex - 1) * this.PageSize)
            };
            // Get the total pages
            decimal decimalPages = Decimal.Divide((decimal)list.Count, (decimal)_pagedDataSource.PageSize);
            this.PageCount = (int)(Math.Ceiling(decimalPages));

            this.StylePageNagiation(list.Count);

            repeaterData.DataSource = _pagedDataSource;
            repeaterData.DataBind();

            this.NavigationFor = "LoadingData";
        }

        #endregion

        #region Part 3: Mukhtar Methods Controller Area and repeaterData_ItemDataBound Event
        // Show image if has path in db
        public string SetImagePath(string path)
        {
            if (string.IsNullOrEmpty(path))
                return string.Empty;
            else
                return path;//.Replace("~/", "");
        }
        // Set only some long text on repeater column to save nice design view
        public string SetSomeLongText(string longText)
        {
            if (longText.Length > 280)
            {
                return longText.Substring(0, 280);
            }
            else { return longText; }
        }

        // Check the total max of description to show link for long text instead of normal label
        protected void repeaterData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lbTitle = (Label)e.Item.FindControl("lbTitle");
                HyperLink hLnkTitle = (HyperLink)e.Item.FindControl("hLnkTitle");
                HiddenField hFiedlDesc = (HiddenField)e.Item.FindControl("hFiedlDesc");

                lbTitle.Visible = false; hLnkTitle.Visible = false;
                if (hFiedlDesc.Value.Length >= 280)
                    hLnkTitle.Visible = true;
                else
                    lbTitle.Visible = true;
            }
        }
        #endregion

        #region Part 4: Pagination [ Previous - Next ]Area

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
        /// WebSite Page Size
        /// </summary>
        protected int PageSize
        {
            get { return Properties.Settings.Default.WebSitePageSize; }
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
            // Disable Previous buttons if necessary
            if (this.CurrentPageIndex == 1)
                lnkBtnPrevious.Visible = false;
            else
                lnkBtnPrevious.Visible = true;

            // Disable Next buttons if necessary
            if (this.CurrentPageIndex == this.PageCount || recordCount == 0)
                lnkBtnNext.Visible = false;
            else
                lnkBtnNext.Visible = true;
        }

        // Previous Link
        protected void lnkBtnPrevious_Click(object sender, EventArgs e)
        {
            this.CurrentPageIndex -= 1;
            this.LoadingDataManner();
        }
        // Next Link
        protected void lnkBtnNext_Click(object sender, EventArgs e)
        {
            this.CurrentPageIndex += 1;
            this.LoadingDataManner();
        }

        // Get type fo data for
        private void LoadingDataManner()
        {
            if (this.NavigationFor == "LoadingData")
                this.LinqFetchServiceData();
            //else if (this.NavigationFor == "Search")
            //    this.LinqSearchData(txtSearch.Text);
        }


        #endregion


    }// end class
}// end NS