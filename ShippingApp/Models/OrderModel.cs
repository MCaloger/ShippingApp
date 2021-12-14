namespace ShippingApp.Models
{
    public class OrderModel
    {
        public long OrderId { get; set; }
        public UserModel Customer { get; set; }
        public Boolean IsComplete { get; set; }

    }
}