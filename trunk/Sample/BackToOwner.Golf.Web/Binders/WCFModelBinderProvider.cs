using System;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;

namespace BackToOwner.Golf.Web.Binders
{
    public class WCFModelBinderProvider:IModelBinderProvider
    {
        public IModelBinder GetBinder(Type modelType)
        {
            var contentType = HttpContext.Current.Request.ContentType;

            if (string.Compare(contentType, @"text/xml",
                StringComparison.OrdinalIgnoreCase) != 0)
            {
                return null;
            }

            return new WCFModelBinder();
        }
    }

    public class WCFModelBinder:IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            DataContractSerializer serializer = new DataContractSerializer(bindingContext.ModelType);
            try
            {
                return serializer.ReadObject(controllerContext.HttpContext.Request.InputStream);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}