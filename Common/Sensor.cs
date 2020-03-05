using System;
using System.Net;
using System.Net.Sockets;
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
            ID = GetLocalIPAddress();
        }
        public void AddMeasurement(Measurement measurement)
        {
            this.MeasurementOfSensor = measurement;
        }

        public override string ToString()
        {
            return $"Sensor ID : {ID}, Type: {MeasurementOfSensor.MeasurementType}, Value: {MeasurementOfSensor.Value}";
        }

        public string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
