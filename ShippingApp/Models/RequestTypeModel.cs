namespace ShippingApp.Models
{
    public class RequestTypeModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long RequestTypeId { get; set; }
        public string RequestTypeName { get; set; }
    }
}