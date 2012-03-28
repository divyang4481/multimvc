using System.Collections.Generic;
using BA.MultiMvc.Framework;

namespace BA.MultiMvc.Test
{
    public class GivenResourcesToSerialize:GivenWhenThen
    {
        protected List<FileResourceProvider.RessourceDictionaryItem> ResourcesToSerialize;
        protected string Path = "Ressources.xml";

        public override void Given()
        {
            base.Given();
            ResourcesToSerialize = new List<FileResourceProvider.RessourceDictionaryItem>();
            ResourcesToSerialize.Add(new FileResourceProvider.RessourceDictionaryItem { En = "Hello world", Fr = "Bonjour le monde", Nl = "Dag de wereld" , Key="Hello"}
                );
            ResourcesToSerialize.Add(new FileResourceProvider.RessourceDictionaryItem { En = "Other Hello world!",Key="Other" });
        }
    }
}