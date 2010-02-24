using System.Web.Mvc;
using BA.MultiMVC.Framework.Core.MultiMVC.Sample.Controllers;

namespace BA.MultiMVC.Framework.Core.MultiMVC.Sample.Extensions.Contoso.Controllers
{
    [HandleError]
    public class ContosoHomeController : HomeController
    {
        public override ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC on Contoso site!";

            return View();
        }
    }
}

