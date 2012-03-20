using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BA.MultiMvc.Framework;

namespace BackToOwner.Golf.Web.Test.Stubs
{
    public class StubResourceProvider:IResourceProvider
    {
        public IDictionary<string, string> GetResources()
        {
            var dico = new StubDico();
            return dico;
        }
    }

    public class StubDico:IDictionary<string,string>
    {

        #region IDictionary<string,string> Members

        public void Add(string key, string value)
        {
        }

        public bool ContainsKey(string key)
        {
            return true;
        }

        public ICollection<string> Keys
        {
            get { return new List<string>() { "stubKey" }; }
        }

        public bool Remove(string key)
        {
            return true;
        }

        public bool TryGetValue(string key, out string value)
        {
            value = "stubValue";
            return true;
        }

        public ICollection<string> Values
        {
            get { return new List<string>() {"stubValue"}; }
        }

        public string this[string key]
        {
            get { return "stubValue"; }
            set { }
        }

    #endregion

    #region ICollection<KeyValuePair<string,string>> Members

    public void Add(KeyValuePair<string, string> item)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(KeyValuePair<string, string> item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public int Count
    {
        get { throw new NotImplementedException(); }
    }

    public bool IsReadOnly
    {
        get { throw new NotImplementedException(); }
    }

    public bool Remove(KeyValuePair<string, string> item)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region IEnumerable<KeyValuePair<string,string>> Members

    public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    #endregion

    #region IEnumerable Members

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    #endregion
}
}
