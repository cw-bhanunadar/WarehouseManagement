using Newtonsoft.Json;
namespace SuprDaily.Model
{
    public class ReserveOrderResponse
    {
        [JsonProperty("code")]
        public string Code { get; set; } = "Success";
        [JsonProperty("data")]
        public ReserveOrderData Data { get; set; } = new ReserveOrderData();
    }
}