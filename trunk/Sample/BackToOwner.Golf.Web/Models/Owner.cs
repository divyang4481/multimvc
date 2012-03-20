using System;
using System.Collections.Generic;
using BA.MultiMvc.Framework.NHibernate;
using Iesi.Collections.Generic;

namespace BackToOwner.Golf.Web.Models
{
    public class Owner:Entity
    {
        private Iesi.Collections.Generic.ISet<Badge> _badges;
        private IDictionary<int,string> _emailAddresses;
        private IDictionary<int, string> _mobilesValues;
       

        public Owner()
        {
            _badges = new HashedSet<Badge>();
            _emailAddresses = new Dictionary<int,string>();
            _mobilesValues = new Dictionary<int, string>();
            _registrationDate = DateTime.Now;
        }

        public Owner(Language language, Badge badge):this()
        {
            if (badge==null)
            {
                throw new ArgumentNullException("badge");
            }
            _language = language;
            _badges.Add(badge);
            badge.SetOwner(this);
        }

        public virtual string PasswordHash { get; set; }
        public virtual string PasswordSalt { get; set; }

        private DateTime _registrationDate;
        public virtual DateTime RegistrationDate
        {
            get { return _registrationDate; }
            set { _registrationDate = value; }
        }

        public virtual Gender Gender { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        private Language _language;
        public virtual Language Language
        {
            get { return _language; }
            set { _language = value; }
        }

        public virtual IList<Badge> Badges
        {
            get { return new List<Badge>(_badges); }
        }

        public virtual IDictionary<int,string> EmailAddresses
        {
            get { return _emailAddresses; }
            set { _emailAddresses = value; }
        }

        public virtual IDictionary<int,string> Mobiles
        {
            get { return _mobilesValues; }
            set { _mobilesValues = value; }
        }

        public virtual bool AddBadge(Badge newItem)
        {
            if (newItem == null || newItem.Owner != null)
            {
                throw new InvalidOperationException("Can't add badge to owner, badge is invalid or allready activated!");
            }

            if (_badges.Add(newItem))
            {
                newItem.Owner = this;
                return true;
            }
            return false;
        }

        public virtual bool RemoveBadge(Badge itemToRemove)
        {

            if (this.Badges.Count==1)
            {
                throw new InvalidOperationException("Can't remove the latest badge of an owner!");
            }

            if (!this.Badges.Contains(itemToRemove))
            {
                return false;
            }

            if (itemToRemove != null)
            {
                this._badges.Remove(itemToRemove);
                itemToRemove.Owner = null;
                return true;
            }

            return false;
        }

        public virtual bool RemoveAllBadges()
        {
            foreach (var itemToRemove in this._badges)
            {
                this._badges.Remove(itemToRemove);
                itemToRemove.Owner = null;
                return true;
            }

            return false;
        }     
    }
}