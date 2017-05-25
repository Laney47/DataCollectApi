using Newtonsoft.Json;
namespace DataCollectApi.Data
{
    public class AccelerometerData
    {
        //Propertykkkk
        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }
        public string Owner { get; set; }
        public double[] x { get; set; }
        public double[] y { get; set; }
        public double[] z { get; set; }

    }
}

