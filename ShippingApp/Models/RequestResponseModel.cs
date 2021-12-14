namespace ShippingApp.Models
{
    public class RequestResponseModel
    {
        public long RequestResponseId { get; set; }
        public RequestModel Request { get; set; }
        public UserModel Responder { get; set; }
        public Boolean IsPublic { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
