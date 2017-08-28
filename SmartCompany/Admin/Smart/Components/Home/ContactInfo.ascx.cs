using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartCompany.App_Data;
using SmartCompany.Admin.Shared.Code;
using System.IO;

namespace SmartCompany.Admin.Smart.Components.Home
{
    public partial class ContactInfo : System.Web.UI.UserControl
    {
        // Connect to xml DataSet to get data from [Home]
        Company.ContactUsDataTable home = new Company.ContactUsDataTable();
        Company.ContactUsRow row;
        string xmlFile = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            xmlFile = BaseSys.GetXmlFilePath("Contact.xml"); // !Important - Multilingual resource
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
                row = (Company.ContactUsRow)home.Rows[0];

                txtAddress.Text = row.Address;
                txtPhone.Text = row.Phone;
                txtFax.Text = row.Fax;
                txtMobile.Text = row.Mobile;
                txtEmail.Text = row.Email; 
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
            row = (Company.ContactUsRow)home.Rows[0];

            row.Address = txtAddress.Text;
            row.Phone = txtPhone.Text;
            row.Fax = txtFax.Text;
            row.Mobile = txtMobile.Text;
            row.Email = txtEmail.Text;

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