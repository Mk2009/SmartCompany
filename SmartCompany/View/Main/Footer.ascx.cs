using System;
using SmartCompany.App_Data;
using System.IO;
using SmartCompany.Admin.Shared.Code;

namespace SmartCompany.View.Main
{
    public partial class Footer : System.Web.UI.UserControl
    {
        // Connect to xml DataSet to get data from [Website]
        Company.WebsiteDataTable website = new Company.WebsiteDataTable();
        Company.WebsiteRow row;
        string xmlFile;

        protected void Page_Load(object sender, EventArgs e)
        {
            xmlFile = BaseSys.GetXmlFilePath("Website.xml");
            if (!IsPostBack)
                this.XmlFetchRowData();
        }

        #region Part 2: Mukhtar XML Methods Controller Area
        // Fetch row data from xml using xml dataset
        protected void XmlFetchRowData()
        {
            if (File.Exists(xmlFile))
            {
                // Get data from xml file
                website.ReadXml(xmlFile);
                row = (Company.WebsiteRow)website.Rows[0];
                //Page.Title = row.Title;
                lbCopyright.Text = string.Format("{0} {1}", row.Copyright, row.Company);
                lbDoneBy.Text = string.Format("{0} {1}", Properties.Resources.DoneBy, row.WebDeveloper);
            }
        }

        #endregion



    }// end class
}// end NS