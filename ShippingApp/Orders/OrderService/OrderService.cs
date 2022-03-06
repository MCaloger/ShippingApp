using Microsoft.EntityFrameworkCore;
using ShippingApp.Data;
using ShippingApp.Models;

namespace ShippingApp.Services
{
    public class OrderService : IOrderService
    {
        /// <summary>
        /// Injcted database context
        /// </summary>
        private readonly DataContext _dataContext;

        /// <summary>
        /// database context injection
        /// </summary>
        /// <param name="context"></param>
        public OrderService(DataContext context)
        {
            _dataContext = context;
        }

        /// <summary>
        /// Create order
        /// </summary>
        /// <param name="Order"></param>
        /// <returns>Created order</returns>
        OrderModel? IOrderService.Create(OrderModel Order)
        {
            var OrderToAdd = Order;
            OrderToAdd.IsComplete = false;

            _dataContext.Orders.Add(Order);
            _dataContext.SaveChanges();
            return OrderToAdd;
        }

        /// <summary>
        /// Get a list of all orders
        /// </summary>
        /// <returns>List of orders</returns>
        List<OrderModel>? IOrderService.ReadAll()
        {
            var orders = _dataContext.Orders.FromSqlRaw("SELECT * FROM ORDERS").ToList();
            return orders;
        }

        List<OrderModel>? IOrderService.ReadOwned(UserModel user)
        {
            return _dataContext.Orders.Where(order => order.Customer == user).ToList();
        }

        /// <summary>
        /// Get a single order by ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OrderModel? IOrderService.ReadOne(long Id)
        {
            var Order = _dataContext.Orders.Where(Order => Order.OrderId == Id).FirstOrDefault();

            return Order;
        }

        /// <summary>
        /// Given an order (likely missing ID), return match
        /// </summary>
        /// <param name="Order"></param>
        /// <returns>Order that matches</returns>
        OrderModel? IOrderService.ReadOne(OrderModel Order)
        {
            var MatchingOrder = _dataContext.Orders.Where(_order =>
                _order.Description == Order.Description &&
                _order.Customer == Order.Customer &&
                _order.IsComplete == Order.IsComplete)
                .FirstOrDefault();

            return MatchingOrder;
        }

        /// <summary>
        /// Update order by id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Order"></param>
        OrderModel? IOrderService.Update(long Id, OrderModel Order)
        {
            Order.OrderId = Id;
            _dataContext.Orders.Update(Order);
            _dataContext.SaveChanges();
            return Order;
        }

        /// <summary>
        /// Delete order by id
        /// </summary>
        /// <param name="Id"></param>
        void IOrderService.Delete(long Id)
        {
            var order = _dataContext.Orders.Where(order => order.OrderId == Id).FirstOrDefault();
            _dataContext.Orders.Remove(order);
            _dataContext.SaveChanges();
        }
    }
}
