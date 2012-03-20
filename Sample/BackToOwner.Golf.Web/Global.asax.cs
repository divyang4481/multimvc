using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BA.MultiMvc.Framework;
using BA.MultiMvc.Framework.NHibernate;
using BackToOwner.Golf.Web.Filters;
using BackToOwner.Golf.Web.Infrastructure;
using BA.MultiMVC.Framework.NHibernate;
using BackToOwner.Golf.Web.Binders;
using BackToOwner.Web.Filters;
using BackToOwner.Web.Setup;
using NHibernate;
using NHibernate.Context;
using StructureMap;

namespace BackToOwner.Golf.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        static MvcApplication()
        {
            SetupDBExecuted = new List<string>();
        }

        public static List<string> SetupDBExecuted; 

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LogExceptionAttribute());
            filters.Add(new LanguageFilterAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
           
            routes.MapRoute(
               "Service", // Route name
               "{tenantKey}.mvc/Services/{action}/{id}", // URL with parameters
               new { controller = "Services", action = "Init", id = UrlParameter.Optional } // Parameter defaults

               );
           
              routes.MapRoute(
                  "Full", // Route name
                  "{tenantKey}.mvc/{language}/{controller}/{action}/{id}", // URL with parameters
                  new { controller = "home", action = "Index", id = UrlParameter.Optional }
                  );
              
               routes.MapRoute(
                "Landing",
                "{tenantKey}.mvc", // URL with parameters
                new { tenantKey="default",controller = "Landing", action = "Index" }
                      // Parameter defaults
                );

               routes.MapRoute(
                  "Default",
                  "", // URL with parameters
                  new { tenantKey = "default", controller = "Landing", action = "Index" }
                   // Parameter defaults
                  );
               

             
        }

        public static void RegisterViewEngines(ViewEngineCollection viewEngines)
        {
            viewEngines.Clear();
            viewEngines.Add(new MultiRazorViewEngine());
        }

        protected void Application_Start()
        { 
             
            log4net.Config.XmlConfigurator.Configure();
            
            RegisterRoutes(RouteTable.Routes);


            RegisterGlobalFilters(GlobalFilters.Filters);

            RegisterViewEngines(ViewEngines.Engines);

            Logger.SetLoggerService(new Log4NetLoggerService());
            Bootstrapper.ConfigureStructureMap(Bootstrapper.ExtensionPath);
            Logger.Info("Application Started");
            Logger.Debug(ObjectFactory.WhatDoIHave());



            ControllerBuilder.Current.SetControllerFactory(
              new ExtensionControllerFactory()
              );

            TenantContext.SetTenantContextProvider(new HttpTenantContextProvider());
            TenantResources.SetTenantResourceProvider(ObjectFactory.GetInstance<NHCachedResourceProvider>());

            ModelBinderProviders.BinderProviders.Add(new XMLModelBinderProvider());
            NHHelper.NHMappingFileRootAssemblyName = "BackToOwner.Golf.Web";

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            
            //Check if db connectionstring is present
            if (String.IsNullOrEmpty(TenantContext.TenantKey) || !DBConnectionStringIsPresentInWebConfig(TenantContext.TenantKey))
            {
                return;
            }

            // Should setup the db the first time it's hit
            if (SetupDBExecuted.Find(n => n == TenantContext.TenantKey) == null)
            {
                SetupDB();
                InsertResources();
                SetupDBExecuted.Add(TenantContext.TenantKey);
            }

            if (!SetupDBExecuted.Contains(TenantContext.TenantKey))
            {
                InsertResources();
                SetupDBExecuted.Add(TenantContext.TenantKey);
            }

            ISession session = NHHelper.GetSessionFactoryFor(TenantContext.TenantKey).OpenSession();
            CurrentSessionContext.Bind(session);
        }

    

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            //Check if db connectionstring is present
            if (String.IsNullOrEmpty(TenantContext.TenantKey) ||!DBConnectionStringIsPresentInWebConfig(TenantContext.TenantKey))
                return;

            if (ConfigurationManager.ConnectionStrings["db" + TenantContext.TenantKey.ToLower()] == null)
                return;

            var session = CurrentSessionContext.Unbind(NHHelper.GetSessionFactoryFor(TenantContext.TenantKey));
            if (session!=null) session.Dispose();
            
        }

      

        private static bool DBConnectionStringIsPresentInWebConfig(string tenantKey)
        {
            return ConfigurationManager.ConnectionStrings["db" + tenantKey.ToLower()] != null;
        }

        private void SetupDB()
        {
            // Setup DB
            string sqlRootFolder = ConfigurationManager.AppSettings["SqlRootFolder"];
            string sqlServerName = ConfigurationManager.AppSettings["SqlServerName"];

            NHHelper.CreateShemaExportFile(HttpContext.Current.Server.MapPath("CreateSchema.sql"), TenantContext.TenantKey);
            CreateDb dbsetup = new CreateDb(sqlRootFolder, TenantContext.DbName, sqlServerName, HttpContext.Current.Server.MapPath("CreateSchema.sql"));
            if (!dbsetup.DBExist())
                dbsetup.Execute(TenantContext.TenantKey);
        }

        private void InsertResources()
        {
            ISession session = NHHelper.GetSessionFactoryFor(TenantContext.TenantKey).OpenSession();
            var resourceCreation =
                ObjectFactory.With("currentSession").EqualTo(session).GetInstance<NHResourceCreation>(TenantContext.TenantKey);
            resourceCreation.InsertOrUpdate();
            session.Flush();
            session.Close();
        }
    }

    public class StructureMapDependencyResolver:IDependencyResolver
    {
        #region IDependencyResolver Members

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class RazorMultiViewPageActivator : IViewPageActivator
    {

        #region IViewPageActivator Members

        public object Create(ControllerContext controllerContext, Type type)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

}