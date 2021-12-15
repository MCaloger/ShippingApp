using Microsoft.EntityFrameworkCore;
using ShippingApp.Data;
using ShippingApp.Models;

namespace ShippingApp.Services
{
    public class OrderService
    {
        /// <summary>
        /// Injcted database context
        /// </summary>
        private readonly DataContext _context;

        /// <summary>
        /// database context injection
        /// </summary>
        /// <param name="context"></param>
        public OrderService(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create order
        /// </summary>
        /// <param name="Order"></param>
        /// <returns>Id of created order</returns>
        public long Create(OrderModel Order)
        {
            var OrderToAdd = Order;
            OrderToAdd.IsComplete = false;

            _context.Orders.Add(Order);
            _context.SaveChanges();
            return OrderToAdd.OrderId;
        }

        /// <summary>
        /// Get a list of all orders
        /// </summary>
        /// <returns>List of orders</returns>
        public List<OrderModel> GetAllOrders()
        {
            var orders = _context.Orders.FromSqlRaw("SELECT * FROM ORDERS").ToList();
            return orders;
        }

        /// <summary>
        /// Get a single order by ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public OrderModel GetOrderById(long Id)
        {
            var Order = _context.Orders.Where(Order => Order.OrderId == Id).FirstOrDefault();
            
            return Order;
        }

        /// <summary>
        /// Delete order by id
        /// </summary>
        /// <param name="Id"></param>
        public void DeleteOrderById(long Id)
        {
            var order = _context.Orders.Where(order => order.OrderId == Id).FirstOrDefault();
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update order by id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Order"></param>
        public void UpdateOrderById(long Id, OrderModel Order)
        {
            Order.OrderId = Id;
            _context.Orders.Update(Order);
            _context.SaveChanges();
        }
    }
}
