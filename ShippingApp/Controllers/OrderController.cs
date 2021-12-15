using Microsoft.AspNetCore.Mvc;
using ShippingApp.Models;
using ShippingApp.Services;

namespace ShippingApp.Controllers
{
    public class OrderController : Controller
    {
        /// <summary>
        /// Injected order service
        /// </summary>
        OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// /order root
        /// </summary>
        /// <returns>View displaying Order page</returns>
        [Route("Order/")]
        public IActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// Display a single order based on ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>View showing order based on ID</returns>
        [Route("Order/o/{id}")]
        public IActionResult DisplayOne(long Id)
        {
            var Order = _orderService.GetOrderById(Id);
            return View("Order", Order);
        }

        /// <summary>
        /// Page to create a new order
        /// </summary>
        /// <returns>View with order creation form</returns>
        [Route("Order/new")]
        public IActionResult New()
        {
            var Order = new OrderModel();
            return View("New", Order);
        }

        /// <summary>
        /// Action to create order and display a success page
        /// </summary>
        /// <param name="Order"></param>
        /// <returns>View with success page</returns>
        [Route("Order/create")]
        public IActionResult Create(OrderModel Order)
        {
            long OrderId = _orderService.Create(Order);
            var newOrder = _orderService.GetOrderById(OrderId);

            return View("Created", newOrder);
            
        }

        /// <summary>
        /// Display all orders
        /// </summary>
        /// <returns>View with all orders</returns>
        [Route("Order/all")]
        public IActionResult AllOrders()
        {
            IEnumerable<OrderModel> orders = _orderService.GetAllOrders();
            return View("All", orders);
        }

        [Route("Order/delete/{id}")]
        public IActionResult DeleteOrder(long Id)
        {
            var order = _orderService.GetOrderById(Id);

            _orderService.DeleteOrderById(Id);

            return View("Deleted", order);
        }

        [Route("Order/editor/{id}")]
        public IActionResult OrderEditor(long Id)
        {
            var order = _orderService.GetOrderById(Id);
            return View("Editor", order);
        }

        [Route("Order/edit/{id}")]
        public IActionResult EditOrder(long Id, OrderModel Order)
        {
            _orderService.UpdateOrderById(Id, Order);

            return View("Edited", Order);
        }
    }
}
