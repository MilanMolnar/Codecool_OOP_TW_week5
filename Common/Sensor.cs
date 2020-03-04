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
        public Sensor()
        {
            Random random = new Random();
            ID=random.Next(1, 100000).ToString();

        }
        public void AddMeasurement(Measurement measurement)
        {
            this.MeasurementOfSensor = measurement;
        }

        public override string ToString()
        {
            return $"Sensor ID : {ID}, Type: {MeasurementOfSensor.MeasurementType}, Value: {MeasurementOfSensor.Value}";
        }
    }
}
