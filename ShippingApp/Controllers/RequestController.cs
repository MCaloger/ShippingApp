using Microsoft.AspNetCore.Mvc;

namespace ShippingApp.Controllers
{
    public class RequestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
