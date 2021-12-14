using Microsoft.AspNetCore.Mvc;
using ShippingApp.Models;
using ShippingApp.Services;

namespace ShippingApp.Controllers
{
    public class OrderController : Controller
    {
        OrderService OrderService = new OrderService();

        public IActionResult Index()
        {
            return View();
        }

        public void Create(OrderModel Order)
        {
            OrderService.Create(Order);
        }
    }
}
