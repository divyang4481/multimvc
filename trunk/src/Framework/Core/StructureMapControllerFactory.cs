using System;
using System.Web.Mvc;
using StructureMap;

namespace BA.MultiMvc.Framework.Core
{
    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        #region Methods

        protected override IController GetControllerInstance(Type controllerType)
        {
            if (controllerType == null)
                return null;

            IController result;
            try
            {
                result = ObjectFactory.GetInstance(controllerType) as Controller;
            }
            catch (StructureMapException ex)
            {
                //TODO: use logging framework
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                throw;
            }

            return result;
        }

        #endregion Methods
    }
}