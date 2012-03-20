using System;
using System.Runtime.Serialization;
using System.Web.Mvc;
using BackToOwner.Golf.Web.ViewModels;


namespace BackToOwner.Golf.Web.Binders
{
    public class ServiceInitBinder:IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(ServiceInit));
            try
            {
                return (ServiceInit)serializer.ReadObject(controllerContext.HttpContext.Request.InputStream);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}