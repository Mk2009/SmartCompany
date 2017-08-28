using System;
using System.Web;
using System.Threading;
using System.Globalization;

namespace SmartCompany
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpCookie uiCulture = Request.Cookies["CultureInfo"];// Get UICuluter from cookies

            if (uiCulture != null && !string.IsNullOrEmpty(uiCulture.Value))
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(uiCulture.Value);
                Thread.CurrentThread.CurrentCulture = new CultureInfo(uiCulture.Value);
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Properties.Settings.Default.CurrentCulture);//ar-SY - en-US
                Thread.CurrentThread.CurrentCulture = new CultureInfo(Properties.Settings.Default.CurrentCulture);
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}