using System;
using System.Web.UI.WebControls;
using SmartCompany.Admin.Shared.Code;

namespace SmartCompany
{
    public partial class Services : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                this.InitializeService();
        }

        // Change IPhone Menu Nav.
        private void MasterLabelControl(string menuName)
        {
            Label lbHomeNav = (Label)Master.FindControl("lbHomeNav");
            lbHomeNav.Text = menuName;
        }

        private void InitializeService()
        {
            string menu = Properties.Resources.Services;
            Properties.Settings.Default["MenuNavigation"] = menu;
            this.MasterLabelControl(menu);

            mwcContentList.LinqFetchServiceData();
            SharedLinq.LinqCountVisitor("Service");

            Page.Title = string.Format("{0} - {1}", Properties.Resources.MainTitle, Properties.Resources.Services);
        }



    }// end calss
}// end NS