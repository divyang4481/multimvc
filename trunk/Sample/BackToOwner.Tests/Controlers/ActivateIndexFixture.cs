using System.Collections.Generic;
using System.Web.Mvc;
using BackToOwner.Golf.Web.Models;
using BackToOwner.Golf.Web.ViewModels;
using BackToOwner.Golf.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace BackToOwner.Golf.Web.Test.UnitTests
{
    public class GivenActivateController : GivenTenantContextAndServiceConfigured
    {
        protected ActionResult Result;
        protected ActivateController Subject;
        protected Owner Owner;
        protected Badge BadgeToBeActivated;

        public override void Given()
        {
            
            base.Given();
            this.BadgeToBeActivated = new Badge {Nbr = "333333333"};
            Owner = DomainStubFactory.CreateOwner();
            Subject = new ActivateController(this.ApplicationFacade);
            MockedSessionService.Stub(x => x["badgeNbr"]).Return(new List<Badge>(Owner.Badges)[0].Nbr);
            MockedSessionService.Stub(x => x["owner"]).Return(Owner);
            MockedBadgeRepository.Stub(x => x.GetBy(n=>n.Nbr == new List<Badge>(Owner.Badges)[0].Nbr)).IgnoreArguments().Return(this.BadgeToBeActivated);
            MockedMapperService.Stub(x => x.MapToOwner(Owner, new ActivateMobileRequest())).IgnoreArguments().Return(Owner);
            MockedDistributorService.Stub(x => x.SendActivationConfirmation(this.BadgeToBeActivated));
        }
    }


    /// <summary>
    /// Summary description for ActivateContactFixture
    /// </summary>
    [TestClass]
    public class GivenActivateContact : GivenActivateController
    {

        public override void When()
        {
            _result = Subject.Index();
        }

        [TestMethod]
        public void CheckThatOwnerIsInSession()
        {
            MockedSessionService.AssertWasCalled(x=>x["badgeNbr"]);
        }

        [TestMethod]
        public void WhenGetResultModelGenderListContains2Elemenrt()
        {
            Assert.AreEqual(3, ((ActivateIndexRequest)((ViewResult)_result).Model).GenderList.Count);
        }
    }

    
    public class GivenActivateContactRequest: GivenActivateController
    {
        protected ActivateIndexRequest _request;
        protected Owner _owner;

        public override void Given()
        {
            base.Given();
            Subject = new ActivateController(this.ApplicationFacade);
            _request = new ActivateIndexRequest
            {
                Gender = Gender.Male,
                Email = "test@hotmail.com",
                Email2 = "geoffrey@belgianganecies.com",
                //todo:remove magic const
                ConfirmEmail = "test@hotmail.com",
                Password = "belgacom",
                ConfirmPassword = "belgacom",
            };
            _owner = DomainStubFactory.CreateOwner();
            MockedMapperService.Stub(n => n.MapToOwner(_owner, _request)).Return(_owner).IgnoreArguments();
            MockedSessionService.Stub(n => n["badgeNbr"]).Return(new List<Badge>(DomainStubFactory.CreateOwner().Badges)[0].Nbr);
            string salt;
            MockedSecurityService.Stub(n => n.Hash(_request.Password, out salt)).Return("hasedPassword").OutRef("theSalt");


        }

        public override void When()
        {
            Result = Subject.Index(_request);
        }
    }

    [TestClass]
    public class WhenPostValidContactRequest : GivenActivateContactRequest
    {
        

        [TestMethod]
        public void BadgeStoredInSession()
        {
            MockedSessionService.AssertWasCalled(n => n["badgeNbr"] = "", x => x.IgnoreArguments());
        }

        [TestMethod]
        public void RedirectToMobileAction()
        {
            Assert.AreEqual("mobile", (((RedirectToRouteResult)Result).RouteValues["action"].ToString().ToLower()));
        }

        [TestMethod]
        public void MapperMapWasCalled()
        {
            MockedMapperService.AssertWasCalled(n => n.MapToOwner(_owner, _request), x => x.IgnoreArguments());
        }

        [TestMethod]
        public void SecurityServiceWasCalled()
        {
            string salt;
            MockedSecurityService.AssertWasCalled(n => n.Hash(_request.Password, out salt));
        }
    }

    [TestClass]
    public class GivenModelErrorOnActivateIndex : GivenActivateContactRequest
    {
        public override void Given()
        {
            base.Given();
            Subject.ViewData.ModelState.AddModelError("Password", @"Password is invalid");

        }

        public override void When()
        {
            Result = Subject.Index(_request);
        }

        [TestMethod]
        public void ResultShouldBeViewResult()
        {
            
            Assert.IsInstanceOfType(Result, typeof(ViewResult));
        }
    }


}
