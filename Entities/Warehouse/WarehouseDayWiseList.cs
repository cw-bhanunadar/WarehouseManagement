using System.Collections.Generic;

namespace SuprDaily.Entities.Warehouse
{
    public class WarehouseDayWiseList
    {
        public Dictionary<int, WarehouseItem> Items { get; set; } = new Dictionary<int, WarehouseItem>();
        public Dictionary<int, WarehouseCategory> Categories { get; set; } = new Dictionary<int, WarehouseCategory>();
    }
}