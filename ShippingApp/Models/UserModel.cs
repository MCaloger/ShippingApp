using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ShippingApp.Models
{
    public class UserModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long? UserId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? ProfileImage { get; set; }
        public Boolean? IsAdmin { get; set; }

        public List<SessionModel> Sessions;
        public List<OrderModel> Orders;
        private ILazyLoader LazyLoader { get; set; }

        protected UserModel()
        {


        }

        public UserModel(string? email, string? password)
        {
            Email = email;
            Password = password;
        }

        public UserModel(string? email, string? password, string? firstName, string? lastName, string? address, string? city, string? region, string? postalCode, string? profileImage, bool isAdmin)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            Region = region;
            PostalCode = postalCode;
            ProfileImage = profileImage;
            IsAdmin = isAdmin;
        }

        public UserModel(long userId, string email, string password, string firstName, string lastName, string address, string city, string region, string postalCode, string profileImage, bool isAdmin)
        {
            UserId = userId;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            Region = region;
            PostalCode = postalCode;
            ProfileImage = profileImage;
            IsAdmin = isAdmin;
        }
    }
}
