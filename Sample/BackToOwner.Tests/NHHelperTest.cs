using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BA.MultiMvc.Framework;

namespace BackToOwner.Golf.Web.Test
{
    [TestClass]
    public class NHHelperTest
    {
        [TestMethod]
        public void CanStringToCamelCase()
        {
            Assert.AreEqual(0, String.Compare("someString".ToCamelCase(), "Somestring", false));
        }
    }
}
