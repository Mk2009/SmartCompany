using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartCompany.Properties;
using System.Drawing;
using SmartCompany.Admin.Shared.Code;
using SmartCompany.App_Data;

namespace SmartCompany.Admin.Smart.Components.CoService
{
    public partial class DetailService : System.Web.UI.UserControl
    {
        protected static SmartCompanyDataContext smartDb = new SmartCompanyDataContext();
        string xmlFile = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            xmlFile = BaseSys.GetXmlFilePath("Category.xml");

            //if (!IsPostBack)
            //    xmlFile = BaseSys.GetXmlFilePath("Category.xml");
        }
        /// <summary>
        /// Set or Get the Service id
        /// </summary>
        public int ServiceID
        {
            get
            {
                object obj = this.ViewState["ServiceID"];
                if (obj == null)
                    return 0; // Default value
                else
                    return (int)obj;
            }
            set
            {
                this.ViewState["ServiceID"] = value;
            }
        }


        #region Part 3: Mukhtar LINQ Methods Controller Area
        /// <summary>
        /// Fetch row data using LINQ techniques
        /// </summary>
        public void LinqFetchRowData()
        {
            var serv = (from t in smartDb.ServiceTitles join s in smartDb.Services on t.Service_Id equals s.Id
                        join u in smartDb.SysUsers on s.EditedBy_Id equals u.Id
                        where s.Id == this.ServiceID
                        select new { s.Id, t.Title, s.CategoryID, t.Description, s.ImagePath, s.Slide, s.Show, s.ModifiedDate, u.UserName }).First();

            // For Edit Purpose
            imgBtnEditDet.CommandArgument = serv.Id.ToString();
            // Matches data to controls
            lbTitle.Text = serv.Title;
            lbCategory.Text = this.GetCategoryName(serv.CategoryID);
            lbDescription.Text = serv.Description;
            imgUploaded.ImageUrl = serv.ImagePath;
            // Slide
            if (serv.Slide == true)
            {
                lbSlide.Text = Properties.Resources.Yes; lbSlide.ForeColor = Color.Green;
            }
            else
            {
                lbSlide.Text = Properties.Resources.No; lbSlide.ForeColor = Color.Red;
            }
            // Show
            if (serv.Show == true)
            {
                lbShow.Text = Properties.Resources.Yes; lbShow.ForeColor = Color.Green;
            }
            else
            {
                lbShow.Text = Properties.Resources.No; lbShow.ForeColor = Color.Red;
            }

            lbDoneBy.Text = string.Format("{0}: {1} | {2}: {3}", Properties.Resources.By, serv.UserName, Properties.Resources.Date, serv.ModifiedDate);
        }
        #endregion

        #region Part 4. Edit & NewUser Icons Buttons Click Event

        // Edit Icon 
        protected void imgBtnEditDet_Click(object sender, ImageClickEventArgs e)
        {
            EntryService mwcEntry = (EntryService)Parent.FindControl("mwcEntry");
            mwcEntry.ServiceID = Convert.ToInt32(imgBtnEditDet.CommandArgument);
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
        // Populate ddl from xml data
        private string GetCategoryName(short? id)
        {
            Company.CategoryDataTable category = new Company.CategoryDataTable();
            category.ReadXml(xmlFile);

            var cateVal = (from c in category where c.Id == id select new { c.Name }).First();
            return cateVal.Name;
        }

        #endregion

    }// end class
}// end NS