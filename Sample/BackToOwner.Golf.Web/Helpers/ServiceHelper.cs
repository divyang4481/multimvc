using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BA.MultiMvc.Framework;

namespace BackToOwner.Web.Helpers
{
    public interface IServiceHelper
    {
        string Root { get; }
    }

    public class ServiceHelper:IServiceHelper
    {
        public string Root
        {
            get
            {
                return "http://" + HttpContext.Current.Request.Url.Host + "/" + TenantContext.TenantKey + "/Services/";
            }
        }
    }
}