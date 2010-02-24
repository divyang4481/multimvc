using System.Web.Mvc;
using BA.MultiMVC.Framework.Core;

namespace BA.MultiMVC.Framework.Core.MultiMVC.Sample.Controllers
{
    [HandleError]
    public class HomeController : BaseController
    {
        public virtual ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC on Default site!";

            return View();
        }

        public virtual ActionResult CheckForLanguage(string client)
        {
            if (Request == null ||
                Request.Cookies == null ||
                Request.Cookies["language"] == null ||
                Request.Cookies["language"].Value.Length != 2)
                return View();

            string language = Request.Cookies["language"].Value;
            return RedirectToAction("Index", new { language = language, client = client });
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
