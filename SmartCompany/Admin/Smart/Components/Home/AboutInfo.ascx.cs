using System;
using SmartCompany.App_Data;
using SmartCompany.Admin.Shared.Code;
using System.IO;

namespace SmartCompany.Admin.Smart.Components.Home
{
    public partial class AboutInfo : System.Web.UI.UserControl
    {
        // Connect to xml DataSet to get data from [Home]
        Company.AboutDataTable about = new Company.AboutDataTable();
        Company.AboutRow row;
        string xmlFile = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            xmlFile = BaseSys.GetXmlFilePath("About.xml"); // !Important - Multilingual resource
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
                about.ReadXml(this.xmlFile);
                row = (Company.AboutRow)about.Rows[0];
                txtWhoAreWe.Text = row.WhoAreWe;
                txtProfile.Text = row.Profile;
                txtManager.Text = row.Manager;
            }
            else
            {
                BaseSys.ShowMsg(msgPanel, lbMsg, Properties.Resources.XmlFileNotFound, "error");
            }
        }

        // Save new data to xml file using xml dataset techniques
        protected bool XmlSaveData()
        {
            about.ReadXml(this.xmlFile);
            row = (Company.AboutRow)about.Rows[0];

            row.WhoAreWe = txtWhoAreWe.Text;
            row.Profile = txtProfile.Text;
            row.Manager = txtManager.Text;

            try
            {
                about.AcceptChanges();
                about.WriteXml(this.xmlFile);
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