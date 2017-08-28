using System;
using System.Linq;
using System.Web.UI.WebControls;
using SmartCompany.Properties;
using System.Web.UI;

namespace SmartCompany.Admin.Smart.Components.Contact
{
    public partial class DetailMessage : System.Web.UI.UserControl
    {
        protected static SmartCompanyDataContext smartDb = new SmartCompanyDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// Set or Get the Contact id
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


        #region Part 3: Mukhtar LINQ Methods Controller Area
        /// <summary>
        /// Fetch row data using LINQ techniques
        /// </summary>
        public void LinqFetchRowData()
        {
            var contact = (from c in smartDb.ContactUs
                            where c.Id == this.ContactID select c).First();

            // Matches data to controls
            lbName.Text = contact.Name;
            lbEmail.Text = contact.Email;
            lbMessage.Text = contact.Message;
            lbSentDate.Text = contact.SentDate.ToString();

            lbSentBy.Text = string.Format("{0}: {1} | {2}: {3}", Properties.Resources.IPAddress, contact.IPAddress, Properties.Resources.MachineName, contact.MachineName);
        }
        #endregion

        #region Part 4. Back Icons Buttons Click Event
        // Back Icon
        protected void imgBtnBack_Click(object sender, ImageClickEventArgs e)
        {
            Parent.FindControl("mwcShow").Visible = true;
            this.Visible = false;
        }
        // New message icon
        protected void imgBtnNewMessage_Click(object sender, ImageClickEventArgs e)
        {
            Parent.FindControl("mwcShow").Visible = false;



        }
        #endregion

        private void HidePanels()//mwcSendEmail
        {
            Parent.FindControl("mwcShow").Visible = false;
            Parent.FindControl("mwcSendEmail").Visible = false;
        }

    }// end class
}// end NS