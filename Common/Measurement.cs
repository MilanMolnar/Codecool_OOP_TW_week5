using System;

namespace Common
{
    public class Measurement
    {
        public DateTime Time { get; set; }
        public string Value { get; set; }
        public string MeasurementType { get; set; }
        public Measurement(){}
        public Measurement(string value, string measurementType, DateTime time)
        {
            Time = time;
            Value = value;
            MeasurementType = measurementType;
        }
        public override string ToString()
        {
            return $"Value: {Value}, Type: {MeasurementType}" +
                $", Time: {Time.Year}.{Time.Month}.{Time.Day}\\t{Time.Hour}:{Time.Minute}:{Time.Second}";
        }
    }
}