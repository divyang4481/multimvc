namespace BA.MultiMVC.Framework.Ressources
{
    public interface IRessourceDictionary
    {
        #region Properties

        int Count
        {
            get;
        }

        string this[string key]
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        void Add(string key, string value);

        System.Collections.Generic.IList<System.Web.Mvc.SelectListItem> ToSelectListItemList();

        System.Collections.Generic.IList<System.Web.Mvc.SelectListItem> ToSelectListItemList(string p);

        #endregion Methods
    }
}