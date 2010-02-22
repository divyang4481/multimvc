using BA.MultiMVC.Sample.Models.Domain;
using BA.MultiMVC.Sample.Models.Infrastructure;
using BA.MultiMVC.Core;
using StructureMap;
using BA.MultiMVC.Ressources;

namespace BA.MultiMVC.Sample
{
    public static class Bootstrapper
    {
        #region Methods

        public static void ConfigureStructureMap()
        {
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry(new SampleRegistry());
            });
        }

        #endregion Methods
    }

    public class SampleRegistry : ExtensionRegistry
    {
        #region Constructors

        public SampleRegistry()
        {
            ForRequestedType<User>()
                .TheDefaultIsConcreteType<User>();
            ForRequestedType<IMembershipService>()
                .TheDefaultIsConcreteType<MembershipService>();
            ForRequestedType<IUserRepository>()
                .TheDefaultIsConcreteType<UserRepository>();
            ForRequestedType<IRessourceProvider>()
                .TheDefaultIsConcreteType<RessourceRepository>();

            ScanControllersAndRepositoriesFromPath(".");
        }

        #endregion Constructors
    }
}
