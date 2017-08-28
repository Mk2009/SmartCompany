using System;
using System.Web;
using SmartCompany.App_Data;
using System.IO;
using SmartCompany.Admin.Shared.Code;

namespace SmartCompany.View.Content
{
    public partial class StackholderList : System.Web.UI.UserControl
    {
        // Connect to xml DataSet to get data from [Category]
        Company.StockholderDataTable holder = new Company.StockholderDataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //    this.XmlFetchData();
        }

        #region Part 2: Mukhtar XML Methods Controller Area
        /// <summary>
        /// Fetch company services
        /// </summary>
        public void XmlFetchData()
        {
            string xmlFile = BaseSys.GetXmlFilePath("");
            if (File.Exists(xmlFile))
            {
                holder.ReadXml(xmlFile);

                repeaterData.DataSource = holder;
                repeaterData.DataBind();
            }
        }

        #endregion

    }// end class
}// end NS