using System;

namespace SmartCompany.Admin
{
    public partial class AdminSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                html.Attributes["dir"] = Properties.Resources.Dir;
                string cssFile = string.Format("~/App_Themes/Admin/{0}", Properties.Resources.CssFile);
                dirCss.Attributes["href"] = cssFile;
                lbCopyright.Text = Properties.Resources.Copyright;
                //this.InitializePrintPage();
            }
        }

    }// end class
}// end NS