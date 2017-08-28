using System;
using System.Linq;
using System.Web.UI.WebControls;
using SmartCompany.Properties;
using SmartCompany.Admin.Shared.Code;

namespace SmartCompany.View.Main
{
    public partial class SlideShow : System.Web.UI.UserControl
    {
        protected static SmartCompanyDataContext smartDb = new SmartCompanyDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                this.LinqFetchServiceData();
        }

        #region Part 2: Mukhtar LINQ Methods Controller Area
        /// <summary>
        /// Fetch company services
        /// </summary>
        public void LinqFetchServiceData()
        {
            var list = smartDb.SelectSlideService(BaseSys.CurrentCulture).ToList();

            repeaterData.DataSource = list;
            repeaterData.DataBind();
        }

        #endregion

        #region Part 3: Mukhtar Methods Controller Area and repeaterData_ItemDataBound Event
        // Set only some long text on repeater column to save nice design view
        public string SetSomeLongText(string longText)
        {
            if (longText.Length > 208)
            {
                return longText.Substring(0, 208);
            }
            else { return longText; }
        }

        // Check the total max of description to show link for long text instead of normal label
        protected void repeaterData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HyperLink hLnkTitle = (HyperLink)e.Item.FindControl("hLnkTitle");
                HiddenField hFiedlDesc = (HiddenField)e.Item.FindControl("hFiedlDesc");

                if (hFiedlDesc.Value.Length >= 208)
                    hLnkTitle.Visible = true;
                else
                    hLnkTitle.Visible = false;
            }
        }
        #endregion

    }// end class
}// end NS