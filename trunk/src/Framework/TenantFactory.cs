using System;
using StructureMap;
using StructureMap.TypeRules;

namespace BA.MultiMvc.Framework
{
    public static class TenantFactory
    {
       
        /// <summary>
        /// Create a new Service.
        /// The service can contain Repositories or other Services.  
        /// These dependencies can be injected via the constructor but they should also be exposed as properties 
        /// This will enable the TenantFactory to inject the apropriate dependencies. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Create<T>() where T : ITenantModel
        {
            return (T)Create(typeof(T));
        }

        public static ITenantModel Create(Type tenantModelType)
        {
            ITenantModel modelInstance;
            string tenantModelFullName = GetTenantModelFullName(tenantModelType);
            try
            {
                modelInstance = (ITenantModel)ObjectFactory.GetNamedInstance(typeof(ITenantModel), tenantModelFullName);
            }
            catch (StructureMapException)
            {
                try
                {
                    modelInstance = (ITenantModel)ObjectFactory.GetInstance(tenantModelType);
                }
                catch (Exception)
                {
                    return null;
                }
                
            }
            
            modelInstance = ConfigurationHelper.InjectTenantModelNamedInstance(modelInstance);

            return modelInstance;
        }

        private static string GetTenantModelFullName(Type tenantModelType)
        {

            if (tenantModelType.GetName().StartsWith("I",StringComparison.Ordinal))
                return TenantContext.TenantKey + tenantModelType.GetName().Remove(0, 1);

            return TenantContext.TenantKey + tenantModelType.GetName();
        }
    }
}