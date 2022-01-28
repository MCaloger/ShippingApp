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

        /// <summary>
        /// Get user by email address
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public UserModel? GetUserByEmail(string email)
        {
            return _context.Users.Where(user => user.Email == email).FirstOrDefault();
        }

        /// <summary>
        /// bcrypt hash password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private string HashPassword(string password) {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        /// <summary>
        /// bcrypt compare passwords
        /// </summary>
        /// <param name="givenPassword"></param>
        /// <param name="hashedPassword"></param>
        /// <returns></returns>
        private bool ComparePasswords(string givenPassword, string hashedPassword) {
            return BCrypt.Net.BCrypt.Verify(givenPassword, hashedPassword);
        }
        
        /// <summary>
        /// create user internally
        /// </summary>
        /// <param name="user"></param>
        public void InternalCreateUser(UserModel user)
        {
            if(GetUserByEmail(user.Email) == null) {
                user.Password = HashPassword(user.Password);
                _context.Users.Add(user);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// check if provided creds are valid
        /// </summary>
        /// <param name="providedCredentials"></param>
        /// <param name="foundCredentials"></param>
        /// <returns></returns>
        public bool AttemptLogin(UserModel providedCredentials, UserModel foundCredentials)
        {
            return ComparePasswords(providedCredentials.Password, foundCredentials.Password);
        }
    }
}
