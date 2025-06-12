using Microsoft.AspNetCore.Mvc;

namespace LTIA_website.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Promotions() => View();
        public IActionResult Dining() => View();
        public IActionResult Shopping() => View();
        public IActionResult Lounge() => View();
        public IActionResult Relax() => View();
    }
}
