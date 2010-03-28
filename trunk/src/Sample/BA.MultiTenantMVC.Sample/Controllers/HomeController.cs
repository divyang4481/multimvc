using System.Web.Mvc;
using System.Web.UI.WebControls;
using BA.MultiMvc.Framework.Core;
using BA.MultiMvc.Sample.Models.ViewModel;

namespace BA.MultiMvc.Framework.Core.MultiMvc.Sample.Controllers
{
    [HandleError]
    public class HomeController : BaseController
    {
        protected virtual HomeVM HomeView
        {
            get
            {
              var view = new HomeVM();
              view.Message = "Welcome to ASP.NET Mvc on Default site!";
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
                return View("index",HomeView);

            string language = Request.Cookies["language"].Value;
            return RedirectToAction("Index", new { language = language, client = client });
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
