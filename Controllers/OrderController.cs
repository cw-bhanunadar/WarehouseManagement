using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuprDaily.Business;
using SuprDaily.Entities;
using SuprDaily.Entities.Warehouse;
using SuprDaily.Model;

namespace SuprDaily.Controller
{
    public class OrderController : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet, Route("api/orders/availability")]
        public async Task<ActionResult> CheckOrderAvailability(Order orders)
        {
            PopulateData();
            if(orders == null)
            {
                Console.WriteLine("Order recieved null");
                return BadRequest();
            }
            Console.WriteLine("Order recieved");
            WarehouseManager manager = new WarehouseManager();
            var result = new AvailabilityResult();
            result.Result = manager.CheckIfOrderCanBeServed(orders);
            return Json(result);
        }
        [HttpPost, Route("api/orders/reserve")]
        public async Task<ActionResult> ReserveOrder(Order orders)
        {
            if(orders == null)
            {
                return BadRequest();
            }
            Console.WriteLine("Order recieved");
            WarehouseManager manager = new WarehouseManager();
            var result = manager.ReserveOrder(orders);
            var response = GetResponseObject(result);
            return Json(response);
        }
        private ReserveOrderResponse GetResponseObject(bool result)
        {
            var response = new ReserveOrderResponse();
            response.Data.Reserved = result;
            response.Data.Message = result ? "Success" : "Insufficient Quantities";
            return response;
        }
        private void PopulateData()
        {
            WarehouseManager manager = new WarehouseManager();
            var item = new WarehouseItem{
                ItemId = 1,
                TotalQuantity = 3
            };
            manager.AddItemToWarehouse(100, item, "2020-10-13");
            var category = new WarehouseCategory {
                CategoryId = "F_N_V",
                QuantityLimit = 3
            };
            manager.AddCategoryToWarehouse(100, category, "2020-10-13");
        }
    }
}