using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Xml.Serialization;

namespace BA.MultiMvc.Framework
{
    public class FileResourceProvider : IResourceProvider
    {
        public class RessourceDictionaryItem
        {
            public string Key { get; set; }
            public string Fr { get; set; }
            public string Nl { get; set; }
            public string En { get; set; }
        }

        public IDictionary<string, string> GetResources()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<RessourceDictionaryItem>));
            
            List<RessourceDictionaryItem> ressources;
            string filePath = System.Web.Hosting.HostingEnvironment.MapPath("~/Ressources.xml") ?? "Ressources.xml";

            using (FileStream stream = new FileStream(filePath, FileMode.Open,FileAccess.Read))
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