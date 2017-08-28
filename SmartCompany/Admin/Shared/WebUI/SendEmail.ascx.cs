using System;
using SmartCompany.Properties;
using SmartCompany.Admin.Shared.Code;

namespace SmartCompany.Admin.Shared.WebUI
{
    public partial class SendEmail : System.Web.UI.UserControl
    {
        protected static SmartCompanyDataContext smartDb = new SmartCompanyDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #region Part 3: Mukhtar Properties Area

        private string ToEmail
        {
            get { return lbToEmail.Text; }
        }

        private string Subject
        {
            get { return txtSubject.Text; }
        }
        private string Message
        {
            get { return txtMessage.Text; }
        }
        #endregion

        #region Part 4: Mukhtar Save Button Click Event Controller Area
        // Save Button
        protected void btnSave_Click(object sender, EventArgs e)
        {
            msgPanel.Visible = false;

            bool action = false;

            if (Page.IsValid)
            {
                action = this.SendEmailMessage();

                // Check Saving and sending data..
                if (action == true)
                {
                    BaseSys.ShowMsg(msgPanel, lbMsg, Properties.Resources.SuccessSentEmail, "ok");
                    this.LinqInsertEmail();
                }
                else
                    BaseSys.ShowMsg(msgPanel, lbMsg, Properties.Resources.Failure, "error");

            }
            else { BaseSys.ShowMsg(msgPanel, lbMsg, Properties.Resources.FailureValid, "error"); }

        }
        #endregion

        #region Part 5: Mukhtar LINQ Methods Controller Area

        /// <summary>
        /// Insert Data using LINQ techniques
        /// </summary>
        /// <returns></returns>
        protected bool LinqInsertEmail()
        {
            // Send  all values of course to  InsertCourse() storedprocedure
            smartDb.InsertSentEmail(this.ToEmail, this.Subject, this.Message, DateTime.Now);

            try
            {
                smartDb.SubmitChanges(); return true; // Save data and return true
            }
            catch { return false; }

        }

        #endregion

        #region Part 6: Send Email Method Controller
        /// <summary>
        /// Send email to user
        /// </summary>
        /// <returns></returns>
        private bool SendEmailMessage()
        {
            try
            {
                Email email = new Email(this.ToEmail, this.Subject, this.Message);
                email.Message.IsBodyHtml = true;
                email.Send(); return true;
            }
            catch { return false; }
        }
        #endregion

    }// end class
}// end NS