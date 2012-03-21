using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using BA.MultiMvc.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace BA.MultiMvc.Test
{
    [TestClass]
    public class WhenGetRessourceFromFile:GivenResourcesToSerialize
    {
        private IDictionary<string, string> Result; 
        private FileResourceProvider fileRessourceProvider;
        public override void Given()
        {
            base.Given();
            var tenantContextProvider = MockRepository.GenerateMock<ITenantContextProvider>();
            tenantContextProvider.Stub(n => n.Language).Return("fr");
            TenantContext.SetTenantContextProvider(tenantContextProvider);

            XmlSerializer serializer = new XmlSerializer(typeof(List<RessourceDictionaryItem>));
            using (FileStream stream = new FileStream(Path, FileMode.OpenOrCreate))
            {
                serializer.Serialize(stream, ResourcesToSerialize);
                stream.Close();
            };
            fileRessourceProvider = new FileResourceProvider();
        }

        public override void When()
        {
            base.When();
            this.Result = fileRessourceProvider.GetResources();

        }

        [TestMethod]
        public void ThenResltIsNotEmpty()
        {
            Assert.IsTrue(this.Result.Count>0);
        }
    }

    public class FileResourceProvider : IResourceProvider
    {
        public IDictionary<string, string> GetResources()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<RessourceDictionaryItem>));
            List<RessourceDictionaryItem> ressources;
            using (FileStream stream = new FileStream("Ressources.xml", FileMode.Open))
            {
                ressources = (List<RessourceDictionaryItem>)serializer.Deserialize(stream);
                stream.Close();
            }
            Dictionary<string,string> ret = new Dictionary<string, string>();
            foreach (var ressourceDictionaryItem in ressources)
            {
                if (TenantContext.Language.ToLower()=="fr")
                {
                    ret.Add(ressourceDictionaryItem.Key ,ressourceDictionaryItem.Fr);
                }
                if (TenantContext.Language.ToLower() == "nl")
                {
                    ret.Add(ressourceDictionaryItem.Key, ressourceDictionaryItem.Nl);
                }
                if (TenantContext.Language.ToLower() == "en")
                {
                    ret.Add(ressourceDictionaryItem.Key, ressourceDictionaryItem.En);
                }
            }
            return ret;
        }
    }
}
