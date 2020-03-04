using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Common
{
    [XmlInclude(typeof(Measurement))]

    public class Sensor
    {
        public string ID { get; set; } = "12";
        public Measurement MeasurementOfSensor { get; set; }
        public Sensor()
        {

        }
        public Sensor(string id, Measurement measurementOfSensor)
        {
            ID = id;
            MeasurementOfSensor = measurementOfSensor;
        }
        public void AddMeasurement()
        {

        }

        public override string ToString()
        {
            return $"Sensor ID : {ID}, {MeasurementOfSensor}";
        }
    }
}
