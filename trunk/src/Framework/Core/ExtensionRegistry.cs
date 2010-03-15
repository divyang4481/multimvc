using System.IO;
using System.Web.Mvc;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace BA.MultiMVC.Framework.Core
{
    public abstract class ExtensionRegistry : Registry
    {
        #region Methods

        protected void ScanControllersAndRepositoriesFromPath(string path)
        {
            var extensions = new Extensions(path);
            var binDirs =extensions.GetBinDirectories();
            foreach(var dir in binDirs)
            {
                Scan(o =>
                     {
                         o.AssembliesFromPath(dir.FullName);
                         o.AddAllTypesOf<BaseController>().NameBy(type => type.Name.Replace("Controller", ""));
                         o.AddAllTypesOf<ITenantModel>().NameBy(type => type.Name);
                     });
            }
        }

        #endregion Methods
    }
}