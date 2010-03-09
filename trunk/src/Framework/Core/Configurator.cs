using System.Reflection;
using BA.MultiMVC.Framework.Core;
using BA.MultiMVC.Framework.Helpers;
using StructureMap;

namespace BA.MultiMVC.Framework.Core
{
    public static class Configurator<T>
    {
        public static T InjectDomainFactoryNamedInstanceIntoSubject(string tenantKey, T subject)
        {
            return ConfigureDomainFactory(tenantKey, InjectDomainFactory(tenantKey, subject));
        }

        public static T InjectNamedInstanceOfRepositoriesAndServicesIntoSubject(TenantContext context, T subject)
        {
            var properties = subject.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (property.Name.IndexOf("Repository") > -1)
                {
                    if (context.TenantKey != null) subject = InjectRepository(context, subject, property);
                }
                if (property.Name.IndexOf("Service") > -1)
                {
                    if (context.TenantKey != null) subject = InjectService(context, subject, property);
                }
            }
            return subject;
        }

        public static void SetContextOnObjectTree(IService serviceInstance, TenantContext context)
        {
            serviceInstance.Context = context;
            var serviceProperties = serviceInstance.FindProperties(typeof(IService));
            foreach (var property in serviceProperties)
            {
                var childServiceInstance = ((IService)property.GetValue(serviceInstance, null));
                childServiceInstance.Context = context;
                SetContextOnObjectTree(childServiceInstance,context);
            }
        }

        private static T InjectDomainFactory(string tenantKey, T controller)
        {
            var domainFactoryPropertyInfo = controller.GetType().GetProperty("DomainFactory");
            if (domainFactoryPropertyInfo != null)
            {
                try
                {
                    var domainFactoryPlugin = ObjectFactory.GetNamedInstance(
                                                  typeof(TenantFactory), tenantKey
                                                  ) as TenantFactory;
                    if (domainFactoryPlugin != null)
                        domainFactoryPropertyInfo.SetValue(controller, domainFactoryPlugin, null);
                    
                }
                catch (StructureMapException ex)
                {}
            }
            return controller;
        }

        private static T ConfigureDomainFactory(string tenantKey, T controller)
        {
            var domainFactoryPropertyInfo = controller.GetType().GetProperty("DomainFactory");
            if (domainFactoryPropertyInfo !=null)
            {
                var domainFactory = domainFactoryPropertyInfo.GetValue(controller, null) as TenantFactory;
                if (domainFactory!=null)
                {
                    SetClientNameOnDomainFactory(tenantKey, domainFactory);
                }
            }
            return controller;

        }

       

        

        private static T InjectRepository(TenantContext context, T o, PropertyInfo property)
        {
            if (property.Name.IndexOf("Repository") > -1)
            {
                var repositoryName = context.TenantKey + property.Name.Replace("Repository", "");

                try
                {
                    var pluginRepository = ObjectFactory.GetNamedInstance(typeof(IRepository), repositoryName) as IRepository;
                    if (pluginRepository != null)
                        property.SetValue(o, pluginRepository, null);

                }
                catch (StructureMapException)
                { }

                var repositoryProperty = property.GetValue(o, null) as IRepository;
                if (repositoryProperty != null)
                {
                    repositoryProperty.ConnectionString = context.ConnectionString;
                    return o;
                }
            }
            return o;
        }

        private static T InjectService(TenantContext context, T obj, PropertyInfo property)
        {
            if (property.Name.IndexOf("Service") > -1)
            {
                string repositoryName = context.TenantKey  + property.Name.Replace("Service", "");

                try
                {
                    var pluginService = ObjectFactory.GetNamedInstance(typeof(IService), repositoryName) as IService;
                    if (pluginService != null)
                    {
                        property.SetValue(obj, pluginService, null);
                        Configurator<IService>.InjectNamedInstanceOfRepositoriesAndServicesIntoSubject(context, pluginService);
                    }
                }
                catch (StructureMapException)
                { }

                property.GetValue(obj, null);

                return obj;
            }
            return obj;
        }

        private static void SetClientNameOnDomainFactory(string tenantKey, TenantFactory domainFactory)
        {
            var domainFactoryInfrastructureProperty =
                domainFactory.GetType().GetProperty("TenantKey");

            domainFactoryInfrastructureProperty.SetValue(domainFactory, tenantKey,null);
        }

    }
}