using System.Reflection;
using StructureMap;

namespace BA.MultiMvc.Framework
{
    public static class ConfigurationHelper
    {
        /// <summary>
        /// Instantiate an object and inject all dependencies into the properties that are ITenantModel <see cref="ITenantModel"/>
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        public static ITenantModel InjectTenantModelNamedInstance(ITenantModel subject)
        {
            var properties = subject.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (IsATenantModelProperty(property))
                {
                    if (TenantContext.TenantKey != null) subject = InjectTenantModel(subject, property);
                }
            }
            return subject;
        }
        
        private static bool IsATenantModelProperty(PropertyInfo property)
        {
            return typeof (ITenantModel).IsAssignableFrom(property.PropertyType);
        }

        private static ITenantModel InjectTenantModel(ITenantModel obj, PropertyInfo property)
        {
            if (IsATenantModelProperty(property))
            {
                string teantPropertyName = TenantContext.TenantKey  + property.Name;

                try
                {
                    var pluginService = ObjectFactory.GetNamedInstance(typeof(ITenantModel), teantPropertyName) as ITenantModel;
                    if (pluginService != null)
                    {
                        property.SetValue(obj, pluginService, null);
                        InjectTenantModelNamedInstance(pluginService);
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