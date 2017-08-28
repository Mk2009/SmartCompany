using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace SmartCompany.Admin.Shared.Code
{
    public class Email : SmtpClient
    {
        public MailMessage Message { get; private set; }

        private static string EmailSmtp { get { return Properties.Settings.Default.EmailSmtp; } }
        private string FromEmail { get { return Properties.Settings.Default.YourEmail; } }
        private string EmailParty { get { return Properties.Settings.Default.EmailParty; } }

        /// <summary>
        /// Encompassing Email class
        /// </summary>
        /// <param name="to">send mail to</param>
        /// <param name="from">mail is frorm</param>ur
        /// <param name="subject">message subject</param>
        /// <param name="body">message body</param>
        public Email(string to, string subject, string body)
            : base(EmailSmtp, 587)
        {
            EnableSsl = Properties.Settings.Default.EmailSSI;
            if (this.EnableSsl == true)
                this.Credentials = new System.Net.NetworkCredential(this.FromEmail, this.EmailParty);
            // Message to Send
            this.Message = new MailMessage(this.FromEmail, to, subject, body);
        }

        /// <summary>
        /// Send Message
        /// </summary>
        public void Send()
        {
            try
            {
                Send(this.Message);
            }
            catch (Exception ex) { throw ex; }
        }


    }// end class
}// end NS