using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartCompany.Properties;
using System.Drawing;
using SmartCompany.Admin.Shared.Code;

namespace SmartCompany.Admin.Smart.Components.Membership
{
    public partial class CurrentUser : System.Web.UI.UserControl
    {
        protected static SmartCompanyDataContext smartDb = new SmartCompanyDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// Set or Get the Service id
        /// </summary>
        public int UserID
        {
            get
            {
                object obj = this.ViewState["UserID"];
                if (obj == null)
                    return 0; // Default value
                else
                    return (int)obj;
            }
            set
            {
                this.ViewState["UserID"] = value;
            }
        }


        #region Part 3: Mukhtar LINQ Methods Controller Area
        /// <summary>
        /// Fetch row data using LINQ techniques
        /// </summary>
        public void LinqFetchRowData()
        {
            var user = (from u in smartDb.SysUsers
                        join p in smartDb.Privileges on u.Privilege_Id equals p.Id
                        where u.Id == BaseSys.SysUserID
                        select new { u.Id, u.UserName, u.Email, u.FirstName, u.LastName, u.Mobile, u.Active, Privilege = p.Name, u.JoinDate }).First();

            // Matches data to controls
            lbUserName.Text = user.UserName;
            lbEmail.Text = user.Email;
            lbName.Text = string.Format("{0} {1}", user.FirstName, user.LastName);
            lbMobile.Text = user.Mobile;
            lbPrivilege.Text = user.Privilege;

            // Active
            if (user.Active == true)
            {
                lbActive.Text = Properties.Resources.Yes; lbActive.ForeColor = Color.Green;
            }
            else
            {
                lbActive.Text = Properties.Resources.No; lbActive.ForeColor = Color.Red;
            }

            //lbDoneBy.Text = user.JoinDate.ToString();
        }
        #endregion

    }// end class
}// end NS