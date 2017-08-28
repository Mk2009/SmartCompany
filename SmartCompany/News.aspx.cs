using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartCompany.Admin.Shared.Code;

namespace SmartCompany
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                this.InitializeNews();
        }

        // Change IPhone Menu Nav.
        private void MasterLabelControl(string menuName)
        {
            Label lbHomeNav = (Label)Master.FindControl("lbHomeNav");
            lbHomeNav.Text = menuName;
        }

        private void InitializeNews()
        {
            string menu = Properties.Resources.OurActivities;
            Properties.Settings.Default["MenuNavigation"] = menu;
            this.MasterLabelControl(menu);

            mwcContentList.LinqFetchNewsData();
            SharedLinq.LinqCountVisitor("News");

            Page.Title = string.Format("{0} - {1}", Properties.Resources.MainTitle, Properties.Resources.OurActivities);
        }


    }// end calss
}// end NS