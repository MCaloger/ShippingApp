using System.ComponentModel.DataAnnotations;

namespace ShippingApp.Models
{
    public class OrderModel
    {
        [Key]
        public long OrderId { get; set; }
        
        public UserModel? Customer { get; set; }
        public string Description { get; set; }
        public Boolean IsComplete { get; set; }

    }
}