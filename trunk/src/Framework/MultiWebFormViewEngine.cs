using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BA.MultiMvc.Framework
{
    public class MultiWebFormViewEngine : MultiVirtualPathProviderViewEngine
    {
        private IBuildManager _buildManager;

        public MultiWebFormViewEngine()
        {
            MasterLocationFormats = new[] {
                                              "~/Extensions/{2}/Views/{1}/{0}.master",
                                              "~/Extensions/{2}/Views/Shared/{0}.master",
                                              "~/Views/{1}/{0}.master",
                                              "~/Views/Shared/{0}.master"
                                          };

            ViewLocationFormats = new[] {
                                            "~/Extensions/{2}/Views/{1}/{0}.aspx",
                                            "~/Extensions/{2}/Views/{1}/{0}.ascx",
                                            "~/Extensions/{2}/Views/Shared/{0}.aspx",
                                            "~/Extensions/{2}/Views/Shared/{0}.ascx",
                                            "~/Views/{1}/{0}.aspx",
                                            "~/Views/{1}/{0}.ascx",
                                            "~/Views/Shared/{0}.aspx",
                                            "~/Views/Shared/{0}.ascx"
                                        };

            PartialViewLocationFormats = ViewLocationFormats;
        }

        internal IBuildManager BuildManager
        {
            get
            {
                if (_buildManager == null)
                {
                    _buildManager = new BuildManagerWrapper();
                }
                return _buildManager;
            }
            set
            {
                _buildManager = value;
            }
        }
       

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            return new WebFormView(partialPath, null);
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            return new WebFormView(viewPath, masterPath);
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes",
            Justification = "Exceptions are interpreted as indicating that the file does not exist.")]
        protected override bool FileExists(ControllerContext controllerContext, string virtualPath)
        {
            try
            {
                object viewInstance = BuildManager.CreateInstanceFromVirtualPath(virtualPath, typeof(object));

                return viewInstance != null;
            }
            catch (HttpException he)
            {
                if (he.GetHttpCode() == (int)HttpStatusCode.NotFound)
                {
                    // If BuildManager returns a 404 (Not Found) that means the file did not exist
                    return false;
                }
                // All other error codes imply other errors such as compilation or parsing errors
                throw;
            }
            catch
            {
                return false;
            }
        }
    }
}