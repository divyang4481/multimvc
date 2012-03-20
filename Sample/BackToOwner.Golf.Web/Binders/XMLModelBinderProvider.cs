using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace BackToOwner.Golf.Web.Binders
{
    public class XMLModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(Type modelType)
        {
            var contentType = HttpContext.Current.Request.ContentType;

            if (string.Compare(contentType, @"text/xml",
                StringComparison.OrdinalIgnoreCase) != 0)
            {
                return null;
            }

            return new XMLModelBinder();
        }
    }

    public class XMLModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var modelType = bindingContext.ModelType;
            var serializer = new XmlSerializer(modelType);

            var inputStream = controllerContext.HttpContext.Request.InputStream;

            return serializer.Deserialize(inputStream);
        }
    }
}