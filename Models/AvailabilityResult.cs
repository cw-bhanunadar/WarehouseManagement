using Newtonsoft.Json;
namespace SuprDaily.Model
{
    public class AvailabilityResult
    {
        [JsonProperty("can_fulfil")]
        public bool Result { get; set; }
    }
}