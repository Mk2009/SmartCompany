using System;
using SmartCompany.Properties;
using MukhtarMA.SmartWeb.Network;
using System.Drawing;

namespace SmartCompany.View.Content
{
    public partial class ContactUs : System.Web.UI.UserControl
    {
        protected static SmartCompanyDataContext smartDb = new SmartCompanyDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                this.InitializeContactUs();
        }

        #region Part 3: Mukhtar Properties Code Area

        /// <summary>
        /// Set or Get the ContactID id
        /// </summary>
        public int ContactID
        {
            get
            {
                object obj = this.ViewState["ContactID"];
                if (obj == null)
                    return 0; // Default value
                else
                    return (int)obj;
            }
            set
            {
                this.ViewState["ContactID"] = value;
            }
        }

        /// <summary>
        /// Set, get the found date value
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

        #region Entry Properties
        private string Name
        {
            get { return txtName.Text.Trim(); }
        }
        private string Email
        {
            get { return txtEmail.Text.Trim(); }
        }
        private string Message
        {
            get { return txtMessage.Text.Trim(); }
        }   
     
        #endregion

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

        #endregion

        #region Part 4: Mukhtar Click Evnet Controller [Send]
        // Send button
        protected void btnSend_Click(object sender, EventArgs e)
        {
            bool action = this.LinqInsertData();

            msgPanel.Visible = true;

            if (this.mwcCaptcha.CaptchaCode != null && txtCaptchaCode.Text.ToLower() == this.mwcCaptcha.CaptchaCode)
            {
                if (this.Found == false)
                {
                    if (action == true)
                    {
                        lbMsg.Text = Properties.Resources.SendSucceed; lbMsg.ForeColor = Color.Green;
                        contactusPanel.Visible = false;
                    }
                    else
                    {
                        lbMsg.Text = Properties.Resources.SendFailure; lbMsg.ForeColor = Color.Red;
                        contactusPanel.Visible = true;
                    }
                }
                else
                    lbMsg.Text = Properties.Resources.SendNotAccept;
            }
            else
            {
                lbMsg.Text = Properties.Resources.ErrorCaptchaCode; lbMsg.ForeColor = Color.Red;
            }
        }
        #endregion

        #region Part 5: Mukhtar LINQ Methods Controller Area
        /// <summary>
        /// Insert data in db using linq technique
        /// </summary>
        /// <returns></returns>
        protected bool LinqInsertData()
        {
            this.ContactID = smartDb.InsertContacts
            (
                this.Name, this.Email, this.Message, DateTime.Now, MaNetwork.GetRemoteIPAddress(), this.MachineName, MaNetwork.MacAddress
            );

            if (this.ContactID == 0) this.Found = true; else this.Found = false;

            try
            {
                smartDb.SubmitChanges(); return true;
            }
            catch { return false; }
        }
        #endregion


        // Initialize the box for new message
        private void InitializeContactUs()
        {
            msgPanel.Visible = false;
            contactusPanel.Visible = true;
        }

    }// end class
}// end NS