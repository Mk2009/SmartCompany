using System;
using System.Web;
using SmartCompany.App_Data;
using System.IO;
using System.Web.UI.WebControls;
using SmartCompany.Admin.Shared.Code;

namespace SmartCompany
{
    public partial class ContactUs : System.Web.UI.Page
    {
        // Connect to xml DataSet to get data from
        // ContactUs table
        Company.ContactUsDataTable contact = new Company.ContactUsDataTable();
        Company.ContactUsRow row;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                this.InitializeContactUs();
        }

        #region Part 2: Mukhtar XML Methods Controller Area
        // Fetch row data from xml using xml dataset
        protected void XmlFetchRowData()
        {
            string xmlFile = BaseSys.GetXmlFilePath("Contact.xml");

            if (File.Exists(xmlFile))
            {
                // Get data from xml file
                contact.ReadXml(xmlFile);
                row = (Company.ContactUsRow)contact.Rows[0];

                lbContact.Text = string.Format("{0}: {1} | {2}: {3}", Properties.Resources.Phone, row.Phone, Properties.Resources.Fax, row.Fax);
                lbMobile.Text = string.Format("{0}: {1}", Properties.Resources.Mobile, row.Mobile);
                lbEmail.Text = string.Format("{0}: {1}", Properties.Resources.Email, row.Email);
                lbAddress.Text = string.Format("{0}: {1}", Properties.Resources.Address, row.Address);
            }
        }

        #endregion
        // Change IPhone Menu Nav.
        private void MasterLabelControl(string menuName)
        {
            Label lbHomeNav = (Label)Master.FindControl("lbHomeNav");
            lbHomeNav.Text = menuName;
        }

        private void InitializeContactUs()
        {
            string menu = Properties.Resources.Contact;
            Properties.Settings.Default["MenuNavigation"] = menu;
            this.MasterLabelControl(menu);

            this.XmlFetchRowData();
            SharedLinq.LinqCountVisitor("Contact");

            lbContactInfo.Text = Properties.Resources.ContactInformation;

            Page.Title = string.Format("{0} - {1}", Properties.Resources.MainTitle, Properties.Resources.Contact);
        }


    }// end class
}// end NS