using System.Web;
using BA.MultiMvc.Framework.Core.MultiMvc.Sample.Models.Domain;
using BA.MultiMvc.Framework.Core.MultiMvc.Sample.Models.Infrastructure;
using BA.MultiMvc.Framework.Core;
using BA.MultiMvc.Framework.Ressources;
using BA.MultiMvc.Test.Util.Stubs;
using StructureMap;
using BA.MultiMvc.Framework.Caching;

namespace BA.MultiMvc.Framework.UnitTests
{
    public static class BootstrapperForUnitTest
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