using Newtonsoft.Json;
using SuprDaily.Entities.Enums;

namespace SuprDaily.Entities
{
    public class Item
    {
        [JsonProperty("item_id")]
        public int Id { get; set; }
        [JsonProperty("item_name")]
        public string Name { get; set; }
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("quantity")]
        public int Quantities { get; set; }
    }
}