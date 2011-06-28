﻿using System.Web.Mvc;
using BA.MultiMvc.Framework;
using BA.MultiMvc.Sample.Models.ViewModel;

namespace BA.MultiMvc.Sample.Controllers
{
    [HandleError]
    public class HomeController : BaseController
    {
        protected virtual HomeVM HomeView
        {
            get
            {
                var view = new HomeVM(this.Context,this.Resources);
                view.Message = "Welcome to ASP.NET Mvc on Default site!";
                return view;
            }
        }

        public virtual ActionResult Index()
        {
            return View(HomeView);
        }

        public virtual ActionResult CheckForLanguage(string tenantKey)
        {
            if (Request == null ||
                Request.Cookies == null ||
                Request.Cookies["language"] == null ||
                Request.Cookies["language"].Value.Length != 2)
                return View("index",HomeView);

            string language = Request.Cookies["language"].Value;

            Response.Redirect("~/" + tenantKey + "/" + language);

            return null;
        }

        public ActionResult About()
        {
            return View();
        }
    }
}