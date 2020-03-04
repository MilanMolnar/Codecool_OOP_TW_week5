using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Xml.Linq;

namespace Common
{
    public class XMLHandler
    {

        public static void SavetoXml(Sensor sensor)
        {
            XElement measurement = new XElement("measurement");
            measurement.Add(new XAttribute("id", sensor.ID));
            measurement.Add(new XElement("time", sensor.MeasurementOfSensor.Time),
                            new XElement("value", sensor.MeasurementOfSensor.Value),
                            new XElement("type", sensor.MeasurementOfSensor.MeasurementType));
            measurement.Save("measurement.xml");
        }
        public Dictionary<string, Measurement> LoadFromXml() //String will be the sensor's ID
        {
            return null;
        }
    }
}