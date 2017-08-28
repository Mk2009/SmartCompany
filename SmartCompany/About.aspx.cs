using System;
using System.Web;
using System.IO;
using SmartCompany.App_Data;
using System.Web.UI.WebControls;
using SmartCompany.Admin.Shared.Code;

namespace SmartCompany
{
    public partial class About : System.Web.UI.Page
    {
        // Connect to xml DataSet to get data from [Home]
        Company.AboutDataTable about = new Company.AboutDataTable();
        Company.AboutRow row;

        // Page_PreInit: Get the selected theme from setting
        protected void Page_PreInit(object sender, EventArgs e)
        {
            MasterPageFile = "~/Default.Master";
            Page.Theme = Properties.Settings.Default.WebsiteTheme;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                this.InitializeAbout();
        }

        #region Part 2: Mukhtar XML Methods Controller Area
        // Fetch row data from xml using xml dataset
        protected void XmlFetchRowData()
        {
            string xmlFile = BaseSys.GetXmlFilePath("About.xml");

            if (File.Exists(xmlFile))
            {
                // Get data from xml file
                about.ReadXml(xmlFile);
                row = (Company.AboutRow)about.Rows[0];
                lbWhoAreWe.Text = row.WhoAreWe;
                lbManager.Text = string.Format("{0}: {1}", Properties.Resources.Manager, row.Manager);
                lbProfile.Text = row.Profile;
            }
        }

        #endregion

        // Change IPhone Menu Nav.
        private void MasterLabelControl(string menuName)
        {
            Label lbHomeNav = (Label)Master.FindControl("lbHomeNav");
            lbHomeNav.Text = menuName;
        }

        private void InitializeAbout()
        {
            string menu = Properties.Resources.About;
            Properties.Settings.Default["MenuNavigation"] = menu;
            this.MasterLabelControl(menu);

            this.XmlFetchRowData();
            SharedLinq.LinqCountVisitor("About");

            lbMainTitle.Text = Properties.Resources.WhoAreWe;
            lbProfileTitle.Text = Properties.Resources.OurProfile;

            Page.Title = string.Format("{0} - {1}", Properties.Resources.MainTitle, Properties.Resources.About);
        }


    }// end class
}// end NS