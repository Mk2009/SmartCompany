using System;
using System.Linq;
using System.Web.UI.WebControls;
using SmartCompany.Properties;
using SmartCompany.Admin.Shared.Code;
using MukhtarMA.SmartWeb.Security;

namespace SmartCompany.Admin.Smart.Components.Membership
{
    public partial class EntryUser : System.Web.UI.UserControl
    {
        protected static SmartCompanyDataContext smartDb = new SmartCompanyDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #region Part 3: Mukhtar Properties Area
        /// <summary>
        /// Determine if this for add new reocrd or just edit current
        /// </summary>
        protected bool AddNew
        {
            get
            {
                object obj = this.ViewState["AddNew"];
                if (obj == null)
                    return false; // Default value
                else
                    return (bool)obj;
            }
            set
            {
                this.ViewState["AddNew"] = value;
            }
        }
        /// <summary>
        /// Determine if this for add new reocrd or just edit current
        /// </summary>
        public bool ItsManager
        {
            get
            {
                object obj = this.ViewState["ItsManager"];
                if (obj == null)
                    return false; // Default value
                else
                    return (bool)obj;
            }
            set
            {
                this.ViewState["ItsManager"] = value;
            }
        }

        // Get the Service id for update a row
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
        /// <summary>
        /// For checking found data 
        /// </summary>
        protected bool Found
        {
            get
            {
                object obj = this.ViewState["Found"];
                if (obj == null)
                    return false; // Default value
                else
                    return (bool)obj;
            }
            set
            {
                this.ViewState["Found"] = value;
            }
        }

        #region Form Entry Fields
        private string UserName
        {
            get { return txtUserName.Text.Trim(); }
        }
        // Encrypted Password
        private string Password
        {
            get { return MaSecurity.Encrypt(MaSecurity.EncryptionKey, txtPassword.Text, true); }
        }
        private string Email
        {
            get { return txtEmail.Text.Trim(); }
        }
        private string FirstName
        {
            get { return txtFirstName.Text.Trim(); }
        }
        private string LastName
        {
            get { return txtLastName.Text.Trim(); }
        }
        private string Mobile
        {
            get { return txtMobile.Text.Trim(); }
        }

        private byte PrivilegeID
        {
            get { return byte.Parse(ddlPrivilege.SelectedValue); }
        }
        private bool Active
        {
            get { return bool.Parse(ddlActive.SelectedValue); }
        }
        #endregion

        #endregion

        #region Part 4: Mukhtar Save Button Click Event Controller Area
        // Save Button
        protected void btnSave_Click(object sender, EventArgs e)
        {
            msgPanel.Visible = false;
            string successMsg = string.Format("{0} <b>{1}</b> {2}", Properties.Resources.Save, this.UserName, Properties.Resources.Successfully);
            bool action = false;

            if (Page.IsValid)
            {
                if (this.AddNew == true)
                    action = this.LinqInsertData();
                else
                    action = this.LinqUpdateData();

                // Check Saving data..
                if (this.Found == true)
                    BaseSys.ShowMsg(msgPanel, lbMsg, Properties.Resources.Found, "error");
                else
                {
                    if (action == true)
                    {
                        if (this.ItsManager) this.ShowLoginBox();
                        else
                            BaseSys.ShowMsg(msgPanel, lbMsg, successMsg, "ok");
                    }
                    else
                        BaseSys.ShowMsg(msgPanel, lbMsg, Properties.Resources.Failure, "error");
                }

            }
            else { BaseSys.ShowMsg(msgPanel, lbMsg, Properties.Resources.FailureValid, "error"); }

        }
        #endregion

        #region Part 5: Mukhtar LINQ Methods Controller Area

        /// <summary>
        /// Insert news Data using LINQ techniques
        /// </summary>
        /// <returns></returns>
        protected bool LinqInsertData()
        {
            // Send  all values of course to  InsertCourse() storedprocedure
            //this.NewsID = smartDb.
            this.UserID = smartDb.InsertSysUser
            (
                this.UserName,
                this.Password,
                this.Email,
                this.PrivilegeID,
                this.FirstName,
                this.LastName,
                this.Mobile,
                DateTime.Now,
                this.Active
            );

            // Check if the data is already found
            if (this.UserID == 0) this.Found = true; else this.Found = false;

            try
            {
                smartDb.SubmitChanges(); return true; // Save data and return true
            }
            catch { return false; }

        }

        /// <summary>
        /// Update Data using LINQ techniques
        /// </summary>
        /// <returns></returns>
        protected bool LinqUpdateData()
        {
            SysUser user = (from u in smartDb.SysUsers where u.Id == this.UserID select u).First();

            user.UserName = this.UserName;
            user.Email = this.Email;
            user.Privilege_Id = this.PrivilegeID;
            user.FirstName = this.FirstName;
            user.LastName = this.LastName;
            user.Mobile = this.Mobile;
            user.Active = this.Active;

            try
            {
                smartDb.SubmitChanges(); return true; // Save data and return true
            }
            catch { return false; }

        }

        /// <summary>
        /// Just I need to get one row from db - I need this for both edit and show details
        /// </summary>
        protected void LinqFetchRowData()
        {
            SysUser user = (from u in smartDb.SysUsers where u.Id == this.UserID select u).First();

            txtUserName.Text = user.UserName;
            txtEmail.Text = user.Email;
            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            txtMobile.Text = user.Mobile;

            ddlPrivilege.ClearSelection();
            ddlPrivilege.Items.FindByValue(user.Privilege_Id.ToString()).Selected = true;

            ddlActive.ClearSelection();
            ddlActive.Items.FindByValue(user.Active.ToString()).Selected = true;

            lbBoxTitle.Text = string.Format("{0} - {1}", Properties.Resources.UserEntry, Properties.Resources.Edit);
        }

        #endregion

        #region Part 6: Other Methods Controller
        // Initialize the box for new data or just edit existed data
        public void InitializeBox(bool newData)
        {
            this.AddNew = newData;
            SharedLinq.LinqFetchPrivilege(ddlPrivilege);
            msgPanel.Visible = false;

            if (this.ItsManager == true)
            {
                ddlPrivilege.SelectedIndex = 0; ddlPrivilege.Enabled = false;
                ddlActive.Enabled = false;
            }
            else
            {
                ddlPrivilege.Items.Insert(0, new ListItem(Properties.Resources.SelectOne, "0"));
                ddlPrivilege.Enabled = true; ddlActive.Enabled = true;
            }

            if (newData == false)
            {
                this.LinqFetchRowData();
                RFvPassword.Enabled = false;
                RFvRePassword.Enabled = false;
            }
            else
            {
                BaseSys.ClearPanelControl(addPanel);
                lbBoxTitle.Text = string.Format("{0} - {1}", Properties.Resources.UserEntry, Properties.Resources.New);
            }
        }

        // Show the login user for manager login - I need this the first time after registration
        private void ShowLoginBox()
        {
            LoginUser mwcLoginUser = (LoginUser)Parent.FindControl("mwcLoginUser");
            mwcLoginUser.Visible = true;
            this.Visible = false;
        }
        #endregion

    }// end class
}// end NS