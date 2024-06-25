using ECommWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ECommWeb.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IConfiguration configuration;
        CartDAL db;
        public CartController(IConfiguration configuration)
        {
            this.configuration = configuration;
            db = new CartDAL(this.configuration);
        }
        public IActionResult CartIndex()
        {
            DataTable dt = db.GetCartForUser((int)HttpContext.Session.GetInt32("UserId"));
            return View(dt);
        }

        public ActionResult Cart()
        {
            int userId = (int)HttpContext.Session.GetInt32("UserId");

            // Retrieve products in the cart for the current user
            DataTable cartItems = db.GetCartForUser(userId);

            return View(cartItems);
        }


    }
}
