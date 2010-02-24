using System.Web.Mvc;
using StructureMap.Configuration.DSL;

namespace BA.MultiMVC.Framework.Core
{
    public abstract class ExtensionRegistry : Registry
    {
        #region Methods

        protected void ScanControllersAndRepositoriesFromPath(string path)
        {
            Scan(o =>
                     {
                         o.AssembliesFromPath(path);
                         o.AddAllTypesOf<BaseController>().NameBy(type => type.Name.Replace("Controller", ""));
                         o.AddAllTypesOf<IRepository>().NameBy(type => type.Name.Replace("Repository", ""));
                         o.AddAllTypesOf<IService>().NameBy(type => type.Name.Replace("Service", ""));
                         o.AddAllTypesOf<TenantFactory>().NameBy(type => type.Name.Replace("SaasFactory",""));
                         o.AddAllTypesOf<IModel>().NameBy(type=> type.Name);
                     });
        }

        #endregion Methods
    }
}