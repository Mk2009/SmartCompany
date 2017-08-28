using System;
using System.Linq;
using SmartCompany.Properties;
using System.Web.UI.WebControls;
using SmartCompany.App_Data;
using System.IO;
using System.Web;

namespace SmartCompany.Admin.Shared.Code
{
    public static class SharedLinq
    {
        // Declare my system database context = LINQ
        private static SmartCompanyDataContext smartDb = new SmartCompanyDataContext();
        private static Company.LanguageDataTable language = new Company.LanguageDataTable();


        #region Part 1: Mukhtar LINQ Methods Conteroller Area
        /// <summary>
        /// Fecth all privilegs to dropdownlist
        /// </summary>
        /// <param name="_dropDownList"></param>
        public static void LinqFetchPrivilege(DropDownList _dropDownList)
        {
            var privilege = (from p in smartDb.Privileges select p);

            // Match values to _dropDownList control
            _dropDownList.Items.Clear();
            _dropDownList.DataSource = privilege;
            _dropDownList.DataTextField = "Name";
            _dropDownList.DataValueField = "Id";
            _dropDownList.DataBind();
        }
        /// <summary>
        /// Update the count of visiotr for eacher page
        /// </summary>
        public static void LinqCountVisitor(string page)
        {
            DateTime date = DateTime.Now.Date;
            smartDb.CalculateVisitor(page, date);
        }
        #endregion

        #region Part 2: Mukhtar XML Methods Controller Area
        // Fetch row data from xml using xml dataset
        public static void XmlFetchLanguage(DropDownList _dropDownList)
        {
            string xmlFile = HttpContext.Current.Server.MapPath("~") + @"\App_Data\Language.xml";
            language.Rows.Clear();// Clear it first to avoid any repeated data in ddl
            _dropDownList.Items.Clear();// only to be sure that it's empty before fill it.

            if (File.Exists(xmlFile))
            {
                // Get data from xml file
                language.ReadXml(xmlFile);

                _dropDownList.DataTextField = "Name";
                _dropDownList.DataValueField = "Value";
                _dropDownList.DataSource = language;
                _dropDownList.DataBind();
            }
        }
        #endregion

    }// end class
}// end NS