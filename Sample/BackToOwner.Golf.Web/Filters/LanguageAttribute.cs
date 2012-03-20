using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BA.MultiMvc.Framework;

namespace BackToOwner.Web.Filters
{
    
    public class LanguageFilterAttribute : ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.RouteData.Values["language"] != null)
            {
                var langCookie = new HttpCookie("lang", TenantContext.Language);
                langCookie.Expires = DateTime.Now.AddYears(1);
                filterContext.HttpContext.Response.Cookies.Add(langCookie);
            }
            base.OnActionExecuting(filterContext);
        }
    }
}