namespace ShippingApp.Models
{
    public class UserModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string ProfileImage { get; set; }
        public Boolean IsAdmin { get; set; }
    }
}
