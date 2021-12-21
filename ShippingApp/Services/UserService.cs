using ShippingApp.Data;
using ShippingApp.Models;

namespace ShippingApp.Services
{
    public class UserService
    {
        /// <summary>
        /// Injcted database context
        /// </summary>
        private readonly DataContext _context;

        /// <summary>
        /// database context injection
        /// </summary>
        /// <param name="context"></param>
        public UserService(DataContext context)
        {
            _context = context;
        }

        public UserModel? GetUserByEmail(string email)
        {
            return _context.Users.Where(user => user.Email == email).FirstOrDefault();
        }

        private string HashPassword(string password) {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool ComparePasswords(string givenPassword, string hashedPassword) {
            return BCrypt.Net.BCrypt.Verify(givenPassword, hashedPassword);
        }

        public void InternalCreateUser(UserModel user)
        {
            if(GetUserByEmail(user.Email) == null) {
                user.Password = HashPassword(user.Password);
                _context.Users.Add(user);
                _context.SaveChanges();
            }
        }

        public bool AttemptLogin(UserModel providedCredentials, UserModel foundCredentials)
        {
            return ComparePasswords(providedCredentials.Password, foundCredentials.Password);
        }
    }
}
