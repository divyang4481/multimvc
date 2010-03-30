using System.Web;
using BA.MultiMvc.Framework.Core.MultiMvc.Sample.Models.Domain;
using BA.MultiMvc.Framework.Core.MultiMvc.Sample.Models.Infrastructure;
using BA.MultiMvc.Framework.Core;
using BA.MultiMvc.Test.Util.Stubs;
using StructureMap;

namespace BA.MultiMvc.Framework.IntegrationTests
{
    public static class BootstrapperForIntegrationTest
    {
        #region Methods

        public static void ConfigureStructureMap(string extensionPath)
        {
            ObjectFactory.Initialize(x =>
             {
                 x.AddRegistry(new UnitTestRegistry(extensionPath));
             });
        }

        #endregion Methods
    }

    public class UnitTestRegistry : ExtensionRegistry
    {
        #region Constructors

        public UnitTestRegistry(string extensionPath)
        {
            ForRequestedType<User>()
                .TheDefaultIsConcreteType<User>();
            ForRequestedType<IMembershipService>()
                .TheDefaultIsConcreteType<MembershipService>();
            ForRequestedType<IUserRepository>()
                .TheDefaultIsConcreteType<UserRepository>();
            ForRequestedType<IResourceProviderService>()
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