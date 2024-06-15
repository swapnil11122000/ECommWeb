using ECommWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace webapp3.Controllers

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
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(Users user)
        {
            return RedirectToAction("Index", "Product");
        }
       
        
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
            

            /*  try
            {
                int res = db.AddUser(user);
                *//*if (res > 0)
                {
                    return RedirectToAction(nameof(ProductController.Index));

                }
                else
                {

                    ViewBag.Error = "Something Went Wrong";
                    return View();
                }*//*
            }
            catch
            {
                return View();
            }*/
        }

       
        public JsonResult GetDevInfo()
        {
            Dev dev = new Dev();
            var json=JsonConvert.SerializeObject(dev);
            return Json(json);
        }
       

            
        
    }
}
