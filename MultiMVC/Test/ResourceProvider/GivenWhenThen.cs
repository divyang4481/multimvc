using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BA.MultiMvc.Test
{
    [TestFixture]
    public class GivenWhenThen
    {
        [SetUp]
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
