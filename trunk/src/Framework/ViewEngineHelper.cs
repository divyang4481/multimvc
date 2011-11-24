using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BA.MultiMvc.Framework
{
    /// <summary>
    /// Helper class that genericizes the logic for searching for a view based
    /// on pre-defined view location paths for the web application.
    /// </summary>
    internal class ViewEngineHelper
    {
        /// <summary>
        /// An empty string array.
        /// </summary>
        private static readonly string[] EmptyLocations = new string[0];

        /// <summary>
        /// The callback object that the helper can use to obtain information
        /// from the view engine.
        /// </summary>
        private readonly IViewEngineCallback _callback;

        /// <summary>
        /// Initializes a new instance of the ViewEngineHelper class.
        /// </summary>
        /// <param name="callback">
        /// The <see cref="IViewEngineCallback"/> object for the view engine.
        /// </param>
        public ViewEngineHelper(IViewEngineCallback callback)
        {
            this._callback = callback;
        }

        /// <summary>
        /// Searches the view locations to find the requested partial view.
        /// </summary>
        /// <param name="controllerContext">
        /// The <see cref="ControllerContext"/> object for the current request.
        /// </param>
        /// <param name="partialViewName">
        /// The name of the partial view to locate.
        /// </param>
        /// <param name="useCache">
        /// True to use the cache to find the view, or false to forcibly search
        /// for the partial view's file.
        /// </param>
        /// <returns>
        /// Returns a <see cref="ViewEngineResult"/> object containing the view
        /// if the view was found, or the list of locations that were searched
        /// if the view was not found.
        /// </returns>
        public ViewEngineResult FindPartialView(
            ControllerContext controllerContext,
            string partialViewName,
            bool useCache)
        {
            if (null == controllerContext)
            {
                throw new ArgumentNullException("controllerContext");
            }

            if (String.IsNullOrEmpty(partialViewName))
            {
                throw new ArgumentException(
                    "Is Null or Empty",
                    "partialViewName");
            }

            var controllerName =
                controllerContext.RouteData.GetRequiredString("controller");
            string[] searchedLocations;
            var path = this.GetPath(
                controllerContext,
                this._callback.PartialViewLocationFormats,
                this._callback.AreaPartialViewLocationFormats,
                partialViewName,
                controllerName,
                "Partial",
                useCache,
                out searchedLocations);
            if (string.IsNullOrEmpty(path))
            {
                return new ViewEngineResult(searchedLocations);
            }

            var partialView = this._callback.CreatePartialView(
                controllerContext,
                path);
            return new ViewEngineResult(partialView, this._callback.ViewEngine);
        }

        /// <summary>
        /// Searches the view locations to find the requested view.
        /// </summary>
        /// <param name="controllerContext">
        /// The <see cref="ControllerContext"/> object for the current request.
        /// </param>
        /// <param name="viewName">
        /// The name of the view.
        /// </param>
        /// <param name="masterName">
        /// The name of the master view.
        /// </param>
        /// <param name="useCache">
        /// If true, use the cache to find the path to the view and master
        /// view.
        /// </param>
        /// <returns>
        /// Returns a <see cref="ViewEngineResult"/> object that contains the
        /// view and master view, or the list of locations that were searched
        /// if the view was not found.
        /// </returns>
        public ViewEngineResult FindView(
            ControllerContext controllerContext,
            string viewName,
            string masterName,
            bool useCache)
        {
            string[] viewSearchedLocations;
            string[] masterSearchedLocations;

            if (null == controllerContext)
            {
                throw new ArgumentNullException("controllerContext");
            }

            if (string.IsNullOrEmpty(viewName))
            {
                throw new ArgumentException(
                    "Is Null or Empty",
                    "viewName");
            }

            var controllerName =
                controllerContext.RouteData.GetRequiredString("controller");
            var viewPath = this.GetPath(
                controllerContext,
                this._callback.ViewLocationFormats,
                this._callback.AreaViewLocationFormats,
                viewName,
                controllerName,
                "View",
                useCache,
                out viewSearchedLocations);
            var masterPath = this.GetPath(
                controllerContext,
                this._callback.MasterLocationFormats,
                this._callback.AreaMasterLocationFormats,
                masterName,
                controllerName,
                "Master",
                useCache,
                out masterSearchedLocations);
            var hasMaster = !string.IsNullOrEmpty(masterPath) ||
                string.IsNullOrEmpty(masterName);
            if (!string.IsNullOrEmpty(viewPath) && hasMaster)
            {
                var view = this._callback.CreateView(
                    controllerContext,
                    viewPath,
                    masterPath);
                return new ViewEngineResult(view, this._callback.ViewEngine);
            }

            var searchedLocations =
                viewSearchedLocations.Union(masterSearchedLocations);
            return new ViewEngineResult(searchedLocations);
        }

        /// <summary>
        /// Extracts the name of the area from the route information.
        /// </summary>
        /// <param name="routeData">
        /// The <see cref="RouteData"/> object for the current request.
        /// </param>
        /// <returns>
        /// Returns the name of the area, or null if the request did not
        /// reference an area.
        /// </returns>
        private static string GetAreaName(RouteData routeData)
        {
            object areaName;
            if (routeData.DataTokens.TryGetValue("area", out areaName))
            {
                return areaName as string;
            }

            var area = routeData.Route as IRouteWithArea;
            if (null != area)
            {
                return area.Area;
            }

            var route = routeData.Route as Route;
            if (null != route && null != route.DataTokens)
            {
                return route.DataTokens["area"] as string;
            }

            return null;
        }

        private string GetTenantKey(RouteData routeData)
        {
            return routeData.GetTenantKey();
        }

      

        /// <summary>
        /// Builds and returns a list of the locations where the view may be
        /// located.
        /// </summary>
        /// <param name="viewLocationFormats">
        /// The list of location formats for views.
        /// </param>
        /// <param name="areaViewLocationFormats">
        /// The list of location formats for area views.
        /// </param>
        /// <returns>
        /// Returns a list of <see cref="ViewLocation"/> objects.
        /// </returns>
        [SuppressMessage(
            "Microsoft.Design",
            "CA1061:DoNotHideBaseClassMethods",
            Justification = "MFC3: I've overridden the implementation, so it's ok.")]
        private static List<ViewLocation> GetViewLocations(
            IEnumerable<string> viewLocationFormats,
            IEnumerable<string> areaViewLocationFormats)
        {
            var list = new List<ViewLocation>();

            if (null != areaViewLocationFormats)
            {
                list.AddRange(areaViewLocationFormats.Select(
                    format => new AreaViewLocation(format)));
            }

            if (null != viewLocationFormats)
            {
                list.AddRange(viewLocationFormats.Select(
                    format => new ViewLocation(format)));
            }

            return list;
        }

        /// <summary>
        /// Determines if the view name is a specific path.
        /// </summary>
        /// <param name="name">
        /// The name of the view.
        /// </param>
        /// <returns>
        /// Returns true if the name is a specific path, or false if the name
        /// is not a specific path.
        /// </returns>
        private static bool IsSpecificPath(string name)
        {
            var ch = name[0];
            if ('~' != ch)
            {
                return '/' == ch;
            }

            return true;
        }

        /// <summary>
        /// Generates the key used to store the location of the view in the
        /// view location cache.
        /// </summary>
        /// <param name="name">
        /// The name of the view.
        /// </param>
        /// <param name="areaName">
        /// The name of the area that the view belongs to.
        /// </param>
        /// <param name="cacheKeyPrefix">
        /// The prefix for the cache key.
        /// </param>
        /// <param name="specificPath">
        /// The specific path for the view.
        /// </param>
        /// <param name="controllerName">
        /// The name of the controller that the view belongs to.
        /// </param>
        /// <param name="tenantKey">
        /// The name of the tenant.
        /// </param>
        private string CreateCacheKey(
            string name,
            string areaName,
            string cacheKeyPrefix,
            bool specificPath,
            string controllerName,
            string tenantKey)
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                ":ViewCacheEntry:{0}:{1}:{2}:{3}:{4}:{5}",
                this.GetType().AssemblyQualifiedName,
                cacheKeyPrefix,
                name,
                specificPath ? String.Empty : controllerName,
                areaName,
                tenantKey);
        }

        /// <summary>
        /// Determines whether the specified path is supported by the view
        /// engine.
        /// </summary>
        /// <param name="virtualPath">
        /// The path of the view to validate.
        /// </param>
        /// <returns>
        /// Returns true if the path is supported, or false if the path is
        /// not supported.
        /// </returns>
        private bool FilePathIsSupported(string virtualPath)
        {
            if (this._callback.FileExtensions == null)
            {
                return true;
            }

            var extension = VirtualPathUtility.GetExtension(virtualPath)
                .TrimStart(new[] { '.' });
            return this._callback.FileExtensions.Contains(
                extension,
                StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Searches the virtual file system of the web application to find the
        /// partial view.
        /// </summary>
        /// <param name="controllerContext">
        /// The <see cref="ControllerContext"/> object for the current request.
        /// </param>
        /// <param name="locations">
        /// An array of strings containing the formats for the paths to search
        /// to find normal non-area views.
        /// </param>
        /// <param name="areaLocations">
        /// An array of strings containing the formats for the paths to search
        /// to find area views.
        /// </param>
        /// <param name="name">
        /// The name of the view or partial view to find.
        /// </param>
        /// <param name="controllerName">
        /// The name of the controller.
        /// </param>
        /// <param name="cacheKeyPrefix">
        /// The prefix to use for keys in the view location cache.
        /// </param>
        /// <param name="useCache">
        /// If true, use the cache to locate the view. If false, search for the
        /// view even if the view exists in the cache.
        /// </param>
        /// <param name="searchedLocations">
        /// On output, if the view was not found, a list of the searched
        /// locations will be stored in this array to be reported in the
        /// error.
        /// </param>
        /// <returns>
        /// Returns the path to the view or partial view if the view is
        /// found.
        /// </returns>
        private string GetPath(
            ControllerContext controllerContext,
            IEnumerable<string> locations,
            IEnumerable<string> areaLocations,
            string name,
            string controllerName,
            string cacheKeyPrefix,
            bool useCache,
            out string[] searchedLocations)
        {
            searchedLocations = EmptyLocations;
            if (string.IsNullOrEmpty(name))
            {
                return String.Empty;
            }

            var areaName = GetAreaName(controllerContext.RouteData);
            var tenantKey = GetTenantKey(controllerContext.RouteData);


            var viewLocations = GetViewLocations(
                locations,
                !string.IsNullOrEmpty(areaName) ? areaLocations : null);
            var specificPath = IsSpecificPath(name);
            string cacheKey = this.CreateCacheKey(
                name,
                areaName,
                cacheKeyPrefix,
                specificPath,
                controllerName,
                tenantKey
                );
            if (useCache)
            {
                return this._callback.ViewLocationCache.GetViewLocation(
                    controllerContext.HttpContext,
                    cacheKey);
            }

            if (!specificPath)
            {
                return this.GetPathFromGeneralName(
                    controllerContext,
                    viewLocations,
                    name,
                    controllerName,
                    areaName,
                    tenantKey,
                    cacheKey,
                    ref searchedLocations);
            }

            return this.GetPathFromSpecificName(
                controllerContext,
                name,
                cacheKey,
                ref searchedLocations);
        }

     

        /// <summary>
        /// Searches for the view using the general name of the view.
        /// </summary>
        /// <param name="controllerContext">
        /// The <see cref="ControllerContext"/> object for the request.
        /// </param>
        /// <param name="viewLocations">
        /// The list of <see cref="ViewLocation"/> objects representing the
        /// locations where the view may be located.
        /// </param>
        /// <param name="name">
        /// The name of the view.
        /// </param>
        /// <param name="controllerName">
        /// The name of the controller.
        /// </param>
        /// <param name="areaName">
        /// The name of the area.
        /// </param>
        /// <param name="tenantKey">
        /// The tenant name.
        /// </param>
        /// <param name="cacheKey">
        /// The key used to store the view's location in the view location
        /// cache.
        /// </param>
        /// <param name="searchedLocations">
        /// On output, an array of the locations that were searched for the
        /// view if the view was not found.
        /// </param>
        /// <returns>
        /// Returns the virtual path for the view, or null if the view was
        /// not found.
        /// </returns>
        private string GetPathFromGeneralName(
            ControllerContext controllerContext,
            IList<ViewLocation> viewLocations,
            string name,
            string controllerName,
            string areaName,
            string tenantKey,
            string cacheKey,
            ref string[] searchedLocations)
        {
            var virtualPath = String.Empty;
            searchedLocations = new string[viewLocations.Count];
            for (var i = 0; i < viewLocations.Count; i++)
            {
                var path = viewLocations[i].Format(
                    name,
                    controllerName,
                    areaName,
                    tenantKey);
                if (this._callback.FileExists(controllerContext, path))
                {
                    searchedLocations = EmptyLocations;
                    virtualPath = path;
                    this._callback.ViewLocationCache.InsertViewLocation(
                        controllerContext.HttpContext,
                        cacheKey,
                        virtualPath);
                    return virtualPath;
                }

                searchedLocations[i] = path;
            }

            return virtualPath;
        }

        /// <summary>
        /// Gets the path for a view from its specific name.
        /// </summary>
        /// <param name="controllerContext">
        /// The <see cref="ControllerContext"/> object for the request.
        /// </param>
        /// <param name="name">
        /// The name of the view.
        /// </param>
        /// <param name="cacheKey">
        /// The cache key to use to store the view's location.
        /// </param>
        /// <param name="searchedLocations">
        /// On output, if the view is not found this array will contain the
        /// list of locations that were searched for the view.
        /// </param>
        /// <returns>
        /// Returns the path of the view if the view was found, or an empty
        /// string if the view was not found.
        /// </returns>
        private string GetPathFromSpecificName(
            ControllerContext controllerContext,
            string name,
            string cacheKey,
            ref string[] searchedLocations)
        {
            var virtualPath = name;
            if (!this.FilePathIsSupported(name) ||
                !this._callback.FileExists(controllerContext, name))
            {
                virtualPath = string.Empty;
                searchedLocations = new[] { name };
            }

            this._callback.ViewLocationCache.InsertViewLocation(
                controllerContext.HttpContext,
                cacheKey,
                virtualPath);
            return virtualPath;
        }

        

        /// <summary>
        /// Represents a virtual location where a view file for an area may
        /// be located.
        /// </summary>
        private class AreaViewLocation : ViewLocation
        {
            /// <summary>
            /// Initializes a new instance of the AreaViewLocation class.
            /// </summary>
            /// <param name="virtualPathFormat">
            /// The format for the view's virtual path.
            /// </param>
            public AreaViewLocation(string virtualPathFormat) :
                base(virtualPathFormat)
            {
            }

            /// <summary>
            /// Formats the view path format and returns the calculated view
            /// path.
            /// </summary>
            /// <param name="viewName">
            /// The name of the view to find.
            /// </param>
            /// <param name="controllerName">
            /// The name of the controller.
            /// </param>
            /// <param name="areaName">
            /// The name of the area.
            /// </param>
            /// <param name="language">
            /// Language code
            /// </param>
            /// <param name="tenantKey">
            /// The name of the tenant
            /// </param>
            /// <returns>
            /// Returns the formatted virtual path of the view.
            /// </returns>
            public override string Format(
                string viewName,
                string controllerName,
                string areaName,
                string tenantKey)
            {
                return String.Format(
                    CultureInfo.InvariantCulture,
                    this.VirtualPathFormat,
                    viewName,
                    controllerName,
                    areaName,
                    tenantKey);
            }
        }

        /// <summary>
        /// Represents a virtual location where a view file may be located.
        /// </summary>
        private class ViewLocation
        {
            /// <summary>
            /// Initializes a new instance of the ViewLocation class.
            /// </summary>
            /// <param name="virtualPathFormat">
            /// The format for the view's virtual path.
            /// </param>
            public ViewLocation(string virtualPathFormat)
            {
                this.VirtualPathFormat = virtualPathFormat;
            }

            /// <summary>
            /// Gets the format for the virtual path of the view.
            /// </summary>
            /// <value>
            /// The value of this property is the format of the virtual path
            /// for the view.
            /// </value>
            protected string VirtualPathFormat { get; private set; }

            /// <summary>
            /// Formats the view path format and returns the calculated view
            /// path.
            /// </summary>
            /// <param name="viewName">
            /// The name of the view to find.
            /// </param>
            /// <param name="controllerName">
            /// The name of the controller.
            /// </param>
            /// <param name="areaName">
            /// The name of the area.
            /// </param>
            /// <param name="language">
            /// The code of the language
            /// </param>
            /// <param name="tenantKey">
            /// The name of the tenant.
            /// </param>
            public virtual string Format(
                string viewName,
                string controllerName,
                string areaName,
                string tenantKey)
            {
                return String.Format(
                    CultureInfo.InvariantCulture,
                    this.VirtualPathFormat,
                    viewName,
                    controllerName,
                    tenantKey);
            }
        }
    }

}
