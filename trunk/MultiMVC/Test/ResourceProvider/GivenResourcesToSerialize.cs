using System.Collections.Generic;

namespace BA.MultiMvc.Test
{
    public class GivenResourcesToSerialize:GivenWhenThen
    {
        protected List<RessourceDictionaryItem> ResourcesToSerialize;
        protected string Path = "RessourceDictionary.xml";

        public override void Given()
        {
            base.Given();
            ResourcesToSerialize = new List<RessourceDictionaryItem>();
            ResourcesToSerialize.Add(new RessourceDictionaryItem { En = "Hello world", Fr = "Bonjour le monde", Nl = "Dag de wereld" }
                );
            ResourcesToSerialize.Add(new RessourceDictionaryItem { En = "Other Hello world!" });
        }
    }
}