using System;
using System.Collections.Generic;
using SuprDaily.Business.Interface;
using SuprDaily.Entities;
using SuprDaily.Entities.Warehouse;

namespace SuprDaily.Business
{
    public class WarehouseManager : IWarehouseManager
    {
        private Dictionary<int, Warehouse> warehouseList;
        public WarehouseManager()
        {
            warehouseList = new Dictionary<int, Warehouse>();
        }
        public bool AddWarehouse(int id)
        {
            if(warehouseList.ContainsKey(id))
            {
                return false;
            }
            warehouseList.Add(id, new Warehouse());
            return true;
        }
        public bool AddItemToWarehouse(int id, WarehouseItem item, string date)
        {
            if(!warehouseList.ContainsKey(id))
            {
                warehouseList.Add(id, new Warehouse());
            }
            var warehouse = warehouseList[id];
            var warehouseAvailaibility = warehouse.DailyStats;
            if(!warehouseAvailaibility.ContainsKey(date))
            {
                warehouseAvailaibility[date] = new WarehouseDayWiseList();
            }
            var itemList = warehouseAvailaibility[date];
            if(itemList.Items.ContainsKey(item.ItemId))
            {
                itemList.Items[item.ItemId].TotalQuantity += item.TotalQuantity;
            }
            else
            {
                itemList.Items[item.ItemId] = item;
            }
            Console.WriteLine("Added Item");
            return true;
        }
        public bool AddCategoryToWarehouse(int id, WarehouseCategory category, string date)
        {
            if(!warehouseList.ContainsKey(id))
            {
                warehouseList.Add(id, new Warehouse());
            }
            var warehouse = warehouseList[id];
            var warehouseAvailaibility = warehouse.DailyStats;
            if(!warehouseAvailaibility.ContainsKey(date))
            {
                warehouseAvailaibility[date] = new WarehouseDayWiseList();
            }
            var itemList = warehouseAvailaibility[date];
            if(itemList.Categories.ContainsKey(category.CategoryId))
            {
                itemList.Categories[category.CategoryId].QuantityLimit += category.QuantityLimit;
            }
            else
            {
                itemList.Categories[category.CategoryId] = category;
            }
             Console.WriteLine("Added Category");
            return true;
        }
        public bool CheckIfOrderCanBeServed(Order orders)
        {
            if(!IsOrderValid(orders))
            {
                Console.WriteLine("Inavlid order");
                return false;
            }
            int warehouseId = orders.WarehouseId;
            var warehouseAvailaibility = warehouseList[warehouseId].DailyStats[orders.DeliveryDate];
            var itemList = warehouseAvailaibility.Items;
            var categoryList = warehouseAvailaibility.Categories;
            foreach(var item in orders.Items)
            {
                if(!itemList.ContainsKey(item.Id) || !categoryList.ContainsKey(item.Category))
                {
                    Console.WriteLine("Item not found");
                    // Item or category present
                    return false;
                }
                var purchaseItem = itemList[item.Id];
                var purchaseCategory = categoryList[item.Category];
                if(!IsQuantityValid(purchaseItem, purchaseCategory, item))
                {
                    Console.WriteLine("Item cannot served");
                    return false;
                }
            }
            return true;
        }
        public bool ReserveOrder(Order orders)
        {
            if(!CheckIfOrderCanBeServed(orders))
            {
                return false;
            }
            int warehouseId = orders.WarehouseId;
            var warehouseAvailaibility = warehouseList[warehouseId].DailyStats[orders.DeliveryDate];
            var itemList = warehouseAvailaibility.Items;
            var categoryList = warehouseAvailaibility.Categories;
            foreach(var item in orders.Items)
            {
                var purchaseItem = itemList[item.Id];
                var purchaseCategory = categoryList[item.Category];
                ReserveOrder(purchaseItem, purchaseCategory, item);
            }
            return true;
        }
        private bool IsOrderValid(Order orders)
        {
            int warehouseId = orders.WarehouseId;
            if(!warehouseList.ContainsKey(warehouseId))
            {
                // No warehouse of that Id present
                Console.WriteLine("No warehouse found"+ warehouseId);
                return false;
            }
            var warehouseAvailaibility = warehouseList[warehouseId].DailyStats[orders.DeliveryDate];
            if(warehouseAvailaibility == null)
            {
                // No items registered for that day
                Console.WriteLine("No Date "+ warehouseId);
                return false;
            }
            return true;
        }
        private bool IsQuantityValid(WarehouseItem warehouseItem, WarehouseCategory warehouseCategory, Item item)
        {
            return (warehouseItem.SoldQuantity + item.Quantities <= warehouseItem.TotalQuantity) && (warehouseCategory.SoldQuantity + item.Quantities <= warehouseCategory.QuantityLimit);
        }
        private void ReserveOrder(WarehouseItem warehouseItem, WarehouseCategory warehouseCategory, Item item)
        {
            warehouseItem.SoldQuantity += item.Quantities;
            warehouseCategory.SoldQuantity += item.Quantities;
        }
    }

}