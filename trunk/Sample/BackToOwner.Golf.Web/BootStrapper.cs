using System.Web;
using BA.MultiMvc.Framework;
using BA.MultiMvc.Framework.NHibernate;
using BackToOwner.Golf.Web.Infrastructure;
using BackToOwner.Golf.Web.Models;
using BackToOwner.Web.Helpers;
using StructureMap;


namespace BackToOwner.Golf.Web
{
    public static class Bootstrapper
    {
        #region Methods

        public static void ConfigureStructureMap(string extensionPath)
        {
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry(new SampleRegistry(extensionPath));
            });
            
        }

        public static string ExtensionPath
        {
            get
            {
                return HttpContext.Current.Server.MapPath("~/Bin");
            }
        }
        #endregion Methods
    }

    public class SampleRegistry : ExtensionRegistry
    {
        #region Constructors

        public SampleRegistry(string extensionPath)
        {
            For<IRepository<Declaration>>().Use<Repository<Declaration>>();
            For<IRepository<Owner>>().Use<Repository<Owner>>();
            For<IRepository<Badge,string>>().Use<Repository<Badge,string>>();
            For<IMapperService>().Use<DefaultMapperService>();
            For<IServiceHelper>().Use<ServiceHelper>();
            For<ISessionService>().Use<SessionService>();
            For<ISecurityService>().Use<SecurityService>();
            For<IDistributorService>().Use<DistributorService>();
            For<ISmsService>().Use<ClickatelSmsService>();
            For<IMailService>().Use<MailService>();
            For<ILoggerService>().Use<Log4NetLoggerService>();
            For<ISecurityService>().Use<SecurityService>();
            For<IAuthenticationService>().Use<AuthenticationService>();
            For<IMailFactory>().Use<MailFactory>();
            For<ICacheService>().Use<DefaultCacheService>();
            SelectConstructor(() => new Repository<Badge,string>());
            SelectConstructor(() => new Repository<Declaration>());
            SelectConstructor(() => new Repository<Owner>());
            ScanResourceCreation();
            ScanControllersAndRepositoriesFromPath(extensionPath);
        }



        #endregion Constructors
    }

   
}