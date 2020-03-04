using System;

namespace Common
{
    public class Measurement
    {
        public long Time { get; set; }
        private DateTime Date { get; set; }
        public string Value { get; set; }
        public string MeasurementType { get; set; }
        public Measurement()
        {
            Time = DateTime.Now.Ticks;
            
            Random random = new Random();
            Value= random.Next(0, 35).ToString();

            string[] typeOfTypes = new string[] { "Celsius", "Humidity","Air pressure" };
            MeasurementType = typeOfTypes[random.Next(0, typeOfTypes.Length)];

            Date = new DateTime(Time);
        }

        public override string ToString()
        {
            return $"Value: {Value}, Type: {MeasurementType}" +
                $", Time: {Date.Year}.{Date.Month}.{Date.Day} {Date.Hour}:{Date.Minute}:{Date.Second}";
        }
    }
}