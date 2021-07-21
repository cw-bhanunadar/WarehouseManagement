using System.Collections.Generic;

namespace SuprDaily.Entities.Warehouse
{
    public class Warehouse
    {
        public int Id { get; set; }
        public Dictionary<string, WarehouseDayWiseList> DailyStats { get; set; } = new Dictionary<string, WarehouseDayWiseList>();
    }
}