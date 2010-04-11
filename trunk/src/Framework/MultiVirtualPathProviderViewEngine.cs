﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace BA.MultiMvc.Framework
{
   
    [AspNetHostingPermission(System.Security.Permissions.SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    public abstract class MultiVirtualPathProviderViewEngine : IViewEngine
    {
        // format is ":ViewCacheEntry:{cacheType}:{prefix}:{name}:{controllerName}:{TenantKey}"
        private const string CacheKeyFormat = ":ViewCacheEntry:{0}:{1}:{2}:{3}:{4}";
        private const string CacheKeyPrefixMaster = "Master";
        private const string CacheKeyPrefixPartial = "Partial";
        private const string CacheKeyPrefixView = "View";
        private static readonly string[] EmptyLocations = new string[0];

        private VirtualPathProvider _vpp;

        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
        public string[] MasterLocationFormats
        {
            get;
            set;
        }

        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
        public string[] PartialViewLocationFormats
        {
            get;
            set;
        }

        public IViewLocationCache ViewLocationCache
        {
            get;
            set;
        }

        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
        public string[] ViewLocationFormats
        {
            get;
            set;
        }

        protected VirtualPathProvider VirtualPathProvider
        {
            get
            {
                if (_vpp == null)
                {
                    _vpp = HostingEnvironment.VirtualPathProvider;
                }
                return _vpp;
            }
            set
            {
                _vpp = value;
            }
        }

        protected MultiVirtualPathProviderViewEngine()
        {
            if (HttpContext.Current == null || HttpContext.Current.IsDebuggingEnabled)
            {
                ViewLocationCache = DefaultViewLocationCache.Null;
            }
            else
            {
                ViewLocationCache = new DefaultViewLocationCache();
            }
        }

        private string CreateCacheKey(string prefix, string name, string controllerName,string tenantName)
        {
            return String.Format(CultureInfo.InvariantCulture, CacheKeyFormat,
                                 GetType().AssemblyQualifiedName, prefix, name, controllerName, tenantName);
        }

        protected abstract IView CreatePartialView(ControllerContext controllerContext, string partialPath);

        protected abstract IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath);

        protected virtual bool FileExists(ControllerContext controllerContext, string virtualPath)
        {
            return VirtualPathProvider.FileExists(virtualPath);
        }

        public virtual ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            if (controllerContext == null)
            {
                throw new ArgumentNullException("controllerContext");
            }
            if (String.IsNullOrEmpty(partialViewName))
            {
                throw new ArgumentException("partialViewName");
            }

            string[] searched;
            string controllerName = controllerContext.RouteData.GetRequiredString("controller");
            string partialPath = GetPath(controllerContext, PartialViewLocationFormats, "PartialViewLocationFormats", partialViewName, controllerName, CacheKeyPrefixPartial, useCache, out searched);

            if (String.IsNullOrEmpty(partialPath))
            {
                return new ViewEngineResult(searched);
            }

            return new ViewEngineResult(CreatePartialView(controllerContext, partialPath), this);
        }

        public virtual ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            if (controllerContext == null)
            {
                throw new ArgumentNullException("controllerContext");
            }
            if (String.IsNullOrEmpty(viewName))
            {
                throw new ArgumentException("Viewname is null or empty!", "viewName");
            }

            string[] viewLocationsSearched;
            string[] masterLocationsSearched;

            string controllerName = controllerContext.RouteData.GetRequiredString("controller");
            string viewPath = GetPath(controllerContext, ViewLocationFormats, "ViewLocationFormats", viewName, controllerName, CacheKeyPrefixView, useCache, out viewLocationsSearched);
            string masterPath = GetPath(controllerContext, MasterLocationFormats, "MasterLocationFormats", masterName, controllerName, CacheKeyPrefixMaster, useCache, out masterLocationsSearched);

            if (String.IsNullOrEmpty(viewPath) || (String.IsNullOrEmpty(masterPath) && !String.IsNullOrEmpty(masterName)))
            {
                return new ViewEngineResult(viewLocationsSearched.Union(masterLocationsSearched));
            }

            return new ViewEngineResult(CreateView(controllerContext, viewPath, masterPath), this);
        }

        private string GetPath(ControllerContext controllerContext, string[] locations, string locationsPropertyName, string name, string controllerName, string cacheKeyPrefix, bool useCache, out string[] searchedLocations)
        {
            searchedLocations = EmptyLocations;
            string tenantKey = controllerContext.RouteData.GetTenantKey();
            
            if (String.IsNullOrEmpty(name))
            {
                return String.Empty;
            }

            if (locations == null || locations.Length == 0)
            {
                throw new InvalidOperationException(String.Format(CultureInfo.CurrentUICulture,
                                                                  "Property can not be null or empty", locationsPropertyName));
            }

            bool nameRepresentsPath = IsSpecificPath(name);
            string cacheKey = CreateCacheKey(cacheKeyPrefix, name, (nameRepresentsPath) ? String.Empty : controllerName, tenantKey);

            if (useCache)
            {
                string result = ViewLocationCache.GetViewLocation(controllerContext.HttpContext, cacheKey);
                if (result != null)
                {
                    return result;
                }
            }

            return (nameRepresentsPath) ?
                                            GetPathFromSpecificName(controllerContext, name, cacheKey, ref searchedLocations) :
                                                                                                                                  GetPathFromGeneralName(controllerContext, locations, name, controllerName, cacheKey, ref searchedLocations, tenantKey);
        }

        private string GetPathFromGeneralName(ControllerContext controllerContext, string[] locations, string name, string controllerName, string cacheKey, ref string[] searchedLocations, string tenantKey)
        {
            string result = String.Empty;
            searchedLocations = new string[locations.Length];

            for (int i = 0; i < locations.Length; i++)
            {
                string virtualPath = String.Format(CultureInfo.InvariantCulture, locations[i], name, controllerName,tenantKey);

                if (FileExists(controllerContext, virtualPath))
                {
                    searchedLocations = EmptyLocations;
                    result = virtualPath;
                    ViewLocationCache.InsertViewLocation(controllerContext.HttpContext, cacheKey, result);
                    break;
                }

                searchedLocations[i] = virtualPath;
            }

            return result;
        }

        private string GetPathFromSpecificName(ControllerContext controllerContext, string name, string cacheKey, ref string[] searchedLocations)
        {
            string result = name;

            if (!FileExists(controllerContext, name))
            {
                result = String.Empty;
                searchedLocations = new[] { name };
            }

            ViewLocationCache.InsertViewLocation(controllerContext.HttpContext, cacheKey, result);
            return result;
        }

        private static bool IsSpecificPath(string name)
        {
            char c = name[0];
            return (c == '~' || c == '/');
        }

        public virtual void ReleaseView(ControllerContext controllerContext, IView view)
        {
            IDisposable disposable = view as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}