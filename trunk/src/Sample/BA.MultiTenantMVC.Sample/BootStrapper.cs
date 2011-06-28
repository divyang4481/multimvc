using System.Web;
using BA.MultiMvc.Framework;
using BA.MultiMvc.Sample.Controllers;
using BA.MultiMvc.Sample.Models.Infrastructure.Linq;
using StructureMap;
using BA.MultiMvc.Sample.Models.Infrastructure;

namespace BA.MultiMvc.Sample
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
            ForRequestedType<BA.MultiMvc.Framework.IMembershipService>()
                .TheDefaultIsConcreteType<AccountMembershipService>();
            ForRequestedType<IUserRepository>()
                .TheDefaultIsConcreteType<UserRepository>();
            ForRequestedType<IResourceProvider>().TheDefaultIsConcreteType<ResourceProvider>();
            ForRequestedType<ICacheService>().TheDefaultIsConcreteType<DefaultCacheService>();
            ForRequestedType<IFormsAuthenticationService>()
                .TheDefaultIsConcreteType<FormsAuthenticationService>();

            SelectConstructor(() => new AccountMembershipService());

            ScanControllersAndRepositoriesFromPath(extensionPath);
        }

       

        #endregion Constructors
    }
}