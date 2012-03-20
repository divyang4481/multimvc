using System.Collections.Generic;
using System.Net.Mail;
using BackToOwner.Golf.Web.Infrastructure;
using BackToOwner.Golf.Web.Models;
using BackToOwner.Golf.Web.Test;
using BackToOwner.Golf.Web.Test.UnitTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace BackToOwner.Golf.Tests.Infrastructure
{
    [TestClass]
    public class GivenDistributorService : GivenTenantContextAndServiceConfigured
    {
        protected DistributorService Subject;
        protected Badge Badge;
        protected Declaration Declaration;


        public override void Given()
        {
            base.Given(); 
            this.Subject = new DistributorService(this.MockedSmsService, this.MockedMailService,this.MockedMailFactory);
            this.Badge = new List<Badge>(DomainStubFactory.CreateOwner().Badges)[0];
            this.Declaration = DomainStubFactory.CreateDeclaration(Badge);
        }
    }

    [TestClass]
    public class WhenSendActivationConfirmation:GivenDistributorService
    {
        public override void When()
        {
            Subject.SendActivationConfirmation(Badge);
        }

        [TestMethod]
        public void MailServiceWasCalled()
        {
            MockedMailService.AssertWasCalled(n => n.SendMail(
                Arg.Is(Badge.Owner.EmailAddresses[0]),
                Arg<string>.Is.Anything,
                Arg<string>.Matches(x=>x.Contains(Badge.Owner.FirstName)), // + " " + Badge.Owner.LastName + " your badge number:" + Badge.Nbr + " " + Badge.Owner.RegistrationDate.ToString("dd/MM/yyyy"),
                Arg<string>.Is.Anything));
        }

        [TestMethod]
        public void SmsServiceWasCalled()
        {
            MockedSmsService.AssertWasCalled(n => n.Send(
                Arg.Is(Badge.Owner.Mobiles[0]),
                Arg<string>.Matches(x => x.Contains(Badge.Owner.FirstName))
                ));
        }
    }


    [TestClass]
    public class WhenSendDeclaration:GivenDistributorService
    {
        public override void When()
        {
            base.When();
            this.Subject.Send(this.Declaration);
        }

        [TestMethod]
        public void ShouldSendMailToAdmin()
        {
            MockedMailService.AssertWasCalled(n=>n.SendMail(
                Arg.Is(this.Resources["admin_mail_to"]),
                Arg.Is(this.Resources["admin_mail_from"]), 
                Arg<string>.Matches(
                    x=>x.Contains(this.Badge.Owner.LastName)        && 
                       x.Contains(this.Badge.Owner.FirstName)       && 
                       x.Contains(this.Badge.Owner.Mobiles[0])      &&
                       x.Contains(this.Badge.Owner.EmailAddresses[0])   &&
                       x.Contains(this.Declaration.RetrivedBadge.Nbr)    &&
                       x.Contains(this.Declaration.Id.ToString())   &&
                       x.Contains(this.Declaration.LastName)        &&
                       x.Contains(this.Declaration.Message)         &&
                       x.Contains(this.Declaration.PhoneNumber)
                       ),
                Arg<string>.Is.Anything));
        }

        [TestMethod]
        public void ShouldSendMailToOwner()
        {
            foreach (var email in this.Declaration.RetrivedBadge.Owner.EmailAddresses)
            {
                MockedMailService.AssertWasCalled(n => n.SendMail(
                Arg.Is(email.Value),
                Arg.Is(this.Resources["owner_mail_from"]),
                Arg<string>.Matches(x=>x.Contains(this.Declaration.Message)),
                Arg<string>.Is.Anything
                ));
            }
        }

        [TestMethod]
        public void ShouldSendSmsToOwner()
        {
            foreach (var mobileNbr in this.Declaration.RetrivedBadge.Owner.Mobiles.Values)
            {
                MockedSmsService.AssertWasCalled(n => n.Send(
                    Arg.Is(mobileNbr),
                    Arg<string>.Matches(x=>x.Contains(this.Declaration.PhoneNumber)))
                    );
            }
        }
    }

    [TestClass]
    public class WhenSendPassword:GivenDistributorService
    {
        protected string NewPassword = "newpassword";
        protected MailMessage[] SendPaswordMails;

        public override void Given()
        {
            base.Given();
            this.SendPaswordMails = new[]{new MailMessage
                                                {
                                                    From = new MailAddress("golflabel@golflabel.net"),
                                                    Body = "<p>some text</p><p>and your password is: newPassword</p>",
                                                    Subject = "This is the subject!"
                                                }};
            this.MockedMailFactory.Stub(n => n.CreateSendPasswordMails(this.Badge.Owner, this.NewPassword)).Return(this.SendPaswordMails);
        }


        public override void When()
        {
            base.When();
            this.Subject.SendPassword(this.Badge.Owner, this.NewPassword);
            
        }

        [TestMethod]
        public void ShouldSendMailToOwner()
        {
            foreach (var mailMessage in this.SendPaswordMails)
            {
                this.MockedMailService.AssertWasCalled(n => n.SendMail(mailMessage)); 
            }
        }
    }

}
