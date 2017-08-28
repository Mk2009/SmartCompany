using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartCompany.Admin.Smart
{
    public partial class ContactInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                Page.Title = string.Format("{0} - {1}", Properties.Resources.MainTitle, Properties.Resources.ContactInformation);
        }
    }
}