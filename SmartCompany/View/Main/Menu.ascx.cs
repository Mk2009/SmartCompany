using System;
using System.Web;
using SmartCompany.App_Data;
using System.IO;

namespace SmartCompany.View.Main
{
    public partial class Menu : System.Web.UI.UserControl
    {

        #region Part 1: DataSet Table Declaration
        // Connect to xml DataSet to get data from
        // Menu table
        Company.MenuDataTable menu = new Company.MenuDataTable();
        Company.MenuRow rowMe;
        // MenuShow table
        Company.MenuVisibleDataTable menuVisible = new Company.MenuVisibleDataTable();
        Company.MenuVisibleRow rowVs;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                this.InitializeMenu(); this.MenuFocusStyle();
        }

        #region Part 2: Mukhtar XML Methods Controller Area
        // Fetch row data from xml using xml dataset
        protected void XmlFetchRowData()
        {
            lbMsg.Visible = false;

            //if (File.Exists(this.CompanyXmlFile))
            //{
            //    // Get data from xml file
            //    menu.ReadXml(this.CompanyXmlFile);
            //    rowMe = (Company.MenuRow)menu.Rows[0];
            //    if(XmlCheckVisibleMenu(1))
            //        hlItem1.Text = rowMe.Item1;

            //    if (XmlCheckVisibleMenu(2))
            //        hlItem2.Text = rowMe.Item2;

            //    if (XmlCheckVisibleMenu(3))
            //        hlItem3.Text = rowMe.Item3;

            //    if (XmlCheckVisibleMenu(4))
            //        hlItem4.Text = rowMe.Item4;

            //    if (XmlCheckVisibleMenu(5))
            //        hlItem5.Text = rowMe.Item5;

            //    if (XmlCheckVisibleMenu(6))
            //        hlItem6.Text = rowMe.Item6;
            //}
            //else { lbMsg.Visible = true; }
        }
        // Check the row Visible
        protected bool XmlCheckVisibleMenu(byte itemNo)
        {
            //menuVisible.ReadXml(CompanyXmlFile);
            //rowVs = (Company.MenuVisibleRow)menuVisible.Rows[0];

            if (itemNo == 1)
                return rowVs.Item1;
            else if (itemNo == 2)
                return rowVs.Item2;
            else if (itemNo == 3)
                return rowVs.Item3;
            else if (itemNo == 4)
                return rowVs.Item4;
            else if (itemNo == 5)
                return rowVs.Item5;
            else if (itemNo == 6)
                return rowVs.Item6;
            else return false;
        }
        #endregion

        #region Part 3: Mukhtar Other Method [MenuFocusStyle]
        // Make style for focused menu
        private void MenuFocusStyle()
        {
            string manner = Properties.Settings.Default.MenuNavigation;
            this.HideFocusStyle();

            if (manner == "Home")
                liHome.Attributes["class"] = "active";
            else if (manner == "Our Business")
                liBusiness.Attributes["class"] = "active";
            else if (manner == "Services")
                liServices.Attributes["class"] = "active";
            else if (manner == "Our Activities")
                liNews.Attributes["class"] = "active";
            else if (manner == "About")
                liAbout.Attributes["class"] = "active";
            else if (manner == "Contact")
                liContact.Attributes["class"] = "active";
        }
        // Hide all focus styles
        private void HideFocusStyle()
        {
            liHome.Attributes["class"] = "";
            liBusiness.Attributes["class"] = "";
            liServices.Attributes["class"] = "";
            liNews.Attributes["class"] = "";
            liAbout.Attributes["class"] = "";
            liContact.Attributes["class"] = "";
        }
        #endregion

        // Initialize the menu box
        private void InitializeMenu()
        {
            hlItem1.Text = Properties.Resources.HomeMenu;
            hlItem2.Text = Properties.Resources.BusinessMenu;
            hlItem3.Text = Properties.Resources.ServiceMenu;
            hlItem4.Text = Properties.Resources.NewsMenu;
            hlItem5.Text = Properties.Resources.AboutMenu;
            hlItem6.Text = Properties.Resources.ContactMenu;
        }

    }// end class
}// end NS