using System;
using System.Linq;
using SmartCompany.Properties;
using SmartCompany.Admin.Shared.Code;

namespace SmartCompany.Admin.Smart.Components.Home
{
    public partial class Counter : System.Web.UI.UserControl
    {
        // Declare my system database context = LINQ
        protected static SmartCompanyDataContext smartDb = new SmartCompanyDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                this.LinFetchCounterData();
            }
        }

        #region Part 1: Mukhtar LINQ Methods Controller Area
        /// <summary>
        /// Fetch Data LINQ techniques
        /// </summary>
        public void LinFetchCounterData()
        {
            var visitor = (from v in smartDb.Visitors
                           join p in smartDb.VisitorPages on v.Id equals p.Visitor_Id
                           where p.Language == BaseSys.CurrentCulture
                           select new { p.TitlePage, v.Day, v.Week, v.Month, v.Year, v.AllVisitor });

            // Fill Repeater with data
            repeaterCounterData.DataSource = visitor;
            repeaterCounterData.DataBind();
        }
        #endregion

    }// end class
}// end NS