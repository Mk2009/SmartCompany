using System;
using System.Linq;
using SmartCompany.Properties;
using SmartCompany.Admin.Shared.Code;
using System.Drawing;

namespace SmartCompany.Admin
{
    public partial class Logout : System.Web.UI.Page
    {
        protected static SmartCompanyDataContext smartDb = new SmartCompanyDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.Title = string.Format("{0} - {1}", Properties.Resources.MainTitle, Properties.Resources.LogoutPage);
                this.LogOutUserFromSystem();
            }
        }

        #region Part 1: Mukhtar LINQ Methods Code Area [LinqUpdateLoginStatusData]
        /// <summary>
        /// Update Data using Linq Techniques - In Logout 
        /// </summary>
        /// <returns></returns>
        protected bool LinqUpdateLoginStatusData()
        {
            DateTime date = DateTime.Now;
            TimeSpan time = DateTime.Now.TimeOfDay;

            SysUserLogStatus status = (from s in smartDb.SysUserLogStatus
                                       where s.Id == BaseSys.SysUserLogStatusID
                                       select s).First();

            status.LogoutTime = time;
            status.LogoutDate = date;
            status.LogIn = false;

            try
            {
                smartDb.SubmitChanges(); return true;
            }
            catch { return false; }
        }
        #endregion

        #region Part 2: Mukhtar Methods Code Area

        // Log user out from system
        protected void LogOutUserFromSystem()
        {
            BaseSys.LogInControlPanel = false;
            BaseSys.SysUserID = 0;
            BaseSys.PrivilegeID = 0;
            try
            {
                if (this.LinqUpdateLoginStatusData() == true)
                {
                    Session.Clear();
                    Session.Abandon();
                    Session.RemoveAll();
                }
            }
            catch { }
            lbInfo.Text = Properties.Resources.LogoutMessage;
            lbInfo.ForeColor = Color.Green; 
        }

        #endregion

    }// end class
}// end NS