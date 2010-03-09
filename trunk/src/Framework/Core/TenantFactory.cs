using System;
using BA.MultiMVC.Framework.Core;
using BA.MultiMVC.Framework.Helpers;
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
        public T CreateService<T>() where T : ITenantModel
        {
            return (T)CreateService(typeof(T));
        }

        public ITenantModel CreateService(Type T)
        {
            ITenantModel serviceInstance;
            var serviceName = Context.TenantKey + T.GetName().Remove(0, 1);
            try
            {
                serviceInstance = (ITenantModel)ObjectFactory.GetNamedInstance(typeof(ITenantModel), serviceName);
            }
            catch (StructureMapException)
            {
                serviceInstance = (ITenantModel)ObjectFactory.GetInstance(T);
            }
            
            serviceInstance = Configurator<ITenantModel>.InjectModelNamedInstance(Context, serviceInstance);

            Configurator<ITenantModel>.SetContextOnObjectTree(serviceInstance,this.Context);

            return serviceInstance;
        }

       

        public T CreateModel<T>() where T : IModel
        {
            return (T)CreateModel(typeof(T));
        }

        public IModel CreateModel(Type T)
        {
            IModel modelInstance;
            var modelName = Context.TenantKey + T.GetName();
            try
            {
                modelInstance = (IModel)ObjectFactory.GetNamedInstance(typeof(IModel), modelName);
            }
            catch (StructureMapException)
            {
                modelInstance = (IModel)ObjectFactory.GetInstance(T);
            }
            return modelInstance;
        }
    }
}