using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace LTIA_Website.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password, bool rememberMe)
        {
            if (username == "admin" && password == "123")
            {
                // ✅ Lưu tên đăng nhập vào session
                HttpContext.Session.SetString("username", username);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Sai tên đăng nhập hoặc mật khẩu.";
            return View();
        }

        // ✅ Action đăng xuất
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index", "Home");
        }
    }
}
