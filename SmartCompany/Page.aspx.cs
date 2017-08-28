using System;
using System.Linq;
using SmartCompany.Properties;
using SmartCompany.Admin.Shared.Code;

namespace SmartCompany
{
    public partial class Page : System.Web.UI.Page
    {
        protected static SmartCompanyDataContext smartDb = new SmartCompanyDataContext();

        #region Part 1: Mukhtar [Page_PreInit] - [Page_Load] Area
        // Page_PreInit: Get the selected theme from setting
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Page.Theme = Properties.Settings.Default.WebsiteTheme;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["ID"];

            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
                    this.ErrorMsg();
                else
                    this.InitializePage(id);
            }
        }
        #endregion

        #region Part 2: Mukhtar LINQ Methods Controller Area
        /// <summary>
        /// Count data found that specified to giving id
        /// </summary>
        /// <param name="id"></param>
        protected void LinqCountRows(int id)
        {
            int count = smartDb.SelectOneContent(id, BaseSys.CurrentCulture).Count();

            if (count > 0)
            {
                msgPanel.Visible = false;
                contentPanel.Visible = true;
                this.LinqFetchContent(id);
            }
        }
        /// <summary>
        /// Fetch single row data that specified to giving id
        /// </summary>
        /// <param name="id"></param>
        protected void LinqFetchContent(int id)
        {
            var content = smartDb.SelectOneContent(id, BaseSys.CurrentCulture).First();

            lbTitle.Text = content.Title;
            lbDescription.Text = content.Description;
            imgShow.ImageUrl = content.ImagePath;
            lbDate.Text = string.Format("{0}: {1}", Properties.Resources.ModifiedDate, content.ModifiedDate);

            if (content.ItsService.Value == true)
                mwcServiceSideList.Visible = true;
            else
                mwcNewsList.Visible = true;
            // Make the title as page title
            Page.Title = string.Format("{0} - {1}", Properties.Resources.MainTitle, content.Title);
        }

        #endregion

        #region  Part 3: Mukhtar Methods Controller Area
        // Initialize the page
        private void InitializePage(string id)
        {
            int number = 0;
            // the id must be a number
            bool urlParam = int.TryParse(id, out number);
            if (urlParam == true)// It's a number
                this.LinqCountRows(number);
            else // It's Not number
                this.ErrorMsg();

            Page.Title = string.Format("{0} - {1}", Properties.Resources.MainTitle, Properties.Resources.Services);
        }
        // Show error message if the data not found, 
        //or the giving url param is string or number that not found.
        private void ErrorMsg()
        {
            contentPanel.Visible = false;
            lbMsg.Text = Properties.Resources.PageNotFound;
            msgPanel.Visible = true;
        }

        #endregion


    }// end class
}// end NS