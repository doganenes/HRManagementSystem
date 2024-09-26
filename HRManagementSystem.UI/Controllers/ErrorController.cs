using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.UI.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult NotFoundPage()
        {
            return View();
        }

        public IActionResult AccessDeniedPage()
        {
            return View();
        }
    }
}
