using ECommWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommWeb.Entities;
using Microsoft.AspNetCore.Authorization;

namespace ECommWeb.Controllers

{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;
         ProductDAL db;
        public ProductController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
            db= new ProductDAL(applicationDbContext);
        }
       
       
        // GET: ProductController
        //display all products
        public ActionResult Index()
        {
            List<Product> model = db.GetAllProducts();
            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        public ActionResult Supplier()
        {
            List<Product> model = db.GetAllProducts();
            return View(model);
        }

      
        public IActionResult Search(string product)
        {
            var model=db.SearchProductByName(product);
            return View(model);
        }
        // GET: ProductController/Details/5
        //display single product
        public ActionResult Details(int Id)
        {
            var model = db.GetProductById(Id);
            return View(model);
        }

        // GET: ProductController/Create
        //add new product
     
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product prod)
        {
            try
            {
                int res = db.AddProduct(prod);
                if (res > 0)
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                {

                    ViewBag.Error = "Something Went Wrong";
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int Id)
        {
            var model = db.GetProductById(Id);
            return View(model);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product prod)
        {
            try
            {
                int res = db.UpdateProduct(prod);
                if (res > 0)
                {
                    return RedirectToAction(nameof(Supplier));

                }
                else
                {

                    ViewBag.Error = "Something Went Wrong";
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int Id)
        {
            var model = db.GetProductById(Id);
            return View(model);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int Id)
        {
            try
            {
                int res = db.DeleteProduct(Id);
                if (res > 0)
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                {

                    ViewBag.Error = "Something Went Wrong";
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
