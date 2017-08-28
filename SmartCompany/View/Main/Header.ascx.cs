using System;
using SmartCompany.Admin.Shared.Code;
using System.Threading;

namespace SmartCompany.View.Main
{
    public partial class Header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SharedLinq.XmlFetchLanguage(ddlLanguage);
                ddlLanguage.ClearSelection();
                ddlLanguage.Items.FindByValue(this.CultureInfo).Selected = true;
                txtSearch.ToolTip = Properties.Resources.SearchToolTip;
                imgLogo.ImageUrl = string.Format("~/App_Themes/Default/Images/{0}", Properties.Resources.LogoImage);
            }
        }

        #region 1. Mukhtar Change Language Controller Area
        protected string CultureInfo
        {
            get
            {
                if (Request.Cookies["CultureInfo"] == null)
                    return Properties.Settings.Default.CurrentCulture;
                else
                    return Request.Cookies["CultureInfo"].Value;
            }
        }

        // Change Langauge
        protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string culture = ddlLanguage.SelectedValue;

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);
            this.SaveLanguaeInCookies(culture);
            Response.Redirect("Default.aspx");
        }

        // Save selected lang in cookies for future use
        private void SaveLanguaeInCookies(string uiCulture)
        {
            Response.Cookies["CultureInfo"].Value = uiCulture;
            Response.Cookies["CultureInfo"].Expires = DateTime.Now.AddDays(14);
        }
        #endregion

    }// end class
}// end NS