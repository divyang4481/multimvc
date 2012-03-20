using System;
using System.Web;
using BA.MultiMvc.Framework;

namespace BackToOwner.Golf.Web.Infrastructure
{
    public interface ISessionService : ITenantModel
    {
        Object this[string key] { get; set; }
        string Ip { get; }
    }

    public class SessionService:ISessionService
    {
        public object this[string key]
        {
            get { return HttpContext.Current.Session[key]; }
            set { HttpContext.Current.Session[key] = value; }
        }

        #region ISessionService Members


        public string Ip
        {
            get { return HttpContext.Current.Request.UserHostAddress; }
        }

        #endregion
    }
}