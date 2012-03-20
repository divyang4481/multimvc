using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BackToOwner.Golf.Web.Application;
using BackToOwner.Golf.Web.Controllers;
using BackToOwner.Golf.Web.Infrastructure;

namespace BackToOwner.Golf.Extensions
{
    public class BicycleHomeController:HomeController
    {
        public BicycleHomeController(ApplicationFacade applicationFacde, IMapperService mapperService):base(applicationFacde,mapperService)
        {}

        public override System.Web.Mvc.ActionResult Index()
        {
            Response.Write("Hello from bicycle home controller");
            return base.Index();
        }
    }
}
