using System;
using BA.MultiMvc.Framework;
using BA.MultiMvc.Framework.NHibernate;

namespace BackToOwner.Golf.Web.Models
{
    public class Declaration : Entity
    {
        
        public Declaration()
        {
            this._registrationDate = DateTime.Now;
        }

        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual Badge RetrivedBadge { get; set; }
        public virtual string Message { get; set; }
        public virtual Language Language { get; set; }

        private DateTime _registrationDate;
        public virtual DateTime RegistrationDate
        {
            get { return _registrationDate; }
            set { _registrationDate = value; }
        }

        public virtual string MailToOwnerBody
        {
            get { return personalize(TenantResources.Values["owner_mail_text"]); }

        }

        public virtual string SmsToOwner
        {
            get { return this.personalize(TenantResources.Values["owner_sms_text"]).Replace("<br/>", Environment.NewLine); }
        }

        public virtual string MailToOwnerSubject
        {
            get { return this.personalize(TenantResources.Values["owner_mail_subject"]); }
        }

        public virtual string MailToOwnerFrom
        {
            get { return TenantResources.Values["owner_mail_from"]; }
        }

        public virtual string MailToAdminSubject
        {
            get { return this.personalize(TenantResources.Values["admin_mail_subject"]); }
        }

        public virtual string MailToAdminTo
        {
            get { return TenantResources.Values["admin_mail_to"]; }
        }

        public virtual string MailToAdminFrom
        {
            get { return TenantResources.Values["admin_mail_from"]; }
        }

        public virtual string MailToAdminBody
        {
            get { return this.personalize(TenantResources.Values["admin_mail_text"]); }
        }

        private string personalize(string text)
        {
            return text.Replace("[declarationfirstname]", this.FirstName)
                .Replace("[declarationlastname]", this.LastName)
                .Replace("[id]", this.Id.ToString())
                .Replace("[nbr]", this.RetrivedBadge.Nbr)
                .Replace("[message]", this.Message)
                .Replace("[declarationphonenumber]", this.PhoneNumber)
                .Replace("[mobile]", this.RetrivedBadge.Owner.Mobiles[0])
                .Replace("[emailaddress]", this.RetrivedBadge.Owner.EmailAddresses[0])
                .Replace("[firstname]", this.RetrivedBadge.Owner.FirstName)
                .Replace("[lastname]", this.RetrivedBadge.Owner.LastName)
                .Replace("[declarationemailaddress]", this.EmailAddress);

        }
    }
}