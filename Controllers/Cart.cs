using Microsoft.AspNetCore.Mvc;

namespace ECommWeb.Controllers
{
    public class Cart : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
