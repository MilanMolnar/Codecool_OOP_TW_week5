using System;

namespace Common
{
    public class Measurement
    {
        public DateTime Time { get; set; }
        public string Value { get; set; }
        public string MeasurementType { get; set; }
        public Measurement()
        {
            var date2 = DateTime.Now.Ticks;
            Time = new DateTime(date2);

            Random random = new Random();
            Value= random.Next(0, 35).ToString();

            string[] typeOfTypes = new string[] { "Celsius", "Humidity","Air pressure" };
            MeasurementType = typeOfTypes[random.Next(0, typeOfTypes.Length)];
        }

        public override string ToString()
        {
            return $"Value: {Value}, Type: {MeasurementType}" +
                $", Time: {Time.Year}.{Time.Month}.{Time.Day} {Time.Hour}:{Time.Minute}:{Time.Second}";
        }
    }
}