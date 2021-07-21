using System.Collections.Generic;

namespace SuprDaily.Entities.Warehouse
{
    public class WarehouseDayWiseList
    {
        public Dictionary<int, WarehouseItem> Items { get; set; } = new Dictionary<int, WarehouseItem>();
        public Dictionary<string, WarehouseCategory> Categories { get; set; } = new Dictionary<string, WarehouseCategory>();
    }
}