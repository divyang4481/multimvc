using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BA.MultiMvc.Test
{
    [TestClass]
    public class GivenWhenThen
    {
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
    }
}
