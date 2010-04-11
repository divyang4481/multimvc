using System.Web;
using BA.MultiMvc.Framework.Core.MultiMvc.Sample.Models.Domain;
using BA.MultiMvc.Sample.Controllers;
using BA.MultiMvc.Sample.Models.Infrastructure;
using BA.MultiMvc.Test.Util.Stubs;
using StructureMap;

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
                .TheDefaultIsConcreteType<AccountMembershipService>();
            ForRequestedType<IUserRepository>()
                .TheDefaultIsConcreteType<UserRepository>();
            ForRequestedType<IResourceProviderService>()
                .TheDefaultIsConcreteType<ResourceProviderService>();
            ForRequestedType<IResourceRepository>()
                .TheDefaultIsConcreteType<RessourceRepositoryStub>();
            ForRequestedType<ICacheService>()
                .TheDefaultIsConcreteType<DefaultCacheService>();

            SelectConstructor(()=>new AccountMembershipService());

            ScanControllersAndRepositoriesFromPath(extensionPath);
        }



        #endregion Constructors
    }
}