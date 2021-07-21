using SuprDaily.Entities.Enums;

namespace SuprDaily.Entities.Warehouse
{
    public class WarehouseCategory
    {
        public Category CategoryId { get; set; }
        public int QuantityLimit { get; set; }
        public int SoldQuantity { get; set; }
    }
}