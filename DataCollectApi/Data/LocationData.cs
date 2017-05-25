using Newtonsoft.Json;
namespace DataCollectApi.Data
{
    public class LocationData
    {
        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }
        public string Owner { get; set; }
        public double[] latitude { get; set; }
        public double[] longitude { get; set; }


    }
}