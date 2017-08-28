using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartCompany.App_Data;
using System.Drawing;
using SmartCompany.Admin.Shared.Code;

namespace SmartCompany.Admin.Smart.Components.Category
{
    public partial class DetailCategory : System.Web.UI.UserControl
    {
        // Connect to xml DataSet to get data from [Home]
        Company.CategoryDataTable category = new Company.CategoryDataTable();
        string xmlFile = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            xmlFile = BaseSys.GetXmlFilePath("Category.xml"); // Important - otherwise will have error
        }
        /// <summary>
        /// Set or Get the Service id
        /// </summary>
        public short CategoryID
        {
            get
            {
                object obj = this.ViewState["CategoryID"];
                if (obj == null)
                    return 0; // Default value
                else
                    return (short)obj;
            }
            set
            {
                this.ViewState["CategoryID"] = value;
            }
        }


        #region Part 3: Mukhtar XML Methods Controller Area [LinqXmlFetchRowData]
        // Fetch row data from xml file using linq to xml techniques
        public void LinqXmlFetchRowData()
        {
            category.ReadXml(xmlFile);
            var cateRow = (from c in category where c.Id == this.CategoryID select c).First();

            hFieldID.Value = cateRow.Id.ToString();
            lbTitle.Text = cateRow.Name;
            lbDescription.Text = cateRow.Description;
            imgUploaded.ImageUrl = cateRow.ImagePath;

            if (cateRow.Active == true)
            {
                lbShow.Text = Properties.Resources.Yes; lbShow.ForeColor = Color.Green;
            }
            else
            {
                lbShow.Text = Properties.Resources.No; lbShow.ForeColor = Color.Red;
            }

        }
        #endregion

        #region Part 4. Edit & NewUser ImagePaths Buttons Click Event

        // Edit ImagePath 
        protected void imgBtnEditDet_Click(object sender, ImageClickEventArgs e)
        {
            EntryCategory mwcEntry = (EntryCategory)Parent.FindControl("mwcEntry");
            mwcEntry.CategoryID = Convert.ToInt16(imgBtnEditDet.CommandArgument);
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