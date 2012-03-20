using System;
using BackToOwner.Golf.Web.Infrastructure;
using BackToOwner.Golf.Web.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BackToOwner.Golf.Tests.Infrastructure
{
    [TestClass]
    public class GivenANewSecurityService:Specification
    {
        protected SecurityService Subject;
        protected string Result;

        public override void Given()
        {
            Subject = new SecurityService();
        }
    }

    [TestClass]
    public class WhenHashAPassword : GivenANewSecurityService
    {
        protected string Password;
        protected string Salt;


        public override void When()
        {
            Result = Subject.Hash(Password, out Salt);
        }

        [TestMethod]
        public void ThenHashPasswordHasHasBeenGenerated()
        {
            Assert.IsFalse(String.IsNullOrEmpty(Result));
        }

        [TestMethod]
        public void ThenSaltHasBeenGenerated()
        {
            Assert.IsFalse(String.IsNullOrEmpty(Salt));
        }
    }

    [TestClass]
    public class WhenGenerateRandomPassword : GivenANewSecurityService
    {
        public override void When()
        {
            this.Result = this.Subject.GenerateRandomPaswword();
        }

        [TestMethod]
        public void ThenPasswordShouldNotBeNullOrEmpty()
        {
            Assert.IsFalse(String.IsNullOrEmpty(this.Result));
        }

        [TestMethod]
        public void ThenPasswordShouldBeDifferentEachTime()
        {
            for (int i = 0; i < 100; i++)
            {
                Assert.AreNotEqual(this.Result, this.Subject.GenerateRandomPaswword());
            }
        }
    }

    [TestClass]
    public class Given10AuditFailures:GivenANewSecurityService
    {
        private bool result;
        public override void Given()
        {
            base.Given();
            for (int i = 0; i < 11; i++)
            {
                this.Subject.AuditFailure("127.0.0.1");
            }
        }

        public override void When()
        {
            result = this.Subject.IsRequestorBlackListed("127.0.0.1");
        }

        [TestMethod]
        public void RequestorShouldBeBlackListed()
        {
            Assert.IsTrue(result);
        }
        
    }

    [TestClass]
    public class GivenStringGenerator:Specification
    {
        List<string> ResultList;

        public override void Given()
        {
            this.ResultList = new List<string>();
        }

        public override void When()
        {
            for (int i = 0; i < 100; i++)
            {
                string generatedString = SecurityService.Generator.RandomString(5);
                this.ResultList.Add(generatedString);
                Console.WriteLine(generatedString);
            }
        }

        [TestMethod]
        public void GeneratedValuesShouldBeDifferent()
        {
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (i!=j) Assert.AreNotEqual(this.ResultList[i], this.ResultList[j],"i="+i);
                }
            }
        }
    }
}
