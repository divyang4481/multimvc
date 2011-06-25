using System;
using StructureMap;
using StructureMap.TypeRules;

namespace BA.MultiMvc.Framework
{
    public  class TenantFactory
    {
        public TenantFactory(TenantContext context)
        {
            Context  = context;
        }

        public TenantContext Context
        {
            get;
            set;
        }

        /// <summary>
        /// Create a new Service.
        /// The service can contain Repositories or other Services.  
        /// These dependencies can be injected via the constructor but they should also be exposed as properties 
        /// This will enable the TenantFactory to inject the apropriate dependencies. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Create<T>() where T : ITenantModel
        {
            return (T)Create(typeof(T));
        }

        public ITenantModel Create(Type tenantModelType)
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
            
            modelInstance = ConfigurationHelper.InjectTenantModelNamedInstance(Context, modelInstance);

            ConfigurationHelper.SetContextOnObjectTree(modelInstance,Context);

            return modelInstance;
        }

        private string GetTenantModelFullName(Type tenantModelType)
        {

            if (tenantModelType.GetName().StartsWith("I",StringComparison.Ordinal))
                return Context.TenantKey + tenantModelType.GetName().Remove(0, 1);

            return Context.TenantKey + tenantModelType.GetName();
        }
    }
}