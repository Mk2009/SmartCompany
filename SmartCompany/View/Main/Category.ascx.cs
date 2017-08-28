using System;
using System.Linq;
using System.Web.UI.WebControls;
using SmartCompany.App_Data;
using System.IO;
using SmartCompany.Admin.Shared.Code;

namespace SmartCompany.View.Main
{
    public partial class Category : System.Web.UI.UserControl
    {
        // Connect to xml DataSet to get data from [Category]
        Company.CategoryDataTable category = new Company.CategoryDataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                this.XmlFetchData();
        }

        #region Part 2: Mukhtar XML Methods Controller Area
        /// <summary>
        /// Fetch company categories
        /// </summary>
        public void XmlFetchData()
        {
            string xmlFile = BaseSys.GetXmlFilePath("Category.xml");
            if (File.Exists(xmlFile))
            {
                category.ReadXml(xmlFile);

                repeaterData.DataSource = category.Take(3);
                repeaterData.DataBind();
            }
        }

        #endregion

        #region Part 3: Mukhtar Methods Controller Area and repeaterData_ItemDataBound Event
        // Set only some long text on repeater column to save nice design view
        public string SetSomeLongText(string longText)
        {
            if (longText.Length > 75)
            {
                return longText.Substring(0, 75);
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

                if (hFiedlDesc.Value.Length >= 75)
                    hLnkTitle.Visible = true;
                else
                    hLnkTitle.Visible = false;
            }
        }
        #endregion


    }// end class
}// end NS