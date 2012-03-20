using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using BA.MultiMvc.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using StructureMap;

namespace BackToOwner.Golf.Web.Test
{
    [TestClass]
    public class Specification
    {
        protected ActionResult _result;

        [TestInitialize]
        public void Init()
        {
            Given();
            When();
        }

        public virtual void Given()
        {}

        public virtual void When()
        {}

        protected static class StructureMapMockRepository
        {
            public static T RegisterMock<T>() where T : class 
            {
                T mock = MockRepository.GenerateMock<T>();
                ObjectFactory.Inject(mock);
                return mock;
            }
        }


    }
}
