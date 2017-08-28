using System;
using System.Linq;
using SmartCompany.App_Data;
using System.IO;
using SmartCompany.Admin.Shared.Code;
using System.Xml.Linq;

namespace SmartCompany
{
    public partial class Business : System.Web.UI.Page
    {
        // Connect to xml DataSet to get data from [Category]
        Company.CategoryDataTable category = new Company.CategoryDataTable();
        
        #region Part 1: Mukhtar [Page_PreInit] - [Page_Load] Area
        // Page_PreInit: Get the selected theme from setting
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Page.Theme = Properties.Settings.Default.WebsiteTheme;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            //string cate = Request.QueryString["Category"];
            //Properties.Settings.Default["MenuNavigation"] = "Business";
            //if (!IsPostBack)
            //{
            //    if (string.IsNullOrEmpty(cate) || string.IsNullOrWhiteSpace(cate))
            //        this.ErrorMsg();
            //    else
            //        this.LinqCountRows(cate);
            //}

            string id = Request.QueryString["ID"];

            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
                    this.ErrorMsg();
                else
                    this.InitializePage(id);
            }

        }
        #endregion

        #region Part 2: Mukhtar XML & LINQ Methods Controller Area
        /// <summary>
        /// Count data found that specified to giving cate
        /// </summary>
        /// <param name="id"></param>
        protected void LinqCountRows(int id)
        {
            string xmlFile = BaseSys.GetXmlFilePath("Category.xml"); 
            category.ReadXml(xmlFile);
            int count = (from c in category where c.Id == id select c).Count();

            if (count > 0)
            {
                msgPanel.Visible = false;
                contentPanel.Visible = true;
                this.XmlFetchContent(id);
            }
        }
        /// <summary>
        /// Fetch single row data that specified to giving cate
        /// </summary>
        /// <param name="id"></param>
        protected void XmlFetchContent(int id)
        {
            string xmlFile = BaseSys.GetXmlFilePath("Category.xml"); 

            if (File.Exists(xmlFile))
            {
                XDocument xmlDoc = XDocument.Load(xmlFile);
                var cate = xmlDoc.Descendants("Category").FirstOrDefault(c => c.Element("Id").Value == id.ToString());

                if (cate == null) return;

                lbTitle.Text = cate.Element("Name").Value;
                lbDescription.Text = cate.Element("Description").Value;
                imgShow.ImageUrl = cate.Element("ImagePath").Value;

                Page.Title = string.Format("{0} - {1}", Properties.Resources.MainTitle, cate.Element("Name").Value);

                //category.ReadXml(xmlFile);
                //var content = (from c in category where c.Id == id select c).First();

                //lbTitle.Text = content.Name;
                //lbDescription.Text = content.Description;
                //imgShow.ImageUrl = content.ImagePath;

                //// Make the title as page title
                //Page.Title = string.Format("{0} - {1}", Properties.Resources.MainTitle, content.Name);
            }
        }

        #endregion

        #region  Part 3: Mukhtar Methods Controller Area
        // Initialize the page
        private void InitializePage(string id)
        {
            int number = 0;
            // the id must be a number
            bool urlParam = int.TryParse(id, out number);
            if (urlParam == true)// It's a number
                this.LinqCountRows(number);
            else // It's Not number
                this.ErrorMsg();

            Page.Title = string.Format("{0} - {1}", Properties.Resources.MainTitle, Properties.Resources.OurBusiness);
        }

        // Show error message if the data not found, 
        //or the giving url param is string or number that not found.
        private void ErrorMsg()
        {
            contentPanel.Visible = false;
            lbMsg.Text = Properties.Resources.PageNotFound;
            msgPanel.Visible = true;
        }

        #endregion


    }// end class
}// end NS