using System.Web.Mvc;
using BA.MultiMvc.Framework;

namespace BackToOwner.Golf.Web.Controllers
{
    public class LandingController : Controller
    {
        //
        // GET: /Landing/

        public ActionResult Index()
        {
            if (Request.Cookies["lang"]!=null)
            {
                return Redirect("~/" + TenantContext.TenantKey+ ".mvc/" + Request.Cookies["lang"].Value);
            }
                
            return View();
        }

    }
}
