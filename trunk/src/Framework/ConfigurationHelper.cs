using System.Reflection;
using BA.MultiMvc.Framework.Helpers;
using StructureMap;

namespace BA.MultiMvc.Framework
{
    public static class ConfigurationHelper
    {

        public static ITenantModel InjectTenantModelNamedInstance(TenantContext context, ITenantModel subject)
        {
            var properties = subject.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (IsATenantModelProperty(property))
                {
                    if (context.TenantKey != null) subject = InjectTenantModel(context, subject, property);
                }
            }
            return subject;
        }

        public static void SetContextOnObjectTree(ITenantModel serviceInstance, TenantContext context)
        {
            serviceInstance.Context = context;
            var serviceProperties = serviceInstance.FindProperties(typeof(ITenantModel));
            foreach (var property in serviceProperties)
            {
                var childServiceInstance = ((ITenantModel)property.GetValue(serviceInstance, null));
                childServiceInstance.Context = context;
                SetContextOnObjectTree(childServiceInstance,context);
            }
        }

        private static bool IsATenantModelProperty(PropertyInfo property)
        {
            return typeof (ITenantModel).IsAssignableFrom(property.PropertyType);
        }

        private static ITenantModel InjectTenantModel(TenantContext context, ITenantModel obj, PropertyInfo property)
        {
            if (IsATenantModelProperty(property))
            {
                string repositoryName = context.TenantKey  + property.Name;

                try
                {
                    var pluginService = ObjectFactory.GetNamedInstance(typeof(ITenantModel), repositoryName) as ITenantModel;
                    if (pluginService != null)
                    {
                        property.SetValue(obj, pluginService, null);
                        InjectTenantModelNamedInstance(context, pluginService);
                    }
                }
                catch (StructureMapException)
                { }

                property.GetValue(obj, null);

                return obj;
            }
            return obj;
        }

      

    }
}