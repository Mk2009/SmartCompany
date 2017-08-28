using System;

namespace SmartCompany
{
    public partial class WebSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                html.Attributes.Add("dir", Properties.Resources.HtmlDir);
                css.Attributes["href"] = string.Format("~/App_Themes/{0}", Properties.Resources.CssFile);
                //Response.Redirect("~/Index.html");
            }
        }

    }// end class
}// end NS