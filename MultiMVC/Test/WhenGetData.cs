using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BA.MultiMvc.Test
{
    [TestClass]
    public class WhenGetData:GivenWhenThen
    {
        protected List<RessourceDictionaryItem> RessourcesToSerialize;
        protected string Path = "RessourceDictionary.xml";

        public override void Given()
        {
           base.Given();
           RessourcesToSerialize = new List<RessourceDictionaryItem>();
           RessourcesToSerialize.Add(new RessourceDictionaryItem
                                         {En = "Hello world", Fr = "Bonjour le monde", Nl = "Dag de wereld"}
                                         );
           RessourcesToSerialize.Add(new RessourceDictionaryItem {En = "Other Hello world!"});
          
            
            
        }

        public override void When()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<RessourceDictionaryItem>));
            using (FileStream stream = new FileStream(Path, FileMode.OpenOrCreate))
            {
                serializer.Serialize(stream, RessourcesToSerialize);
                stream.Close();
            };
        }

        [TestMethod]
        public void ThenFileExist()
        {
            Assert.IsTrue(File.Exists(Path));
        }

        [TestMethod]
        public void ThenCanDeserilize()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<RessourceDictionaryItem>));
            List<RessourceDictionaryItem> deserilizedObject;
             using (FileStream stream = new FileStream(Path, FileMode.Open))
             {
                 deserilizedObject = (List<RessourceDictionaryItem>)serializer.Deserialize(stream);
                 stream.Close();
             }

            Assert.AreEqual(2, deserilizedObject.Count);
        }
    }
}
