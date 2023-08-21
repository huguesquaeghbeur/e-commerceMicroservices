using Microsoft.AspNetCore.Mvc;

namespace Ordered.API.Controllers
{
    public class OrderedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
