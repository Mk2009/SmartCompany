using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartCompany.Properties;
using System.Drawing;

namespace SmartCompany.Admin.Smart.Components.Membership
{
    public partial class DetailUser : System.Web.UI.UserControl
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
                        where u.Id == this.UserID
                        select new { u.Id, u.UserName, u.Email, u.FirstName, u.LastName, u.Mobile, u.Active, Privilege = p.Name, u.JoinDate }).First();

            // For Edit Purpose
            imgBtnEditDet.CommandArgument = user.Id.ToString();
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

            lbDoneBy.Text = user.JoinDate.ToString();
        }
        #endregion

        #region Part 4. Edit & NewUser Icons Buttons Click Event

        // Edit Icon 
        protected void imgBtnEditDet_Click(object sender, ImageClickEventArgs e)
        {
            EntryUser mwcEntry = (EntryUser)Parent.FindControl("mwcEntry");
            mwcEntry.UserID = Convert.ToInt32(imgBtnEditDet.CommandArgument);
            mwcEntry.InitializeBox(false);
            this.HideMukhtarWebUIPanels();
            mwcEntry.Visible = true;
            this.BtnNewActionManner("SHOW");
        }
        #endregion

        #region Part 5: Mukhtar Methods Area
        // Hide all Mukhtar web UI Panels
        private void HideMukhtarWebUIPanels()
        {
            Parent.FindControl("mwcEntry").Visible = false;
            Parent.FindControl("mwcShow").Visible = false;
            Parent.FindControl("mwcDetail").Visible = false;
        }
        // I need to change the btnNew action of the page
        private void BtnNewActionManner(string manner)
        {
            Button btnNew = (Button)Parent.FindControl("btnNew");
            btnNew.CommandName = manner;
            btnNew.Text = Properties.Resources.ShowData;
        }

        #endregion

    }// end class
}// end NS