using System;
using System.Web.UI.WebControls;
using SmartCompany.Admin.Shared.Code;

namespace SmartCompany
{
    public partial class OurBusiness : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                this.InitializeBusiness();
        }

        // Change IPhone Menu Nav.
        private void MasterLabelControl(string menuName)
        {
            Label lbHomeNav = (Label)Master.FindControl("lbHomeNav");
            lbHomeNav.Text = menuName;
        }

        private void InitializeBusiness()
        {
            string menu = Properties.Resources.OurBusiness;
            Properties.Settings.Default["MenuNavigation"] = menu;
            this.MasterLabelControl(menu);
            SharedLinq.LinqCountVisitor("Business");

            Page.Title = string.Format("{0} - {1}", Properties.Resources.MainTitle, Properties.Resources.OurBusiness);
        }


    }// end calss
}// end NS