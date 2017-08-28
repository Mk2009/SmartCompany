using System;

namespace SmartCompany
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = "Company";
            Label1.Text = string.Format("<h1>Mukhtar Website</h1> {0}", name);
        }
    }
}