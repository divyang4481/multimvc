using System.Collections.Generic;
using System.Web.Mvc;

namespace BA.MultiMvc.Framework
{
    /// <summary>
    /// ViewEngine for Razor views.  Support MultiTenancy as it first look for a view into: ~/Extensions/[TenantKey]/Views/[Controller]/[ViewName].cshtml
    /// If it does not find the view in one of the Tenant folder it look in the default MVC location.
    /// </summary>
    public class MultiRazorViewEngine : RazorViewEngine, IViewEngineCallback
    {
        /// <summary>
        /// The <see cref="ViewEngineHelper"/> object that is used to locate
        /// views for the view engine.
        /// </summary>
        private readonly ViewEngineHelper _helper;

        /// <summary>
        /// Initializes a new instance of the WebsiteRazorViewEngine class.
        /// </summary>
        public MultiRazorViewEngine()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the WebsiteRazorViewEngine class.
        /// </summary>
        /// <param name="viewPageActivator">
        /// The <see cref="IViewPageActivator"/> object to use to locate and
        /// create view objects for the view engine.
        /// </param>
        public MultiRazorViewEngine(IViewPageActivator viewPageActivator) :
            base(viewPageActivator)
        {   
            var areaFormats = new[]
            {
                 "~/Extensions/Areas/{3}/{2}/Views/{1}/{0}.cshtml",
                "~/Extensions/Areas/{3}/{2}/Views/Shared/{0}.cshtml",
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml",
                 "~/Extensions/Areas/{3}/{2}/Views/{1}/{0}.vbhtml",
                "~/Extensions/Areas/{3}/{2}/Views/Shared/{0}.vbhtml",
                "~/Areas/{2}/Views/{1}/{0}.vbhtml",
                "~/Areas/{2}/Views/Shared/{0}.vbhtml"
            };
            var viewFormats = new[]
            {
                "~/Extensions/{2}/Views/{1}/{0}.cshtml",
                "~/Extensions/{2}/Views/Shared/{0}.cshtml",
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Extensions/{2}/Views/{1}/{0}.vbhtml",
                "~/Extensions/{2}/Views/Shared/{0}.vbhtml",
                "~/Views/{1}/{0}.vbhtml",
                "~/Views/Shared/{0}.vbhtml"
            };

            this.AreaMasterLocationFormats = areaFormats;
            this.AreaPartialViewLocationFormats = areaFormats;
            this.AreaViewLocationFormats = areaFormats;
            this.MasterLocationFormats = viewFormats;
            this.PartialViewLocationFormats = viewFormats;
            this.ViewLocationFormats = viewFormats;

            this._helper = new ViewEngineHelper(this);
        }


        /// <summary>
        /// Gets the list of location formats for master views belonging to
        /// areas.
        /// </summary>
        /// <value>
        /// The value of this property is an array of strings containing
        /// string formats for the locations where master views can be located.
        /// </value>
        IEnumerable<string> IViewEngineCallback.AreaMasterLocationFormats
        {
            get { return this.AreaMasterLocationFormats; }
        }

        /// <summary>
        /// Gets the list of location formats for partial views belonging to
        /// areas.
        /// </summary>
        /// <value>
        /// The value of this property is an array of strings containing
        /// string formats for the locations where partial views can be
        /// located.
        /// </value>
        IEnumerable<string> IViewEngineCallback.AreaPartialViewLocationFormats
        {
            get { return this.AreaPartialViewLocationFormats; }
        }

        /// <summary>
        /// Gets the list of location formats for area views.
        /// </summary>
        /// <value>
        /// The value of this property is an array of strings containing
        /// string formats for the locations where views can be located.
        /// </value>
        IEnumerable<string> IViewEngineCallback.AreaViewLocationFormats
        {
            get { return this.AreaViewLocationFormats; }
        }

        /// <summary>
        /// Gets the list of supported file extensions for the view engine.
        /// </summary>
        /// <value>
        /// The value of this property is a collection of strings containing
        /// the supported file extensions for the view engine.
        /// </value>
        IEnumerable<string> IViewEngineCallback.FileExtensions
        {
            get { return this.FileExtensions; }
        }

        /// <summary>
        /// Gets the list of location formats for master views.
        /// </summary>
        /// <value>
        /// The value of this property is an array of strings containing
        /// string formats for the locations where master views can be located.
        /// </value>
        IEnumerable<string> IViewEngineCallback.MasterLocationFormats
        {
            get { return this.MasterLocationFormats; }
        }

        /// <summary>
        /// Gets the list of location formats for partial views.
        /// </summary>
        /// <value>
        /// The value of this property is an array of strings containing
        /// string formats for the locations where partial views can be
        /// located.
        /// </value>
        IEnumerable<string> IViewEngineCallback.PartialViewLocationFormats
        {
            get { return this.PartialViewLocationFormats; }
        }

        /// <summary>
        /// Gets the view engine object.
        /// </summary>
        /// <value>
        /// The value of this property is an <see cref="IViewEngine"/> object.
        /// </value>
        IViewEngine IViewEngineCallback.ViewEngine
        {
            get { return this; }
        }

        /// <summary>
        /// Gets the list of location formats for non-area views.
        /// </summary>
        /// <value>
        /// The value of this property is an array of strings containing
        /// string formats for the locations where views can be located.
        /// </value>
        IEnumerable<string> IViewEngineCallback.ViewLocationFormats
        {
            get { return this.ViewLocationFormats; }
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
        public override ViewEngineResult FindPartialView(
            ControllerContext controllerContext,
            string partialViewName,
            bool useCache)
        {
            return this._helper.FindPartialView(
                controllerContext,
                partialViewName,
                useCache);
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
        public override ViewEngineResult FindView(
            ControllerContext controllerContext,
            string viewName,
            string masterName,
            bool useCache)
        {
            return this._helper.FindView(
                controllerContext,
                viewName,
                masterName,
                useCache);
        }

        /// <summary>
        /// Creates a partial view object.
        /// </summary>
        /// <param name="controllerContext">
        /// The <see cref="ControllerContext"/> object for the current request.
        /// </param>
        /// <param name="path">
        /// The path of the selected partial view.
        /// </param>
        /// <returns>
        /// Returns an <see cref="IView"/> object for the partial view.
        /// </returns>
        IView IViewEngineCallback.CreatePartialView(
            ControllerContext controllerContext,
            string path)
        {
            return this.CreatePartialView(controllerContext, path);
        }

        /// <summary>
        /// Creates a view object.
        /// </summary>
        /// <param name="controllerContext">
        /// The <see cref="ControllerContext"/> object for the current request.
        /// </param>
        /// <param name="viewPath">
        /// The path of the view.
        /// </param>
        /// <param name="masterPath">
        /// The path of the master template.
        /// </param>
        /// <returns>
        /// Returns an <see cref="IView"/> object for the view.
        /// </returns>
        IView IViewEngineCallback.CreateView(
            ControllerContext controllerContext,
            string viewPath,
            string masterPath)
        {
            return this.CreateView(controllerContext, viewPath, masterPath);
        }

        /// <summary>
        /// Determines whether the specified file exists.
        /// </summary>
        /// <param name="controllerContext">
        /// The <see cref="ControllerContext"/> object for the current request.
        /// </param>
        /// <param name="path">
        /// The path of the file.
        /// </param>
        /// <returns>
        /// Returns true if the file exists, or false if the file does not
        /// exist.
        /// </returns>
        bool IViewEngineCallback.FileExists(
            ControllerContext controllerContext,
            string path)
        {
            return this.FileExists(controllerContext, path);
        }
    }

}
