using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web.Mvc;

namespace BA.MultiMVC.Framework.Ressources
{
    [Serializable]
    public class RessourceDictionary : Dictionary<string, string>, IRessourceDictionary
    {
        #region Constructors

        public RessourceDictionary()
        {
        }

        protected RessourceDictionary(
            SerializationInfo info,
            StreamingContext context)
            : base(info,context)
        {
        }

        #endregion Constructors

        #region Methods

        public IList<SelectListItem> ToSelectListItemList()
        {
            var query = from p in this
                        select new SelectListItem
                                   {
                                       Text = p.Value,
                                       Value = p.Key
                                   };
            return query.ToList();
        }

        public IList<SelectListItem> ToSelectListItemList(string selectedValue)
        {
            var query =   from p in this
                          select new SelectListItem
                                     {
                                         Text = p.Value,
                                         Value = p.Key,
                                         Selected = (selectedValue== p.Key)
                                     };
            return query.ToList();
        }

        #endregion Methods
    }
}