using Newtonsoft.Json;
namespace DataCollectApi.Data
{
    public class RegisterUserData
    {
        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
        public int height { get; set; }
        public double weight { get; set; }
        public int age { get; set; }
        public string gender { get; set; }


    }
}