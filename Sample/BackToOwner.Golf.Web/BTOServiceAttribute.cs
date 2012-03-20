using System.Web.Mvc;

namespace BackToOwner.Golf.Web
{
    public class BTOServiceAttribute : FilterAttribute, IActionFilter
    {
        #region IActionFilter Members

        private const string contentTypeSupported = "application/vnd.bto+xml";

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Request.ContentType != contentTypeSupported)
            {
                filterContext.Result =
                    new HttpUnauthorizedResult("Only the type " + contentTypeSupported + " is supported!");
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.ContentType = contentTypeSupported;
        }

        #endregion
    }
}