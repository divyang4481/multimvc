using System;
using System.Web;
using System.Web.Mvc;
using BA.MultiMVC.Framework.Core;

namespace BA.MultiTenantMVC.Sample.Controllers
{
    public class CultureController : BaseController
    {
        public ActionResult SetLanguage(string newLanguage, string actionName, string controllerName)
        {
            var languageCookie = new HttpCookie("language", newLanguage) { Expires = DateTime.Now.AddYears(1) };
            Response.Cookies.Add(
                languageCookie
                );
            return RedirectToAction(actionName, controllerName, new {language = newLanguage});
        }

    }
}
