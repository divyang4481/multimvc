using System.Web.Mvc;
using BackToOwner.Web.Setup;
using StructureMap.Configuration.DSL;

namespace BA.MultiMvc.Framework
{
    public abstract class ExtensionRegistry : Registry
    {
        #region Methods

        protected void ScanControllersAndRepositoriesFromPath(string path)
        {
            Scan(o =>
                     {
                         o.AssembliesFromPath(path);
                         o.AddAllTypesOf<Controller>().NameBy(type => type.Name.Replace("Controller", ""));
                         o.AddAllTypesOf<ITenantModel>().NameBy(type => type.Name);
                     });
            
        }

        protected void ScanResourceCreation()
        {
            Scan(o=>
                     {
                         o.AssembliesFromApplicationBaseDirectory();
                         o.AddAllTypesOf<NHResourceCreation>().NameBy(type => type.Name.Replace("ResourceCreation", ""));
                     });
        }
        #endregion Methods
    }
}