using Newtonsoft.Json;
namespace DataCollectApi.Data
{
    public class LocationData
    {
        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }


    }
}