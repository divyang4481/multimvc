using System;
using System.Web.Mvc;
using BA.MultiMvc.Framework;
using BackToOwner.Golf.Web.Application;
using BackToOwner.Golf.Web.Infrastructure;
using BackToOwner.Golf.Web.Models;

namespace BackToOwner.Golf.Web.Controllers
{
    public class BaseController:Controller
    {
        protected readonly ApplicationFacade ApplicationFacade;
        
        public BaseController(ApplicationFacade applicationFacade)
        {
            this.ApplicationFacade = applicationFacade;
        }

        public Language Language
        {
            get { return (Language) Enum.Parse(typeof (Language), TenantContext.Language); }
        }

       
    }
}