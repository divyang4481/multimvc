using System.Web;
using BA.MultiMvc.Framework.Core.MultiMVC.Sample.Models.Domain;
using BA.MultiMvc.Framework.Core.MultiMVC.Sample.Models.Infrastructure;
using BA.MultiMvc.Framework.Core;
using BA.MultiMvc.Framework.Ressources;
using BA.MultiTenantMVC.Framework.UnitTests.Ressources;
using StructureMap;
using BA.MultiMvc.Framework.Caching;

namespace BA.MultiTenantMVC.Framework.UnitTests
{
    public static class BootstrapperForTest
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
                return HttpContext.Current.Server.MapPath("~/Extensions");
            }
        }
        #endregion Methods
    }

    public class SampleRegistry : ExtensionRegistry
    {
        #region Constructors

        public SampleRegistry(string extensionPath)
        {
            ForRequestedType<User>()
                .TheDefaultIsConcreteType<User>();
            ForRequestedType<IMembershipService>()
                .TheDefaultIsConcreteType<MembershipService>();
            ForRequestedType<IUserRepository>()
                .TheDefaultIsConcreteType<UserRepository>();
            ForRequestedType<IRessourceProviderService>()
                .TheDefaultIsConcreteType<RessourceProviderService>();
            ForRequestedType<IRessourceRepository>()
                .TheDefaultIsConcreteType<RessourceRepositoryStub>();
            ForRequestedType<ICacheService>()
                .TheDefaultIsConcreteType<DefaultCacheService>();


            ScanControllersAndRepositoriesFromPath(extensionPath);
        }



        #endregion Constructors
    }
}