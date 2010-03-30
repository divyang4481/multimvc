
using System;
using System.Collections;
using System.Web.Compilation;

namespace BA.MultiMvc.Framework
{
    internal sealed class BuildManagerWrapper : IBuildManager
    {
        #region IBuildManager Members
        object IBuildManager.CreateInstanceFromVirtualPath(string virtualPath, Type requiredBaseType)
        {
            return BuildManager.CreateInstanceFromVirtualPath(virtualPath, requiredBaseType);
        }

        ICollection IBuildManager.GetReferencedAssemblies()
        {
            return BuildManager.GetReferencedAssemblies();
        }
        #endregion
    }

    public interface IBuildManager {
        object CreateInstanceFromVirtualPath(string virtualPath, Type requiredBaseType);
        ICollection GetReferencedAssemblies();
    }
}