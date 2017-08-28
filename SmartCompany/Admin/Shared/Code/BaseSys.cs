using System.Web.UI.WebControls;
using System.Web;
using System.Threading;
using System.Web.UI;
using System;
using System.Drawing;
using System.IO;

namespace SmartCompany.Admin.Shared.Code
{
    public static class BaseSys
    {

        #region VI. HttpContext.Current.Session Storage [LogInControlPanel, SysUserID, PermissionID, SysUserLogStatusID]
        /// <summary>
        /// Save login status in session
        /// </summary>
        public static bool LogInControlPanel
        {
            get
            {
                if (HttpContext.Current.Session["LogInControlPanel"] == null)
                    return false;
                else
                    return Convert.ToBoolean(HttpContext.Current.Session["LogInControlPanel"]);
            }
            set { HttpContext.Current.Session["LogInControlPanel"] = value; }
        }
        /// <summary>
        /// Trace changing language & save it in session
        /// </summary>
        public static bool TraceChangingLanguage
        {
            get
            {
                if (HttpContext.Current.Session["TraceChangingLanguage"] == null)
                    return false;
                else
                    return Convert.ToBoolean(HttpContext.Current.Session["TraceChangingLanguage"]);
            }
            set { HttpContext.Current.Session["TraceChangingLanguage"] = value; }
        }

        /// <summary>
        /// save user id in HttpContext.Current.Session
        /// </summary>
        public static int SysUserID
        {
            get
            {
                if (HttpContext.Current.Session["SysUserID"] == null)
                    return 0;
                else
                    return Convert.ToInt32(HttpContext.Current.Session["SysUserID"]); 
            }
            set { HttpContext.Current.Session["SysUserID"] = value; }
        }
        /// <summary>
        /// save privilege id in HttpContext.Current.Session
        /// </summary>
        public static byte PrivilegeID
        {
            get
            {
                if (HttpContext.Current.Session["PrivilegeID"] == null)
                    return 0;
                else
                    return Convert.ToByte(HttpContext.Current.Session["PrivilegeID"]); 
            }
            set { HttpContext.Current.Session["PrivilegeID"] = value; }
        }
        /// <summary>
        /// Get, Set SysUserLogStatus id, I need this for logout time update
        /// </summary>
        public static int SysUserLogStatusID
        {
            get
            {
                object obj = HttpContext.Current.Session["SysUserLogStatusID"];
                if (obj == null)
                    return 0; // Default value
                else
                    return (int)obj;
            }
            set
            {
                HttpContext.Current.Session["SysUserLogStatusID"] = value;
            }
        }

        #endregion

        #region Part 2: Mukhtar General Properties Area
        /// <summary>
        /// Set the current culture or language
        /// </summary>
        public static string CurrentCulture
        {
            get
            {
                string languge = Properties.Settings.Default.CurrentCulture;

                string culture = Thread.CurrentThread.CurrentCulture.Name;
                string uiCulture = Thread.CurrentThread.CurrentUICulture.Name;

                if (string.IsNullOrEmpty(culture) == false && string.IsNullOrEmpty(uiCulture) == false)
                    languge = uiCulture;

                return languge.Substring(0, 2);
            }
        }

        /// <summary>
        /// Make name for thumbnail image
        /// </summary>
        /// <param name="path"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public static String MakeThumbnailName(String path, string suffix = "-mini")
        {
            string ext = Path.GetExtension(path);
            string fileNameNoExt = Path.GetFileNameWithoutExtension(path);
            string root = Path.GetDirectoryName(path);

            string newName = fileNameNoExt + suffix + ext;
            return String.Format(@"{0}\{1}", root, newName);
        }
        /// <summary>
        /// Delete image file from the folder
        /// </summary>
        /// <returns></returns>
        public static void DeleteImageFile(string imagePath)
        {
            string fullPath = HttpContext.Current.Server.MapPath(imagePath.Replace("~/", "/"));
            try
            {
                if (File.Exists(fullPath))
                    File.Delete(fullPath);
            }
            catch { }
        }

        #endregion

        #region Part 3: Base Method Controler Area
        /// <summary>
        /// Show message to user as result of his/her inputs
        /// </summary>
        /// <param name="_panel">Panel of message</param>
        /// <param name="_label">Label contains message</param>
        /// <param name="msg">The message</param>
        /// <param name="cssClass">The css class - last part ex: ok, error</param>
        public static void ShowMsg(Panel _panel, Label _label, string msg, string cssClass)
        {
            _panel.CssClass = string.Format("msg msg-{0}", cssClass);//error - ok
            _panel.Visible = true;
            _label.Text = msg;
        }
        /// <summary>
        /// Show multiple action message when the action is fail.
        /// </summary>
        /// <param name="message"></param>
        public static void NoAction(Label _label, string message)
        {
            _label.Text = message;
            _label.ForeColor = Color.Red;
            _label.Font.Bold = true;
        }

        /// <summary>
        /// Get the xml file path
        /// </summary>
        /// <param name="file">xml file name</param>
        /// <returns>the full xml file apth, ex: ~\App_data\en\file.xml</returns>
        public static string GetXmlFilePath(string file)
        {
            string language = CurrentCulture.Substring(0, 2);
            return HttpContext.Current.Server.MapPath("~") + @"\App_Data\" + string.Format(@"{0}\{1}", language, file);
        }

        /// <summary>
        /// Get the pagination info.
        /// </summary>
        /// <param name="lbInfo"></param>
        public static void GetPaginationInfo(Label lbInfo, int pageIndex, int pageCount)
        {
            lbInfo.Text = string.Format("{0} <b>{1}</b> {2} {3}", Properties.Resources.Page, pageIndex, Properties.Resources.Of, pageCount);
        }
        // Get the pagination info. with result count
        public static void GetPaginationInfo(Label lbInfo, int pageIndex, int pageCount, string resultTitle, int resultCount)
        {
            lbInfo.Text = string.Format("{0} <b>{1}</b> {2} {3} | {4}: <b>{5}</b>", Properties.Resources.Page, pageIndex, Properties.Resources.Of, pageCount, resultTitle, resultCount);
        }
        // Clear panel controls and keep them empty
        public static void ClearPanelControl(Control _panel)
        {
            foreach (Control c in _panel.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Text = string.Empty;
                if (c is DropDownList)
                    ((DropDownList)c).SelectedIndex = 0;
                if (c is CheckBox)
                    ((CheckBox)c).Checked = false;
            }
        }
        /// <summary>
        /// Calculate total pages for current records
        /// </summary>
        /// <param name="recordCount">Number of records</param>
        /// <param name="pageSize">The page size</param>
        /// <returns></returns>
        public static int CalculateTotalPages(int recordCount, int pageSize)
        {
            decimal decimalPages = Decimal.Divide((decimal)recordCount, (decimal)pageSize);
            return (int)(Math.Ceiling(decimalPages));
        }

        #endregion



    }// end class
}// end NS