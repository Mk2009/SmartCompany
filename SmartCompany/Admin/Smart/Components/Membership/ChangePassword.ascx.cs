using System;
using MukhtarMA.SmartWeb.Security;
using SmartCompany.Properties;
using SmartCompany.Admin.Shared.Code;

namespace SmartCompany.Admin.Smart.Components.Membership
{
    public partial class ChangePassword : System.Web.UI.UserControl
    {
        protected static SmartCompanyDataContext smartDb = new SmartCompanyDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #region Part 3: Mukhtar Properties Code Area
        /// <summary>
        /// Get the Password
        /// </summary>
        protected string OldPasswordHash
        {
            get { return MaSecurity.Encrypt(MaSecurity.EncryptionKey, txtPassword.Text, true); }
        }
        /// <summary>
        /// Get the New Password
        /// </summary>
        protected string NewPasswordHash
        {
            get { return MaSecurity.Encrypt(MaSecurity.EncryptionKey, txtNewPassword.Text, true); }
        }
        /// <summary>
        /// Get, set this value, check if old password is correct or not
        /// </summary>
        protected bool WrongOldPassword
        {
            get
            {
                object obj = this.ViewState["WrongOldPassword"];
                if (obj == null)
                    return false; // Default value
                else
                    return (bool)obj;
            }
            set
            {
                this.ViewState["WrongOldPassword"] = value;
            }
        }
        #endregion

        #region Part 4: Mukhtar Save Button Click Event Controller
        // Save Data
        protected void btnSave_Click(object sender, EventArgs e)
        {
            msgPanel.Visible = false;
            // Check if the page is valid - this is for more security
            if (Page.IsValid)
            {
                bool action = false;
                action = this.LinqChangeCurrentUserPassword();

                // Check Saving data..
                if(this.WrongOldPassword == true)
                    BaseSys.ShowMsg(msgPanel, lbMsg, Properties.Resources.WrongPassword, "error");
                else
                    BaseSys.ShowMsg(msgPanel, lbMsg, Properties.Resources.Success, "ok");

            }
            else { BaseSys.ShowMsg(msgPanel, lbMsg, Properties.Resources.FailureValid, "error"); }
        }

        #endregion

        #region Part 5: Mukhtar LINQ Methods Controller Area
        /// <summary>
        /// Change the current user password
        /// </summary>
        /// <returns></returns>
        protected bool LinqChangeCurrentUserPassword()
        {
            int userId = smartDb.ChangeCurrentUserPassword(BaseSys.SysUserID, this.OldPasswordHash, this.NewPasswordHash);

            if (userId == 0) this.WrongOldPassword = true; else this.WrongOldPassword = false;
            
            try
            {
                smartDb.SubmitChanges(); return true;
            }
            catch { return false; }
        }

        #endregion

    }// end class
}// end NS