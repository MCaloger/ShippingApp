namespace ShippingApp.Models
{
    public class RequestModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long RequestId { get; set; }
        public RequestTypeModel RequestType { get; set; }
        public string details { get; set; }
        public UserModel Requestor { get; set; }
        public StatusModel Status { get; set; }
        public OrderModel Order { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
