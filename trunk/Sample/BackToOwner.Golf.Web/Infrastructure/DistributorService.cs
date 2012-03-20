using System;
using System.Net.Mail;
using BackToOwner.Golf.Web.Models;

namespace BackToOwner.Golf.Web.Infrastructure
{
    public class DistributorService : IDistributorService
    {
        private readonly ISmsService smsService;
        private readonly IMailService mailService;
        private readonly IMailFactory mailFactory;

        public DistributorService(ISmsService smsService, IMailService mailService, IMailFactory mailFactory)
        {
            this.smsService = smsService;
            this.mailService = mailService;
            this.mailFactory = mailFactory;
        }

        public void SendActivationConfirmation(Badge badge)
        {
            this.mailService.SendMail(badge.Owner.EmailAddresses[0], badge.ActivationMailConfirmationFrom, badge.ActivationMailConfirmationBody, badge.ActivationMailConfirmationSubject);
            this.smsService.Send(badge.Owner.Mobiles[0], badge.ActivationSmsConfirmation);
        }

        public void Send(Declaration declaration)
        {
            sendDeclarationAdminEmail(declaration);
            sendDeclarationEmailToOwner(declaration);
            sendDeclarationSmsToOwner(declaration);
        }

        private void sendDeclarationSmsToOwner(Declaration declaration)
        {
            foreach (var mobileNbr in declaration.RetrivedBadge.Owner.Mobiles.Values)
            {
                this.smsService.Send(mobileNbr, declaration.SmsToOwner);
            }

        }

        private void sendDeclarationEmailToOwner(Declaration declaration)
        {
            foreach (var emailAddress in declaration.RetrivedBadge.Owner.EmailAddresses.Values)
            {
                this.mailService.SendMail(emailAddress, declaration.MailToOwnerFrom, declaration.MailToOwnerBody, declaration.MailToOwnerSubject);
            }
        }

        private void sendDeclarationAdminEmail(Declaration declaration)
        {
            this.mailService.SendMail(declaration.MailToAdminTo, declaration.MailToAdminFrom, declaration.MailToAdminBody, declaration.MailToAdminSubject);
        }

        public void SendPassword(Owner owner, string newPassword)
        {
            MailMessage[] mailMessages = mailFactory.CreateSendPasswordMails(owner, newPassword);

            foreach (var mailMessage in mailMessages)
            {
                this.mailService.SendMail(mailMessage);
            }
        }

    }
}