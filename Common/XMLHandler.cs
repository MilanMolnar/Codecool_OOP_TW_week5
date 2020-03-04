using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Common
{
    public class XMLHandler
    {

        public static void SavetoXml(Sensor sensor)
        {
            using (StreamWriter writer = new StreamWriter("test.xml"))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Sensor));
                xml.Serialize(writer, sensor);
            }

        }
        public Dictionary<string,Measurement> LoadFromXml() //String will be the sensor's ID
        {
            return null;
        }
    }
}
