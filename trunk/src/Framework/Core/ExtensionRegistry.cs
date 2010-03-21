using System.IO;
using System.Web.Mvc;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace BA.MultiMvc.Framework.Core
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
                     });
            
        }

        #endregion Methods
    }
}