using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using BA.MultiMvc.Framework;
using BackToOwner.Golf.Web.Models;

namespace BackToOwner.Golf.Web.Infrastructure
{
    public interface IMailFactory{

        MailMessage[] CreateSendPasswordMails(Owner owner, string newPassword);
    }

    public class MailFactory:IMailFactory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public MailMessage[] CreateSendPasswordMails(Owner owner, string newPassword)
        {
            List<MailMessage> messages = new List<MailMessage>();
            foreach (var emailAddress in owner.EmailAddresses.Values)
            {
                MailMessage message = new MailMessage(TenantResources.Values["owner_mail_from"], emailAddress);
                message.Body = TenantResources.Values["send_password_mail_body"].Replace("[password]",newPassword);
                message.Subject = TenantResources.Values["send_password_mail_subject"];
                message.IsBodyHtml = true;

                messages.Add(message);
            }

            return messages.ToArray();
        }
    }
}