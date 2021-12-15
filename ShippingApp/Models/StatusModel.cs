namespace ShippingApp.Models
{
    public class StatusModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long StatusId { get; set; }
        public string StatusName { get; set; }
    }
}