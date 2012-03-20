using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BA.MultiMvc.Framework;

namespace BackToOwner.Golf.Web.Filters
{
    public class LogExceptionAttribute:IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            Logger.Error(filterContext.Exception);
        }
    }
}