using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Common
{
    [XmlInclude(typeof(Measurement))]

    public class Sensor
    {
        public string ID { get; set; }
        public Measurement MeasurementOfSensor { get; set; }
        public Sensor(){}
        public Sensor(string id)
        {
            ID = id;
        }
        public void AddMeasurement(string value, string measurementType, DateTime time)
        {
            this.MeasurementOfSensor = new Measurement(value, measurementType, time);
        }

        public override string ToString()
        {
            return $"Sensor ID : {ID}, Type: {MeasurementOfSensor.MeasurementType}, Value: {MeasurementOfSensor.Value}";
        }
    }
}
