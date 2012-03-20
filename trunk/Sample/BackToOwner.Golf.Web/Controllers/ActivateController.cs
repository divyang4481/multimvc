using System;
using System.Web.Mvc;
using BA.MultiMvc.Framework;
using BackToOwner.Golf.Web.Application;
using BackToOwner.Golf.Web.ViewModels;

namespace BackToOwner.Golf.Web.Controllers
{
    public class ActivateController : BaseController
    {
        public ActivateController(ApplicationFacade applicationFacade):base(applicationFacade)
        {}

        [HttpGet]
        public ActionResult Index()
        {
            if (this.ApplicationFacade.CurrentBadge == null)
            {
                throw new InvalidOperationException("Badge Nbr was not retrieved from Session!");
            }

            return View(new ActivateIndexRequest());
        }

        [HttpPost]
        public ActionResult Index(ActivateIndexRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);
            
            this.ApplicationFacade.HashOwnerPassword(request);

            return RedirectToAction("mobile");
        }

        [HttpGet]
        public ActionResult Mobile()
        {
            if (this.ApplicationFacade.CurrentBadge == null)
            {
                throw new InvalidOperationException("Badge Nbr was not retrieved from Session!");
            }

            return View(new ActivateMobileRequest());
        }
        
        [HttpPost]
        public ActionResult Mobile(ActivateMobileRequest request)
        {
            if (this.ApplicationFacade.CurrentBadge == null || this.ApplicationFacade.OwnerToBeActivate == null)
            {
                throw new InvalidOperationException("Badge Nbr or Owner not present in session!");
            }

            if (request.AcceptTerms == false)
            {
                ModelState.AddModelError("AcceptTerms", TenantResources.Values["err_accept_Terms"]);
            }

            if (!ModelState.IsValid)
                return View(request);
            
            

            this.ApplicationFacade.RegisterOwner(request);

            return RedirectToAction("confirm");
        }

        public ActionResult Confirm()
        {
            if (this.ApplicationFacade.CurrentBadge == null)
            {
                throw new InvalidOperationException("Badge Nbr was not retrieved from Session!");
            }

            ActivateConfirmRequest model = new ActivateConfirmRequest()
                                               {
                                                   ConfirmationMessage =
                                                       this.ApplicationFacade.CurrentBadge.
                                                       ActivationMailConfirmationBody
                                               };

            return View(model);
        } 
    }
}
