using System.Collections.Generic;
using System.Web.Mvc;

namespace BA.MultiMvc.Framework
{
    /// <summary>
    /// Callback interface that defines properties and operations used by the
    /// <see cref="ViewEngineHelper"/> class to do work for a view engine.
    /// </summary>
    internal interface IViewEngineCallback
    {
        /// <summary>
        /// Gets the list of location formats for master views belonging to
        /// areas.
        /// </summary>
        /// <value>
        /// The value of this property is an array of strings containing
        /// string formats for the locations where master views can be located.
        /// </value>
        IEnumerable<string> AreaMasterLocationFormats { get; }

        /// <summary>
        /// Gets the list of location formats for partial views belonging to
        /// areas.
        /// </summary>
        /// <value>
        /// The value of this property is an array of strings containing
        /// string formats for the locations where partial views can be
        /// located.
        /// </value>
        IEnumerable<string> AreaPartialViewLocationFormats { get; }

        /// <summary>
        /// Gets the list of location formats for area views.
        /// </summary>
        /// <value>
        /// The value of this property is an array of strings containing
        /// string formats for the locations where views can be located.
        /// </value>
        IEnumerable<string> AreaViewLocationFormats { get; }

        /// <summary>
        /// Gets the list of supported file extensions for the view engine.
        /// </summary>
        /// <value>
        /// The value of this property is a collection of strings containing
        /// the supported file extensions for the view engine.
        /// </value>
        IEnumerable<string> FileExtensions { get; }

        /// <summary>
        /// Gets the list of location formats for master views.
        /// </summary>
        /// <value>
        /// The value of this property is an array of strings containing
        /// string formats for the locations where master views can be located.
        /// </value>
        IEnumerable<string> MasterLocationFormats { get; }

        /// <summary>
        /// Gets the list of location formats for partial views.
        /// </summary>
        /// <value>
        /// The value of this property is an array of strings containing
        /// string formats for the locations where partial views can be
        /// located.
        /// </value>
        IEnumerable<string> PartialViewLocationFormats { get; }

        /// <summary>
        /// Gets the view engine object.
        /// </summary>
        /// <value>
        /// The value of this property is an <see cref="IViewEngine"/> object.
        /// </value>
        IViewEngine ViewEngine { get; }

        /// <summary>
        /// Gets the view location cache object for the view engine.
        /// </summary>
        /// <value>
        /// The value of this property is an <see cref="IViewLocationCache"/>
        /// object.
        /// </value>
        IViewLocationCache ViewLocationCache { get; }

        /// <summary>
        /// Gets the list of location formats for non-area views.
        /// </summary>
        /// <value>
        /// The value of this property is an array of strings containing
        /// string formats for the locations where views can be located.
        /// </value>
        IEnumerable<string> ViewLocationFormats { get; }

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
        IView CreatePartialView(
            ControllerContext controllerContext,
            string path);

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
        IView CreateView(
            ControllerContext controllerContext,
            string viewPath,
            string masterPath);

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
        bool FileExists(ControllerContext controllerContext, string path);
    }

}
