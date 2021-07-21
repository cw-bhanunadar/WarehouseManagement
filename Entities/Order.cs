using System.Collections.Generic;
using Newtonsoft.Json;

namespace SuprDaily.Entities
{
    public class Order
    {
        [JsonProperty("customer_id")]
        public int CustomerId { get; set; }
        [JsonProperty("delivery_date")]
        public string DeliveryDate { get; set; }
        [JsonProperty("warehouse_id")]
        public int WarehouseId { get; set; }
        [JsonProperty("items")]
        public List<Item> Items { get; set; } = new List<Item>();
    }
}