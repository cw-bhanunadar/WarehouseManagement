using SuprDaily.Entities;
using SuprDaily.Entities.Warehouse;

namespace SuprDaily.Business.Interface
{
    public interface IWarehouseManager
    {
        bool AddWarehouse(int id);
        bool AddItemToWarehouse(int id, WarehouseItem item);
        bool AddCategoryToWarehouse(int id, WarehouseCategory category);
        bool CheckIfOrderCanBeServed(Order orders);
        bool ReserveOrder(Order orders);
    }
}