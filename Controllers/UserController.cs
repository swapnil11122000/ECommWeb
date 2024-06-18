using ECommWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace ECommWeb.Controllers

{
    public class UserController : Controller
    {
        private readonly IConfiguration configuration;
        UsersDAL db;
        public UserController(IConfiguration configuration)
        {
            this.configuration = configuration;
            db = new UsersDAL(this.configuration);
        }


        public ActionResult Index()
        {
            List<Users> model = db.GetAllUsers();
            return View(model);
        }
        public IActionResult Login()
        {
            ClaimsPrincipal claimsUser = HttpContext.User;
            if (claimsUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index","Home");
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(Users user)
        {

            if (user.Email == "test@gmail.com" &&
                  user.Password == "test123")
            {
                List<Claim> claims = new List<Claim>() {
                     new Claim(ClaimTypes.NameIdentifier,user.Email),
                     new Claim("OtherProperties","Example Role")

                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent=user.KeepLoggedIn
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);
                return RedirectToAction("Index","Home");

            }
            ViewData["ValidateMessage"] = "User not found";
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public ActionResult Login(Users user)
        //{
        //    bool Exists = db.IsUserExists(user);
        //    if (Exists)
        //    {
        //        bool SignedInSuccessfully = db.ValidateCredentials(user);
        //        if (SignedInSuccessfully)
        //        {


        //            return RedirectToAction("Index","Product");
        //        }
        //        else
        //        {
        //            ViewBag.Error = "Invalid credentials";
        //            return View();
        //        }
        //    }
        //    else
        //    {

        //        ViewBag.Error = "User does not exist";
        //        return View();
        //    }
        //}


        public ActionResult SignUp()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(Users user)
        {
            int res = db.AddUser(user);

            return RedirectToAction("Login", "User");
        }

        [Authorize]
        public JsonResult GetDevInfo()
        {
            Dev dev = new Dev();
            var json = JsonConvert.SerializeObject(dev);
            return Json(json);
        }

        //public ActionResult LogOut()
        //{
        //    return Redirect("http://localhost:51430/");
        //}


    }
}
