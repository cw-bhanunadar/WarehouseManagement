using Newtonsoft.Json;
namespace SuprDaily.Model
{
    public class ReserveOrderData
    {
        [JsonProperty("reserved")]
        public bool Reserved { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}