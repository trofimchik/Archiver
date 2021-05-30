using System;
using System.Xml.Serialization;
using System.IO;

namespace Archiver.Models
{
    public static  class XMLReader
    {
        public static CompressionSettings GetCompressionSettings()
        {
            XmlSerializer reader = new XmlSerializer(typeof(CompressionSettings));
            StreamReader file = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}config.xml");
            CompressionSettings compressSettings = (CompressionSettings)reader.Deserialize(file);
            file.Close();
            return compressSettings;
        }
       
    }
}
