using System;
using System.Linq;
using SmartCompany.Admin.Shared.Code;
using SmartCompany.Properties;
using System.Threading;

namespace SmartCompany.Admin.Shared.WebUI
{
    public partial class MenuBox : System.Web.UI.UserControl
    {
        protected static SmartCompanyDataContext smartDb = new SmartCompanyDataContext();

        // Best Place for setting controls properties
        protected void Page_PreRender(Object sender, EventArgs e)
        {
            this.InitializePostBackUrl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string xmlFile = BaseSys.GetXmlFilePath("Company.xml");
            if (!IsPostBack)
            {
                SharedLinq.XmlFetchLanguage(ddlLanguage);
                ddlLanguage.Items.FindByValue(this.CultureInfo).Selected = true;
                this.PrivilegedUser();

                if (BaseSys.LogInControlPanel == true)
                    this.UserInfo();
            }
        }
        // Grant the privilege to current user
        private void PrivilegedUser()
        {
            if (BaseSys.PrivilegeID == 1)// Manager
            {
                this.EnableMenuLink(true);
            }
            else if (BaseSys.PrivilegeID == 2)// Supervisor
            {
                this.EnableMenuLink(false);
                hlnkNews.Enabled = true;
                hlnkServices.Enabled = true;
            }
            else if (BaseSys.PrivilegeID == 3)// User
            {
                this.EnableMenuLink(false);
            }
        }
        // Enable / disable the current menu linke
        private void EnableMenuLink(bool enable)
        {
            // Company
            hlnkCoInfo.Enabled = enable;
            hlnkAboutCoInfo.Enabled = enable;
            hlnkCoContactInfo.Enabled = enable;
            hlnkWebsiteInfo.Enabled = enable;
            // News
            hlnkNews.Enabled = enable;
            // Services
            hlnkCategory.Enabled = enable;
            hlnkServices.Enabled = enable;
        }


        public void UserInfo()
        {
            var user = (from u in smartDb.SysUsers where u.Id == BaseSys.SysUserID select u).First();

            string name = string.Format("{0} {1}", user.FirstName, user.LastName);
            lbUserInfo.Text = string.Format("{0} {1} - {2}: {3}", Properties.Resources.WelcomeUser, name, Properties.Resources.UserName, user.UserName);
        }

        #region 1. Mukhtar Change Language Controller Area

        protected string CultureInfo
        {
            get
            {
                if (Request.Cookies["CultureInfo"] == null || Request.Cookies["CultureInfo"].Value == string.Empty)
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

            Response.Redirect("~/Admin/Smart/Default.aspx");
        }

        // Save selected lang in cookies for future use
        private void SaveLanguaeInCookies(string uiCulture)
        {
            Response.Cookies["CultureInfo"].Value = uiCulture;
            Response.Cookies["CultureInfo"].Expires = DateTime.Now.AddDays(14);
        }
        #endregion

        #region Part 2: Mukhtar PostBackUrl - Normal One

        private void InitializePostBackUrl()
        {
            hlnkDashboard.NavigateUrl = "~/Admin/Smart/Dashboard.aspx";
            hlnkCoInfo.NavigateUrl = "~/Admin/Smart/CompanyInfo.aspx";
            hlnkAboutCoInfo.NavigateUrl = "~/Admin/Smart/AboutCompany.aspx";
            hlnkCoContactInfo.NavigateUrl = "~/Admin/Smart/ContactInfo.aspx";
            hlnkWebsiteInfo.NavigateUrl = "~/Admin/Smart/WebsiteInfo.aspx";

            hlnkNews.NavigateUrl = "~/Admin/Smart/ManageNews.aspx";
            hlnkCategory.NavigateUrl = "~/Admin/Smart/ManageCategory.aspx";
            hlnkServices.NavigateUrl = "~/Admin/Smart/ManageService.aspx";

            hlnkContacts.NavigateUrl = "~/Admin/Smart/ManageContact.aspx";
            hlnkUsers.NavigateUrl = "~/Admin/Smart/ManageUser.aspx";

            imgBtnCurrent.PostBackUrl = "~/Admin/Smart/CurrentUser.aspx";
            imgBtnLogout.PostBackUrl = "~/Admin/Logout.aspx";
        }
        #endregion

    }// end class
}// end NS