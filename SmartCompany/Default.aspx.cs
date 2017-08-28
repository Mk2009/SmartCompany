using System;
using SmartCompany.App_Data;
using System.IO;
using System.Web.UI.WebControls;
using SmartCompany.Admin.Shared.Code;

namespace SmartCompany
{
    public partial class Default : System.Web.UI.Page
    {
        // Connect to xml DataSet to get data from [Home]
        Company.HomeDataTable home = new Company.HomeDataTable();
        Company.HomeRow row;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                this.InitializeDefault();
        }

        #region Part 2: Mukhtar XML Methods Controller Area
        // Fetch row data from xml using xml dataset
        protected void XmlFetchRowData()
        {
            string xmlFile = BaseSys.GetXmlFilePath("Home.xml");
            if (File.Exists(xmlFile))
            {
                // Get data from xml file
                home.ReadXml(xmlFile);
                row = (Company.HomeRow)home.Rows[0];
                lbTitle.Text = row.Title;
                lbInformation.Text = row.Information;
                lbVision.Text = row.Vision;
                lbMission.Text = row.Mission;
            }
        }

        #endregion

        // Change IPhone Menu Nav.
        private void MasterLabelControl(string menuName)
        {
            Label lbHomeNav = (Label)Master.FindControl("lbHomeNav");
            lbHomeNav.Text = menuName;
        }

        private void InitializeDefault()
        {
            Master.FindControl("mwcSlideShow").Visible = true;
            string menu = Properties.Resources.Home;
            Properties.Settings.Default["MenuNavigation"] = menu;
            this.MasterLabelControl(menu);
            this.XmlFetchRowData();
            SharedLinq.LinqCountVisitor("Home");

            lbMainTitle.Text = Properties.Resources.OurCompany;
            lbVisionTitle.Text = Properties.Resources.OurVision;
            lbMissionTitle.Text = Properties.Resources.OurMission;

            Page.Title = string.Format("{0} - {1}", Properties.Resources.MainTitle, Properties.Resources.Home);

            TextBox1.Text = MukhtarMA.SmartWeb.Security.MaSecurity.Encrypt(MukhtarMA.SmartWeb.Security.MaSecurity.EncryptionKey, "ugnhggi1430", true);
        }

    }// end class
}// end NS