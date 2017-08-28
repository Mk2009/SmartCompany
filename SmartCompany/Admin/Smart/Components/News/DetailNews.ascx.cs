using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartCompany.Properties;
using System.Drawing;

namespace SmartCompany.Admin.Smart.Components.News
{
    public partial class DetailNews : System.Web.UI.UserControl
    {
        protected static SmartCompanyDataContext smartDb = new SmartCompanyDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// Set or Get the news id
        /// </summary>
        public int NewsID
        {
            get
            {
                object obj = this.ViewState["NewsID"];
                if (obj == null)
                    return 0; // Default value
                else
                    return (int)obj;
            }
            set
            {
                this.ViewState["NewsID"] = value;
            }
        }


        #region Part 3: Mukhtar LINQ Methods Controller Area
        /// <summary>
        /// Fetch row data using LINQ techniques
        /// </summary>
        public void LinqFetchRowData()
        {
            var news = (from t in smartDb.ServiceTitles join n in smartDb.Services on t.Service_Id equals n.Id
                        join u in smartDb.SysUsers on n.EditedBy_Id equals u.Id
                        where n.Id == this.NewsID
                        select new { n.Id, t.Title, t.Description, n.ImagePath, n.Show, n.ModifiedDate, u.UserName }).First();

            // For Edit Purpose
            imgBtnEditDet.CommandArgument = news.Id.ToString();
            // Matches data to controls
            lbTitle.Text = news.Title;
            lbDescription.Text = news.Description;
            imgUploaded.ImageUrl = news.ImagePath;

            if (news.Show == true)
            {
                lbShow.Text = Properties.Resources.Yes; lbShow.ForeColor = Color.Green;
            }
            else
            {
                lbShow.Text = Properties.Resources.No; lbShow.ForeColor = Color.Red;
            }

            lbDoneBy.Text = string.Format("{0}: {1} | {2}: {3}", Properties.Resources.By, news.UserName, Properties.Resources.Date, news.ModifiedDate); 
        }
        #endregion

        #region Part 4. Edit & NewUser Icons Buttons Click Event

        // Edit Icon 
        protected void imgBtnEditDet_Click(object sender, ImageClickEventArgs e)
        {
            EntryNews mwcEntry = (EntryNews)Parent.FindControl("mwcEntry");
            mwcEntry.NewsID = Convert.ToInt32(imgBtnEditDet.CommandArgument);
            mwcEntry.InitializeBox(false);
            this.HideMukhtarWebUIPanels();
            mwcEntry.Visible = true;
            this.BtnNewActionManner("SHOW");
        }
        #endregion

        #region Part 5: Mukhtar Methods Area
        // Hide all Mukhtar web UI Panels
        private void HideMukhtarWebUIPanels()
        {
            Parent.FindControl("mwcEntry").Visible = false;
            Parent.FindControl("mwcShow").Visible = false;
            Parent.FindControl("mwcDetail").Visible = false;
        }
        // I need to change the btnNew action of the page
        private void BtnNewActionManner(string manner)
        {
            Button btnNew = (Button)Parent.FindControl("btnNew");
            btnNew.CommandName = manner;
            btnNew.Text = Properties.Resources.ShowData;
        }

        #endregion

    }// end class
}// end NS