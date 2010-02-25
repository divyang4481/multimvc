using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;
using BA.MultiMVC.Framework.Core;

namespace BA.MultiMVC.Framework.Culture
{
    public class CultureController : BaseController
    {
        public ActionResult SetLanguage(string newLanguage, string actionName, string controllerName)
        {
            var languageCookie = new HttpCookie("language", newLanguage) { Expires = DateTime.Now.AddYears(1) };
            Response.Cookies.Add(
                languageCookie
                );
            return RedirectToAction(actionName, controllerName, new { language = newLanguage });
        }

    }
}
