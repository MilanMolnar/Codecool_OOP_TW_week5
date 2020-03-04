namespace Common
{
    public class Measurement
    {
        public string Value { get; set; } = "value12";
        public string MeasurementType { get; set; } = "type12";
        public Measurement()
        {

        }
        public Measurement(string value, string measurementType)
        {
            Value = value;
            MeasurementType = measurementType;
        }
        public override string ToString()
        {
            return $"Value: {Value}, Type: {MeasurementType}";
        }
    }
}