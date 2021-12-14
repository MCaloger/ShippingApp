using Microsoft.AspNetCore.Mvc;

namespace ShippingApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
