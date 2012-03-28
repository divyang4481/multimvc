﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using BA.MultiMvc.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BA.MultiMvc.Test
{
    [TestClass]
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

        [TestMethod]
        public void ThenFileExist()
        {
            Assert.IsTrue(File.Exists(Path));
        }

        [TestMethod]
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