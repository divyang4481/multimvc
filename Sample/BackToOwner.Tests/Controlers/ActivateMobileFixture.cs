using System.Collections.Generic;
using System.Web.Mvc;
using BackToOwner.Golf.Web.Models;
using BackToOwner.Golf.Web.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace BackToOwner.Golf.Web.Test.UnitTests
{
    [TestClass]
    public class WhenSubmitValidMobileNumbers:GivenActivateController
    {
        protected ActivateMobileRequest Request;
        
        public override void Given()
        {
            base.Given();
            Request = new ActivateMobileRequest()
                          {
                              AcceptTerms = true,
                              CountryCode = "+32",
                              PhoneNumber = "495204340"
                          };

        }

        public override void When()
        {
            Result = Subject.Mobile(Request);
        }

        [TestMethod]
        public void ShouldRedirectToConfirm()
        {
            Assert.IsInstanceOfType(Result,typeof(RedirectToRouteResult));
        }

        [TestMethod]
        public void ShouldStoreOwner()
        {
            MockedBadgeRepository.AssertWasCalled(n => n.Save(Owner), x => x.IgnoreArguments());
        }

        [TestMethod]
        public void ShouldMapRequestToOwner()
        {
            MockedMapperService.AssertWasCalled(n=>n.MapToOwner(Owner,Request),x=>x.IgnoreArguments());
        }

        [TestMethod]
        public void ShouldSendConfirmation()
        {
            MockedDistributorService.AssertWasCalled(n => n.SendActivationConfirmation(BadgeToBeActivated));
        }
    }

   
}
