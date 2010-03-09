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
                         o.AddAllTypesOf<ITenantModel>().NameBy(type => type.Name);
                         o.AddAllTypesOf<IModel>().NameBy(type=> type.Name);
                     });
        }

        #endregion Methods
    }
}