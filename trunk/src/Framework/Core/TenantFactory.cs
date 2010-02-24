using System;
using BA.MultiMVC.Framework.Core;
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

        public T CreateRepository<T>() where T : IRepository
        {
            return (T)CreateRepository(typeof(T));
        }

        public IRepository CreateRepository(Type T)
        {
            IRepository repInstance;
            var repositoryName = Context.TenantKey + T.GetName().Remove(0, 1).Replace("Repository", "");
            try
            {
                repInstance = (IRepository)ObjectFactory.GetNamedInstance(typeof(IRepository), repositoryName);
            }
            catch (StructureMapException)
            {
                repInstance = (IRepository)ObjectFactory.GetInstance(T);
            }

            repInstance.ConnectionString = Context.ConnectionString;
            return repInstance;
        }

        /// <summary>
        /// Create a new Service.
        /// The service can contain Repositories or other Services.  
        /// These dependencies can be injected via the constructor but they should also be exposed as properties 
        /// This will enable the TenantFactory to inject the apropriate dependencies. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T CreateService<T>() where T : IService
        {
            return (T)CreateService(typeof(T));
        }

        public IService CreateService(Type T)
        {
            IService serviceInstance;
            var serviceName = Context.TenantKey + T.GetName().Remove(0, 1).Replace("Service", "");
            try
            {
                serviceInstance = (IService)ObjectFactory.GetNamedInstance(typeof(IService), serviceName);
            }
            catch (StructureMapException)
            {
                serviceInstance = (IService)ObjectFactory.GetInstance(T);
            }
            return Configurator<IService>.InjectNamedInstanceOfRepositoriesAndServicesIntoSubject(Context, serviceInstance);
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