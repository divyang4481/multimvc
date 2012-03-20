using System;
using System.Web.Mvc;
using BA.MultiMvc.Framework.NHibernate;
using BackToOwner.Golf.Web.Application;
using BackToOwner.Golf.Web.Infrastructure;
using BackToOwner.Golf.Web.Models;
using BA.MultiMvc.Framework;
using StructureMap;


namespace BackToOwner.Golf.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ApplicationFacade applicationFacde, IMapperService mapperService):base(applicationFacde)
        {}

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Faq()
        {
            return View();
        }

        public ActionResult Who()
        {
            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }

        public ActionResult Terms()
        {
            return View();
        }

        public ActionResult Dealers()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult EnterLabel()
        {
            return View();
        }

        public ContentResult RefreshCache()
        {
            ObjectFactory.GetInstance<NHCachedResourceProvider>().ClearCache();

            return Content("Cache refreshed!");
        }

        [HttpPost]
        public ActionResult EnterLabel(HomeIndexRequest request)
        {
            return Index(request);
        }

        public virtual ActionResult Index()
        {
            return View(new HomeIndexRequest());
        }

        [HttpPost]
        public virtual ActionResult Index(HomeIndexRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);
            
            try
            {
                this.ApplicationFacade.SetCurrentBadge(request.BadgeNbr);

                if (!this.ApplicationFacade.CurrentBadge.IsActive)
                {
                    this.ApplicationFacade.AddNewOwnerToSession(this.Language);
                    return RedirectToAction("Index", "Activate");
                }

                throw new NotImplementedException();
                
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message.ToLower().Contains("ip"))
                {
                    ModelState.AddModelError("BadgeNbr", TenantResources.Values["locked_ip"]);
                }

                ModelState.AddModelError("BadgeNbr", TenantResources.Values["err_invalidBadge"]);
                return View(request);
            }
           
        }

        
    }
}