using Microsoft.AspNetCore.Mvc;
using ShippingApp.Models;
using ShippingApp.Services;

namespace ShippingApp.Controllers
{
    public class OrderController : Controller
    {
        OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [Route("Order/")]
        public IActionResult Index()
        {
            var Order = new OrderModel();
            Order.OrderId = 1;
            Order.IsComplete = false;
            Order.Description = "Ship 20KG of goods";

            return View();
        }

        [Route("Order/order/{id}")]
        public IActionResult DisplayOne(long Id)
        {
            var Order = _orderService.FindById(Id);

            
            return View("Order", Order);
        }
        [Route("Order/new")]
        public IActionResult New()
        {
            var Order = new OrderModel();
            return View("New", Order);
        }

        [Route("Order/create")]
        public IActionResult Create(OrderModel Order)
        {
            long OrderId = _orderService.Create(Order);

            Console.WriteLine("Created");

            return RedirectToAction("Index");
            
        }

        [Route("Order/sanity")]
        public IActionResult sanity()
        {
            ViewBag.message = _orderService.Sanity();
            return View("Sanity");
            
        }
    }
}
