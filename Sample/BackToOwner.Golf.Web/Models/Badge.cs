using BA.MultiMvc.Framework;
using BA.MultiMvc.Framework.NHibernate;

namespace BackToOwner.Golf.Web.Models
{
    public class Badge:Entity<string>
    {
        private string nbr;
        public virtual string Nbr
        {
            get { return nbr; }
            set { 
                nbr = value;
                nbr = Badge.NormailzeLabelCode(nbr);
            }
        }

        public virtual string PretyNbr
        {
            get { return Badge.DenormalizeLabelCode(this.nbr); }
        }

        public static string DenormalizeLabelCode(string nbr)
        {
            if (nbr.Length > 8)
            {
                string first = nbr.Substring(0, 3);
                string second = nbr.Substring(3, 3);
                string third = nbr.Substring(6, 3);

                return first + "-" + second + "-" + third;
            }

            return nbr;
        }

        public virtual Owner Owner { get; set; }

        public virtual Lot Lot { get; set; }

        public virtual void SetOwner(Owner newOwner)
        {
            var prevOwner = this.Owner;
            if (newOwner == this.Owner)
                return;

            this.Owner = newOwner;

            if (prevOwner !=null)
                prevOwner.RemoveBadge(this);
            if(newOwner !=null)
                newOwner.Badges.Add(this);
        }

        public virtual bool IsActive { get { return this.Owner != null; }}

        public virtual string ActivationMailConfirmationBody
        {
            get { return this.personalize(TenantResources.Values["confirmation_mail_text"]); }
        }

        public virtual string ActivationSmsConfirmation
        {
            get { return this.personalize(TenantResources.Values["confirmation_sms_text"]); }
        }

        public virtual string ActivationMailConfirmationSubject
        {
            get { return this.personalize(TenantResources.Values["confirmation_mail_subject"]); }
        }

        public virtual string ActivationMailConfirmationFrom
        {
            get { return this.personalize(TenantResources.Values["confirmation_mail_from"]); }
        }

        //Badge:[badge], RegistrationDate:[registrationdate], EndValidity:[endvalidity],
        private string personalize(string text)
        {
            return text.Replace("[firstname]", this.Owner.FirstName)
                .Replace("[lastname]", this.Owner.LastName)
                .Replace("[badge]", this.Nbr)
                .Replace("[emailaddress]", this.Owner.EmailAddresses[0])
                .Replace("[mobile]",this.Owner.Mobiles[0])
                .Replace("[registrationdate]", this.Owner.RegistrationDate.ToString("dd/MM/yyyy"))
                .Replace("[endvalidity]", this.Owner.RegistrationDate.AddYears(3).ToString("dd/MM/yyyy"));
        }

        public static string NormailzeLabelCode(string inputLabelCode)
        {
            return inputLabelCode.Replace("-", "").ToUpperInvariant();
        }

        public override bool Equals(object obj)
        {
            var that = obj as Badge;
            if (that == null)
                return false;

            return that.Nbr == this.Nbr;

        }

        public override int GetHashCode()
        {
            return this.Nbr.GetHashCode();
        }
    }
}