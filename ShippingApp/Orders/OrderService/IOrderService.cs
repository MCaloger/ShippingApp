using ShippingApp.Models;

namespace ShippingApp.Services
{
    public interface IOrderService
    {
        public OrderModel? Create(OrderModel Order);
        public List<OrderModel>? ReadAll();
        public List<OrderModel>? ReadOwned(UserModel user);
        public OrderModel? ReadOne(long Id);
        public OrderModel? ReadOne(OrderModel Order);
        public OrderModel? Update(long Id, OrderModel Order);
        public void Delete(long Id);
    }
}
