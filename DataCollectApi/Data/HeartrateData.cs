using Newtonsoft.Json;
namespace DataCollectApi.Data
{
    public class HeartrateData
    {
        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }
        public string Owner { get; set; }
        public double[] heartrate { get; set; }
        


    }
}
