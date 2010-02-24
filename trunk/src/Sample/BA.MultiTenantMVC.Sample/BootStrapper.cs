using System.Web;
using BA.MultiMVC.Framework.Core.MultiMVC.Sample.Models.Domain;
using BA.MultiMVC.Framework.Core.MultiMVC.Sample.Models.Infrastructure;
using BA.MultiMVC.Framework.Core;
using BA.MultiMVC.Framework.Ressources;
using StructureMap;

namespace BA.MultiMVC.Framework.Core.MultiMVC.Sample
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
            ForRequestedType<IRessourceProvider>()
                .TheDefaultIsConcreteType<RessourceRepository>();

            ScanControllersAndRepositoriesFromPath(extensionPath);
        }

       

        #endregion Constructors
    }
}
