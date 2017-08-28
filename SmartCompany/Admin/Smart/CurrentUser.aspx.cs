using System;

namespace SmartCompany.Admin.Smart
{
    public partial class CurrentUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mwcCurrentUser.LinqFetchRowData();
                Page.Title = string.Format("{0} - {1}", Properties.Resources.MainTitle, Properties.Resources.CurrentUserPage);
                lbPageTitle.Text = Properties.Resources.CurrentUserPage;
                btnShowHide.Text = Properties.Resources.ChangePassButton;
            }
        }

        protected void btnShowHide_Click(object sender, EventArgs e)
        {
            mwcCurrentUser.Visible = false;
            mwcChangePass.Visible = false;

            if (btnShowHide.CommandName == "PASS")
            {
                mwcChangePass.Visible = true;
                btnShowHide.CommandName = "USER";
                btnShowHide.Text = Properties.Resources.CurrentUserButton;
            }
            else
            {
                mwcCurrentUser.Visible = true;
                btnShowHide.CommandName = "PASS";
                btnShowHide.Text = Properties.Resources.ChangePassButton;
            }
        }
    }// end class
}// end NS