using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BA.MultiMvc.Framework.NHibernate;

namespace BackToOwner.Golf.Web.Models
{
    public class Lot:Entity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime RegistrationDate { get; set; }
        public virtual int Amount { get; set; }

    }
}