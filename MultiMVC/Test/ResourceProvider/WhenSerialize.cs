using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using BA.MultiMvc.Framework;
using NUnit.Framework;

namespace BA.MultiMvc.Test
{
    public class WhenSerialize:GivenResourcesToSerialize
    {
        public override void When()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<FileResourceProvider.RessourceDictionaryItem>));
            using (FileStream stream = new FileStream(Path, FileMode.OpenOrCreate))
            {
                serializer.Serialize(stream, ResourcesToSerialize);
                stream.Close();
            };
        }

        [Test]
        public void ThenFileExist()
        {
            Assert.IsTrue(File.Exists(Path));
        }

        [Test]
        public void ThenCanDeserilize()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<FileResourceProvider.RessourceDictionaryItem>));
            List<FileResourceProvider.RessourceDictionaryItem> deserilizedObject;
             using (FileStream stream = new FileStream(Path, FileMode.Open))
             {
                 deserilizedObject = (List<FileResourceProvider.RessourceDictionaryItem>)serializer.Deserialize(stream);
                 stream.Close();
             }

            Assert.AreEqual(2, deserilizedObject.Count);
        }
    }
}
