using System.Web.Mvc;
using BA.MultiMvc.Framework;
using BackToOwner.Golf.Web.Application;
using BackToOwner.Golf.Web.Infrastructure;
using BackToOwner.Golf.Web.Models;
using BackToOwner.Golf.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace BackToOwner.Golf.Web.Test.UnitTests
{
    [TestClass]
    public class GivenGetIndexActionOnHomeController : GivenTenantContextAndServiceConfigured
    {
        public override void Given()
        {
            base.Given();
            var controller = new HomeController(this.ApplicationFacade,this.MockedMapperService);
            _result = controller.Index();
        }

        [TestMethod]
        public void ResultShouldBeViewResult()
        {
            Assert.IsInstanceOfType(_result, typeof(ViewResult));
        }

        [TestMethod]
        public void ResultShouldHaveAModel()
        {
            Assert.IsNotNull(((ViewResult)_result).Model);
        }

        [TestMethod]
        public void ResultModelShouldBeHomeIndexRequest()
        {
            Assert.IsInstanceOfType(((ViewResult)_result).Model, typeof(HomeIndexRequest));
        }
    }

    [TestClass]
    public class GivenHomeController : GivenTenantContextAndServiceConfigured
    {
        protected HomeIndexRequest Request;
        protected ActionResult Result;
        protected HomeController Subject;
        protected string RequestIp;

        public override void Given()
        {
            base.Given();
            Subject = new HomeController(this.ApplicationFacade,this.MockedMapperService);
            this.MockedSessionService.Expect(n => n.Ip).Return(this.RequestIp);
            this.MockedSecurityService.Expect(n => n.IsRequestorBlackListed(this.RequestIp)).Return(false);
        }
    }

    [TestClass]
    public class WhenGetIndex : GivenHomeController
    {
        public override void When()
        {
            Result = Subject.Index();
        }

        [TestMethod]
        public void ResultShouldNotBeNull()
        {
            Assert.IsNotNull(Result);
        }
    }

    [TestClass]
    public class WhenPostHomeIndexRequest : GivenHomeController
    {
        public override void When()
        {
           Result = Subject.Index(Request);
        }
    }

    [TestClass]
    public class GivenModelError : WhenPostHomeIndexRequest
    {
        public override void Given()
        {
            base.Given();
            Subject.ViewData.ModelState.AddModelError("BadgeEmpty", @"Badge is empty");
            Request = new HomeIndexRequest { BadgeNbr = null };
        }

        [TestMethod]
        public void ResultShouldBeViewResult()
        {
            //Assert 
            Assert.IsInstanceOfType(Result, typeof(ViewResult));
        }
    }

    [TestClass]
    public class GivenNotActivatedBadge : WhenPostHomeIndexRequest
    {

        protected string NormalizedBadgeNumber;

        public override void Given()
        {
            base.Given();
            this.Subject = new HomeController(this.ApplicationFacade,this.MockedMapperService);
            //  Arange
            const string nbr = "abc-123-Ghj";
            this.NormalizedBadgeNumber =  "ABC123GHJ";
            var nonActivatedBadge = new Badge { Nbr = nbr };
            this.MockedBadgeRepository.Expect(n => n.GetBy(x=>x.Nbr == this.NormalizedBadgeNumber)).IgnoreArguments().Return(nonActivatedBadge);
            Request = new HomeIndexRequest { BadgeNbr = nbr };
            this.MockedSessionService.Stub(x => x["badgeNbr"]).Return(this.NormalizedBadgeNumber);
            
        }


        [TestMethod]
        public void NormalizedBadgeNbrSavedInSession()
        {
            this.MockedSessionService.AssertWasCalled(x => x["badgeNbr"] = this.NormalizedBadgeNumber);
        }

        [TestMethod]
        public void CanNavigateToContactWhenEnterNotActivedBadgeNumber()
        {
            Assert.IsInstanceOfType(Result, typeof(RedirectToRouteResult));
            Assert.AreEqual("activate", ((RedirectToRouteResult)Result).RouteValues["Controller"].ToString().ToLower());
        }
    }

    [TestClass]
    public class GivenNotExistingBadge : WhenPostHomeIndexRequest
    {
        public override void Given()
        {
            base.Given();
            var nbr = "39393";
            MockedBadgeRepository.Expect(n => n.GetBy(x=>x.Nbr == nbr)).Return(null);
            Request = new HomeIndexRequest { BadgeNbr = nbr };
        }


        [TestMethod]
        public void ModelStateInvalidBadgeIsNotNull()
        {
            // Assert
            Assert.IsInstanceOfType(Result, typeof(ActionResult));
            Assert.IsNotNull(Subject.ModelState["BadgeNbr"]);
        }
    }

    [TestClass]
    public class WhenPost10timesNotExistingBadge : GivenTenantContextAndServiceConfigured
    {
        protected HomeIndexRequest Request;
        protected HomeController Subject;
        protected ActionResult Result;

        public override void Given()
        {
            base.Given();
            var nbr = "39393";
            this.MockedBadgeRepository.Expect(n => n.GetBy(x => x.Nbr == nbr)).IgnoreArguments().Return(null);
            this.MockedSecurityService.Expect(n => n.IsRequestorBlackListed(null)).IgnoreArguments().Return(true);
            this.ApplicationFacade = new ApplicationFacade(this.MockedSessionService, this.MockedDistributorService, this.MockedBadgeRepository, this.MockedDeclarationRepository, this.MockedSecurityService, this.MockedAutheticationService, this.MockedOwnerRepository, this.MockedMapperService);
            this.Request = new HomeIndexRequest { BadgeNbr = nbr };
            this.Subject = new HomeController(this.ApplicationFacade,this.MockedMapperService);
        }

        public override void When()
        {
            this.Result = this.Subject.Index(Request);
        }

        [TestMethod]
        public void ModelStateInvalidBadgeIsNotNull()
        {
            // Assert
            Assert.IsInstanceOfType(Result, typeof(ActionResult));
            Assert.IsNotNull(this.Subject.ModelState["BadgeNbr"]);
            Assert.AreEqual(TenantResources.Values["locked_ip"],
               this.Subject.ModelState["BadgeNbr"].Errors[0].ErrorMessage);
        }
    }
   
}