using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuprDaily.Entities;

namespace SuprDaily.Controller
{
    public class OrderController : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost, Route("api/orders/availability")]
        public async Task<ActionResult> CheckOrderAvailability(Order orders)
        {
            if(orders == null)
            {
                return BadRequest();
            }
            return Json(true);
        }
    }
}