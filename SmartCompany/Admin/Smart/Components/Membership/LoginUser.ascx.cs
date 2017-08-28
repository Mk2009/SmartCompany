using System;
using System.Linq;
using SmartCompany.Admin.Shared.Code;
using MukhtarMA.SmartWeb.Security;
using MukhtarMA.SmartWeb.Network;
using SmartCompany.Properties;
using System.Threading;
using SmartCompany.Admin.Shared.WebUI;

namespace SmartCompany.Admin.Smart.Components.Membership
{
    public partial class LoginUser : System.Web.UI.UserControl
    {
        protected static SmartCompanyDataContext smartDb = new SmartCompanyDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int count = smartDb.SysUsers.Count();
                if (count > 0) this.Visible = true; else { this.Visible = false; this.ShowNewUser(); }
                string xmlFile = BaseSys.GetXmlFilePath("Company.xml"); ddlLanguage.Items.Clear();
                SharedLinq.XmlFetchLanguage(ddlLanguage);
                ddlLanguage.ClearSelection();
                ddlLanguage.Items.FindByValue(this.CultureInfo).Selected = true;
            }
        }

        #region Part 3: Mukhtar Properties Code Area [ViewState, Cookies & Session]
        /// <summary>
        /// Get username from textbox
        /// </summary>
        protected string UserName
        {
            get { return txtUserName.Text.Trim(); }
        }
        /// <summary>
        /// Get password from textbox and encrypt it.
        /// </summary>
        protected string PasswordHash
        {
            get { return MaSecurity.Encrypt(MaSecurity.EncryptionKey, txtPassword.Text, true); }
        }
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
        private string SelectedLangauge
        {
            get { return ddlLanguage.SelectedValue; }
        }

        #region 1. ViewState Storage [FoundUserID, FoundPrivilegeID & LoginResult]
        /// <summary>
        /// Get, Set found user id
        /// </summary>
        protected int FoundUserID
        {
            get
            {
                object obj = this.ViewState["FoundUserID"];
                if (obj == null)
                    return 0; // Default value
                else
                    return (int)obj;
            }
            set
            {
                this.ViewState["FoundUserID"] = value;
            }
        }
        /// <summary>
        /// Get, Set found privilege id
        /// </summary>
        protected byte FoundPrivilegeID
        {
            get
            {
                object obj = this.ViewState["FoundPrivilegeID"];
                if (obj == null)
                    return 0; // Default value
                else
                    return (byte)obj;
            }
            set
            {
                this.ViewState["FoundPrivilegeID"] = value;
            }
        }
        /// <summary>
        /// Get, Set login result id
        /// </summary>
        protected string LoginResult
        {
            get
            {
                object obj = this.ViewState["LoginResult"];
                if (obj == null)
                    return string.Empty; // Default value
                else
                    return (string)obj;
            }
            set
            {
                this.ViewState["LoginResult"] = value;
            }
        }
        #endregion

        #region 2. Other Properties [MachineName, MachineIP, MachineMac, LoginTryID]
        /// <summary>
        /// Get the client machine name
        /// </summary>
        protected string MachineName
        {
            get
            {
                System.Net.IPHostEntry host;
                host = System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]);
                return host.HostName;
            }
        }
        /// <summary>
        /// Get, Set MachineIP
        /// </summary>
        protected string MachineIP
        {
            get
            {
                MaNetwork.GetRemoteIPandMacAddress(this.MachineName);
                return MaNetwork.IPAddress;
            }
        }
        /// <summary>
        /// Get, Set MachineMac
        /// </summary>
        protected string MachineMac
        {
            get
            {
                MaNetwork.GetRemoteIPandMacAddress(this.MachineName);
                return MaNetwork.MacAddress;
            }
        }
        /// <summary>
        /// Get, Set loginTry id
        /// </summary>
        protected int LoginTryID
        {
            get { return Convert.ToInt32(hFieldLoginTryId.Value); }
            set { hFieldLoginTryId.Value = value.ToString(); }
        }
        #endregion

        /// <summary>
        /// Set or Get the Count
        /// </summary>
        protected byte Count
        {
            get
            {
                object obj = this.Session["Count"];
                if (obj == null)
                    return 0; // Default value
                else
                    return (byte)obj;
            }
            set
            {
                this.Session["Count"] = value;
            }
        }
        /// <summary>
        /// save BlockLogin in Cookies
        /// </summary>
        protected bool BlockLogin
        {
            get
            {
                if (Request.Cookies["BlockLogin"] == null)
                    return false;
                else
                    return Convert.ToBoolean(Request.Cookies["BlockLogin"].Value);
            }
            set // Set the cookies and give expire date to 2 days only
            {
                Response.Cookies["BlockLogin"].Value = value.ToString();
                Response.Cookies["BlockLogin"].Expires = DateTime.Now.AddDays(2);
            }
        }
        #endregion

        #region Part 4. Mukhtar Login Button Click Event Controller Area
        // Login button
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            this.Count += 1; // Count Lgoin Tries
            if (Page.IsValid == true)
            {
                string culture = ddlLanguage.SelectedValue;
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);
                this.SaveLanguaeInCookies(culture);

                this.CheckLoginAuthentication();
            }
        }
        #endregion

        #region VI Mukhtar Login Method Controller Area [CheckLoginAuthentication]
                /// <summary>
        /// Check the login authentication and pass to next page for successful login
        /// </summary>
        protected void CheckLoginAuthentication()
        {
            this.LinqLoginAuthentication();

            if (this.LoginResult == "Success")// Login Successful Success
            {
                // Store values in session
                BaseSys.LogInControlPanel = true;
                BaseSys.SysUserID = this.FoundUserID;
                BaseSys.PrivilegeID = this.FoundPrivilegeID;
                // Store login info for status
                this.LinqInsertLoginStatusData();
                // Redirect to control panel
                Response.Redirect("~/Admin/Smart/Default.aspx");
                this.SetUserInfoToTopMenu();
            }
            else
            {
                BaseSys.LogInControlPanel = false;

                if (this.LoginResult == "NotActive")
                    BaseSys.ShowMsg(msgPanel, lbMsg, Properties.Resources.NoAdminPermission, "error");
                else if (this.LoginResult == "NotSucceed")
                    BaseSys.ShowMsg(msgPanel, lbMsg, Properties.Resources.WrongLogin, "error");
                
                // Only add for first time, others update in specified time
                if (this.LoginTryID > 0)
                {
                    this.LinqUpdateLoginTryData().ToString();

                }
                else { this.LinqInsertLoginTryData(); }

                txtPassword.Text = string.Empty;
            }
        }
        #endregion

        #region Part 5: Mukhtar LINQ Methods Area

        #region 1. Login Authentication

        protected void LinqLoginAuthentication()
        {
            var login = smartDb.ControlPanelAuthentication(this.UserName, this.PasswordHash);

            foreach (var user in login)
            {
                this.FoundUserID = user.Id;
                this.FoundPrivilegeID = Convert.ToByte(user.Privilege_Id);
                this.LoginResult = user.Result;
            }
        }
        #endregion

        #region 2. LoginTry Table [ Insert, Update & Block]
        /// <summary>
        /// Insert Data using Linq Techniques 
        /// </summary>
        /// <returns></returns>
        protected bool LinqInsertLoginTryData()
        {
            this.LoginTryID = smartDb.InsertLoginTries(this.UserName, this.PasswordHash, this.MachineName, this.MachineIP, this.MachineMac, DateTime.Now, this.Count, this.LoginResult);

            try
            {
                smartDb.SubmitChanges(); return true; 
            }
            catch { return false; }

        }

        /// <summary>
        /// Update Data using Linq Techniques
        /// </summary>
        /// <returns></returns>
        protected bool LinqUpdateLoginTryData()
        {
            LoginTry login = (from l in smartDb.LoginTries
                              where l.Id == this.LoginTryID
                              select l).First();

            login.TriesTimes = this.Count;
            login.Status = this.LoginResult;

            try
            {
                smartDb.SubmitChanges(); return true;
            }
            catch { return false; }
        }
        /// <summary>
        /// Block the user if s/he repeat wrong info 8 times
        /// </summary>
        /// <returns></returns>
        protected bool LinqBlockUser()
        {
            LoginTry login = (from l in smartDb.LoginTries
                              where l.Id == this.LoginTryID
                              select l).First();
            login.Block = true;

            try
            {
                smartDb.SubmitChanges(); return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// Get the block value
        /// I need to check if the user has been blocked, so not allowed for login again untile check admin
        /// </summary>
        /// <returns></returns>
        protected bool LinqGetBlockValue()
        {
            var countLogin = (from c in smartDb.LoginTries where c.EnteredUserName == this.UserName select c).Count();

            if (countLogin > 0)
            {
                var login = (from l in smartDb.LoginTries
                             where l.EnteredUserName == this.UserName
                             select new { l.Block }).First();

                return login.Block;
            }
            else { return false; }
        }
        #endregion

        #region 3. LoginStatus Table [ Insert ]
        /// <summary>
        /// Insert Data using Linq Techniques
        /// </summary>
        /// <returns></returns>
        protected bool LinqInsertLoginStatusData()
        {
            DateTime date = DateTime.Now;
            TimeSpan time = DateTime.Now.TimeOfDay;

            BaseSys.SysUserLogStatusID = smartDb.InsertSysUserLogStatus(BaseSys.SysUserID, time, date, true);

            try
            {
                smartDb.SubmitChanges(); return true;
            }
            catch { return false; }
        }

        #endregion

        #endregion

        private void SetUserInfoToTopMenu()
        {
            MenuBox mwcMenuBox = (MenuBox)Parent.FindControl("mwcMenuBox");

            mwcMenuBox.UserInfo();
        }
        // Show new user box
        private void ShowNewUser()
        {
            EntryUser mwcEntryUser = (EntryUser)Parent.FindControl("mwcEntryUser");
            mwcEntryUser.ItsManager = true;
            mwcEntryUser.InitializeBox(true);
            mwcEntryUser.Visible = true;
        }

        // Save selected lang in cookies for future use
        private void SaveLanguaeInCookies(string uiCulture)
        {
            Response.Cookies["CultureInfo"].Value = uiCulture;
            Response.Cookies["CultureInfo"].Expires = DateTime.Now.AddDays(14);
        }

    }// end class
}// end NS