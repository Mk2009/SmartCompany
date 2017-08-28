using System;
using SmartSchool.Admin.Smart.Shared.WebUI.Captcha.Code.Cryptography;

namespace SmartSchool.Admin.Smart.Shared.WebUI.Captcha
{
    public delegate void CaptchaEventHandler();

    public partial class Captcha : System.Web.UI.UserControl
    {
        private string color = "#ffffff";
        protected string style;
        private event CaptchaEventHandler success;
        private event CaptchaEventHandler failure;

        #region Part 1: Captcha Properties Area
        /// <summary>
        /// Set and Get BackgroundColor for Captcha
        /// </summary>
        public string BackgroundColor
        {
            set { color = value.Trim("#".ToCharArray()); }
            get { return color; }
        }
        /// <summary>
        /// Set and Get Style for Captcha
        /// </summary>
        public string Style
        {
            set { style = value; }
            get { return style; }
        }
        /// <summary>
        /// Get captcha code
        /// </summary>
        public string CaptchaCode
        {
            get { return Session["captcha"].ToString(); }
        }

        #endregion

        #region Part 2: Captcha Event Handler Area

        public event CaptchaEventHandler Success
        {
            add { success += value; }
            remove { success += null; }
        }
        public event CaptchaEventHandler Failure
        {
            add { failure += value; }
            remove { failure += null; }
        }
        #endregion

        // 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetCaptcha();
            }
        }

        #region Part 3: Captcha Method Controller Area

        public void SetCaptcha()
        {
            // Set image
            string s = RandomText.Generate();

            // Encrypt
            string ens = Encryptor.Encrypt(s, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp"));

            // Save to session
            Session["captcha"] = s.ToLower();

            // Set url
            imgBtnCaptcha.ImageUrl = "CaptchaGenericHandler.ashx?w=200&h=48&c=" + ens + "&bc=" + color;
        }

        #endregion

        #region Part 4: Captcha Button Click Event Controller Area
        // Refresh
        protected void btnRefresh_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            SetCaptcha();
        }

        #endregion

        // Refresh when user click on captcha image
        protected void imgBtnCaptcha_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            this.SetCaptcha();
        }

    }// end class
}// end NS