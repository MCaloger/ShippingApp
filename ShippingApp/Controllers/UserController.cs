using Microsoft.AspNetCore.Mvc;
using ShippingApp.Models;
using ShippingApp.Services;

namespace ShippingApp.Controllers
{
    public class UserController : Controller
    {
        UserService _userService;
        SessionService _sessionService;

        public UserController(UserService userService, SessionService sessionService)
        {
            this._userService = userService;
            this._sessionService = sessionService;
        }


        /// <summary>
        /// Returns fdefault user page
        /// </summary>
        /// <returns></returns>
        [Route("/User/")]
        [HttpGet]
        public IActionResult Index()
        {
            string? sessionCookie = HttpContext.Request.Cookies["session_token"];
            if (sessionCookie != null) {
                UserModel? user = _sessionService.GetCurrentUserBySessionToken(sessionCookie);
                return View("Index", user);
            } else
            {
                return View("Failure");
            }         
        }

        /// <summary>
        /// Login page
        /// </summary>
        /// <returns>View</returns>
        [Route("User/login")]
        [HttpGet]
        public IActionResult LoginForm()
        {
            return View("Login");
        }

        [Route("User/register")]
        [HttpGet]
        public IActionResult RegisterForm()
        {
            return View("Register");
        }

        [Route("User/registration")]
        [HttpPost]
        public IActionResult Register(UserModel user)
        {
            _userService.InternalCreateUser(user);
            return View("Registration");
        }

        /// <summary>
        /// Generate session
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Route("User/session")]
        [HttpPost]
        public IActionResult RequestSession(UserModel user)
        {
            UserModel? matchingUser = _userService.GetUserByEmail(user.Email);
            if(matchingUser == null) {
                return View("Failure");
            }

            bool attempt = _userService.AttemptLogin(user, matchingUser);

            if(!HttpContext.Request.Cookies.ContainsKey("session_token")) 
            {
                if (attempt)
                {
                    var token = _sessionService.GenerateSessionToken();
                    SessionModel session = new SessionModel(matchingUser, token, true);
                    _sessionService.CreateSession(session);

                    HttpContext.Response.Cookies.Append("session_token", token);
                    return View("Success");
                }
                
            }

            return View("Failure");
        }

        /// <summary>
        /// Log out and invalidate cookie
        /// </summary>
        /// <returns></returns>
        [Route("User/logout")]
        public IActionResult LogOut()
        {
            if (HttpContext.Request.Cookies.ContainsKey("session_token"))
            {
                HttpContext.Response.Cookies.Delete("session_token");
            }

            return View("LogOut");
        }

        /// <summary>
        /// example user creation
        /// </summary>
        /// <returns></returns>
        [Route("User/example")]
        public IActionResult Example()
        {
            _userService.InternalCreateUser(new UserModel("admin", "admin"));
            return View("Success");
        }

    }
}
