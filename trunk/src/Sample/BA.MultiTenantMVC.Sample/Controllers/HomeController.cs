using System.Web.Mvc;
using System.Web.UI.WebControls;
using BA.MultiMvc.Framework.Core;
using BA.MultiTenantMVC.Sample.Models.ViewModel;

namespace BA.MultiMvc.Framework.Core.MultiMVC.Sample.Controllers
{
    [HandleError]
    public class HomeController : BaseController
    {
        protected virtual HomeVM HomeView
        {
            get
            {
              var view = new HomeVM();
              view.Message = "Welcome to ASP.NET MVC on Default site!";
              return view;
            }
        }

        public virtual ActionResult Index()
        {
            return View(HomeView);
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
