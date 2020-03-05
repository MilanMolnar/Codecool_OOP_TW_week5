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
        public static Dictionary<string, List<Measurement>> LoadFromXml() //String will be the sensor's ID
        {
            Dictionary<string, List<Measurement>> measurementsDict = new Dictionary<string, List<Measurement>>();
            XElement SensorNode = XElement.Load("measurement.xml");
            foreach (var nodes in SensorNode.Elements())
            {
                string id = nodes.Attribute("id").Value;

                Measurement measurement = new Measurement();
                foreach (var node in nodes.Elements())
                {
                    measurement.Time = Convert.ToInt64(node.Element("time").Value);
                    measurement.Value = node.Element("value").Value;
                    measurement.MeasurementType = node.Element("type").Value;

                    if (measurementsDict.ContainsKey(id))
                    {
                        measurementsDict[id].Add(measurement);
                    }
                    else
                    {
                        measurementsDict.Add(id, new List<Measurement>() { measurement });
                    }
                }
            }

            return measurementsDict;
        }
        public static void SaveDictToXML(Dictionary<string, List<Measurement>> dict)
        {
            //XAttribute asdasd = new XAttribute("id", );
            XElement sensorRoot = new XElement("Sensor");
            
            foreach (var kvp in dict)
            {
                XElement measurementsNode = new XElement("measurements", new XAttribute("id", kvp.Key));
                sensorRoot.Add(measurementsNode);
                foreach(var measurement in kvp.Value)
                {
                    XElement measurementNode = new XElement("measurement");
                    measurementNode.Add(new XElement("time", measurement.Time));
                    measurementNode.Add(new XElement("value", measurement.Value));
                    measurementNode.Add(new XElement("type", measurement.MeasurementType));
                    measurementsNode.Add(measurementNode);
                }
            }
            sensorRoot.Save("database.xml");
        }
    }
}