using SuprDaily.Entities.Enums;

namespace SuprDaily.Entities.Warehouse
{
    public class WarehouseCategory
    {
        public string CategoryId { get; set; }
        public int QuantityLimit { get; set; }
        public int SoldQuantity { get; set; }
    }
}