using System;
using System.Linq;
using System.Web.UI.WebControls;
using SmartCompany.Properties;
using SmartCompany.Admin.Shared.Code;

namespace SmartCompany.View.Side
{
    public partial class ServiceList : System.Web.UI.UserControl
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
        protected void LinqFetchServiceData()
        {
            var list = smartDb.SelectSideServiceList(BaseSys.CurrentCulture).ToList();

            repeaterData.DataSource = list;
            repeaterData.DataBind();

            lbBoxTitle.Text = Properties.Resources.OurServices;
            hlnkMore.Text = Properties.Resources.MoreServices;
        }
        #endregion

        #region Part 3: Mukhtar Methods Controller Area and repeaterData_ItemDataBound Event
        // Set only some long text on repeater column to save nice design view
        public string SetSomeLongText(string longText)
        {
            if (longText.Length >= 100)
            {
                return longText.Substring(0, 100);
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
                if (hFiedlDesc.Value.Length >= 100)
                    hLnkTitle.Visible = true;
                else
                    lbTitle.Visible = true;
            }
        }
        #endregion

    }// end class
}// end NS