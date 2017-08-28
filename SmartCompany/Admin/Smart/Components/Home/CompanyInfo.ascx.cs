using System;
using SmartCompany.Admin.Shared.Code;
using SmartCompany.App_Data;
using System.IO;

namespace SmartCompany.Admin.Smart.Components.Home
{
    public partial class CompanyInfo : System.Web.UI.UserControl
    {
        // Connect to xml DataSet to get data from [Home]
        Company.HomeDataTable home = new Company.HomeDataTable();
        Company.HomeRow row;
        string xmlFile = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            xmlFile = BaseSys.GetXmlFilePath("Home.xml"); // !Important - Multilingual resource
            if (!IsPostBack)
                this.XmlFetchRowData();
        }


        #region Part 2: Mukhtar XML Methods Controller Area
        // Fetch row data from xml using xml dataset
        protected void XmlFetchRowData()
        {
            if (File.Exists(this.xmlFile))
            {
                // Get data from xml file
                home.ReadXml(this.xmlFile);
                row = (Company.HomeRow)home.Rows[0];
                txtTitle.Text = row.Title;
                txtInformation.Text = row.Information;
                txtVision.Text = row.Vision;
                txtMission.Text = row.Mission;
            }
            else
            {
                BaseSys.ShowMsg(msgPanel, lbMsg, Properties.Resources.XmlFileNotFound, "error");
            }
        }

        // Save new data to xml file using xml dataset techniques
        protected bool XmlSaveData()
        {
            home.ReadXml(this.xmlFile);
            row = (Company.HomeRow)home.Rows[0];
            row.Title = txtTitle.Text;
            row.Information = txtInformation.Text;
            row.Vision = txtVision.Text;
            row.Mission = txtMission.Text;

            try
            {
                home.AcceptChanges();
                home.WriteXml(this.xmlFile);
                return true;
            }
            catch { return false; }
        }

        #endregion

        #region Part 3: Mukhtar Save Button Click Event Controller Area
        // Save Button
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (File.Exists(this.xmlFile))
            {
                if (Page.IsValid)
                {
                    bool action = this.XmlSaveData();

                    if (action == true)
                        BaseSys.ShowMsg(msgPanel, lbMsg, Properties.Resources.Success, "ok");
                    else
                        BaseSys.ShowMsg(msgPanel, lbMsg, Properties.Resources.Failure, "error");
                }
                else { BaseSys.ShowMsg(msgPanel, lbMsg, Properties.Resources.FailureValid, "error"); }
            }
            else { BaseSys.ShowMsg(msgPanel, lbMsg, Properties.Resources.XmlFileNotFound, "error"); }
        }
        #endregion


    }// end class
}// end NS