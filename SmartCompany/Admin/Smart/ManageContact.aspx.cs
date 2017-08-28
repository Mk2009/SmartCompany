using System;

namespace SmartCompany.Admin.Smart
{
    public partial class ManageContact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.Title = string.Format("{0} - {1}", Properties.Resources.MainTitle, Properties.Resources.ManageContactPage);
                lbPageTitle.Text = Properties.Resources.ManageContactPage;
            }

        }
    }
}