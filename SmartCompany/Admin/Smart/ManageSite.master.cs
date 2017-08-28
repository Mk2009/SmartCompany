using System;
using SmartCompany.Admin.Shared.Code;

namespace SmartCompany.Admin.Smart
{
    public partial class ManageSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (BaseSys.LogInControlPanel == true)
            {
                if (IsPostBack == false)
                {
                    //html.Attributes["dir"] = Properties.Resources.Dir;
                    //string cssFile = string.Format("~/App_Themes/Admin/{0}", Properties.Resources.CssFile);
                    //dirCss.Attributes["href"] = cssFile;
                    //lbCopyright.Text = Properties.Resources.Copyright;
                    //this.InitializePrintPage();
                }
            }
            else
            {
                Response.Redirect("~/Admin/Login.aspx");
            }

        }
    }
}