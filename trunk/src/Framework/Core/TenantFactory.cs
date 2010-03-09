using System;
using StructureMap;

namespace BA.MultiMVC.Framework.Core
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

        public ITenantModel Create(Type T)
        {
            ITenantModel modelInstance;
            string tenantModelFullName = GetTenantModelFullName(T);
            try
            {
                modelInstance = (ITenantModel)ObjectFactory.GetNamedInstance(typeof(ITenantModel), tenantModelFullName);
            }
            catch (StructureMapException)
            {
                modelInstance = (ITenantModel)ObjectFactory.GetInstance(T);
            }
            
            modelInstance = Configurator.InjectTenantModelNamedInstance(Context, modelInstance);

            Configurator.SetContextOnObjectTree(modelInstance,this.Context);

            return modelInstance;
        }

        private string GetTenantModelFullName(Type T)
        {

            if (T.GetName().StartsWith("I"))
                return Context.TenantKey + T.GetName().Remove(0, 1);

            return Context.TenantKey + T.GetName();
        }
    }
}