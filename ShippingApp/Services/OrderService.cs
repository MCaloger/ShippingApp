using ShippingApp.Data;
using ShippingApp.Models;

namespace ShippingApp.Services
{
    public class OrderService
    {
        private readonly DataContext _context;

        public OrderService(DataContext context)
        {
            _context = context;
        }

        public long Create(OrderModel Order)
        {
            var OrderToAdd = Order;
            OrderToAdd.IsComplete = false;
            _context.Orders.Add(Order);
            _context.SaveChanges();
            return OrderToAdd.OrderId;
        }

        public OrderModel FindById(long Id)
        {
            var Order = _context.Orders.Where(Order => Order.OrderId == Id).FirstOrDefault();

            if(Order is not null)
            {
                Console.WriteLine(Order.ToString());
            } else
            {
                Console.WriteLine("order is null");
            }
            
            return Order;
        }

        public string Sanity()
        {
            return "Yes it works";
        }

        
    }
}
