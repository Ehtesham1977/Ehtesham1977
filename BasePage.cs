using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;
using System;

namespace ASPNetMultiLanguage
{
    /// <summary>
    /// Purpose: This class created as a base class. Whenever you want to implement multi-language for any page then should be inherited
    /// Create by: chien.vh@gmail.com
    /// Skype: chien.vh
    /// Date: 05/03/2013
    /// </summary>
    public class BasePage : System.Web.UI.Page
    {
        protected override void InitializeCulture()
        {
            if (!string.IsNullOrEmpty(Request["lang"]))
            {
                Session["lang"] = Request["lang"];
            }
            string lang = Convert.ToString(Session["lang"]);
            string culture = string.Empty;
            /* // In case, if you want to set vietnamese as default language, then removing this comment
            if (lang.ToLower().CompareTo("vi") == 0 || string.IsNullOrEmpty(culture))
            {
                culture = "vi-VN";
            }
             */
            if (lang.ToLower().CompareTo("en") == 0 || string.IsNullOrEmpty(culture))
            {
                culture = "en-US";
            }
            if (lang.ToLower().CompareTo("vi") == 0)
            {
                culture = "vi-VN";
            }
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            base.InitializeCulture();
        }
    }
}