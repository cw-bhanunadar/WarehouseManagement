using System.Collections.Generic;

namespace SuprDaily.Entities
{
    public class Order
    {
        public int CustomerId { get; set; }
        public string DeliveryDate { get; set; }
        public int WarehouseId { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
    }
}