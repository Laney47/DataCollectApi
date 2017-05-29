using Newtonsoft.Json;
namespace DataCollectApi.Data
{
    public class AccelerometerData
    {
       
        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }
        [JsonProperty(PropertyName = "owner")]
        public string Owner { get; set; }
        [JsonProperty(PropertyName = "x")]
        public double[] x { get; set; }
        [JsonProperty(PropertyName = "y")]
        public double[] y { get; set; }
        [JsonProperty(PropertyName = "z")]
        public double[] z { get; set; }

    }
}

