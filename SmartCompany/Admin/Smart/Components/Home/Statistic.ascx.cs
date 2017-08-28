using System;
using System.Linq;
using SmartCompany.Properties;
using SmartCompany.App_Data;
using SmartCompany.Admin.Shared.Code;

namespace SmartCompany.Admin.Smart.Components.Home
{
    public partial class Statistic : System.Web.UI.UserControl
    {
        protected static SmartCompanyDataContext smartDb = new SmartCompanyDataContext();
        Company.CategoryDataTable category = new Company.CategoryDataTable();
        string xmlFile = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            xmlFile = BaseSys.GetXmlFilePath("Category.xml"); // !Important - Multilingual resource
            if (!IsPostBack)
                this.LinqCountDataComponent();
        }

        #region Part 2: Mukhtar LINQ Method Controller Area
        // Count the component of website
        protected void LinqCountDataComponent()
        {
            // Content Info.
            lbContentAll.Text = smartDb.Services.Count().ToString();
            lbContentActive.Text = smartDb.Services.Count(c => c.Show).ToString();
            lbContentNotAct.Text = smartDb.Services.Count(c => !c.Show).ToString();

            // Category Info.
            category.ReadXml(xmlFile);
            lbCategoryAll.Text = category.Count.ToString();
            lbCategoryActive.Text = category.Count(c => c.Active).ToString();
            lbCategoryNotAct.Text = category.Count(c => !c.Active).ToString();

            // Service Info.
            lbServiceAll.Text = smartDb.Services.Count(c => c.ItsService == true).ToString();
            lbServiceActive.Text = this.LinqCountNewsService(true, true).ToString();
            lbServiceNotAct.Text = this.LinqCountNewsService(true, false).ToString();

            // News Info.
            lbNewsAll.Text = smartDb.Services.Count(c => c.ItsService == false).ToString();
            lbNewsActive.Text = this.LinqCountNewsService(false, true).ToString();
            lbNewsNotAct.Text = this.LinqCountNewsService(false, false).ToString();

            // Users Info.
            lbUsersAll.Text = smartDb.SysUsers.Count().ToString();
            lbUsersActive.Text = smartDb.SysUsers.Count(u => u.Active).ToString();
            lbUsersNotAct.Text = smartDb.SysUsers.Count(u => !u.Active).ToString();

            // Contacts Info.
            lbContactsAll.Text = smartDb.ContactUs.Count().ToString();
            lbContactsActive.Text = "-";
            lbContactsNotAct.Text = "-";
        }
        // Count the specific data
        protected int LinqCountNewsService(bool itService, bool show)
        {
            int count = (from s in smartDb.Services where s.ItsService == itService && s.Show == show select s).Count();

            return count;
        }
        #endregion

    }// end class
}// end NS