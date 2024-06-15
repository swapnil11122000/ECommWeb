


using ECommWeb.Entities;
    


namespace ECommWeb.Models
{
    public class ProductDAL
    {
        private readonly ApplicationDbContext db;

        public ProductDAL(ApplicationDbContext db)
        {
            this.db = db;
        }



        // display all
        public List<Product> GetAllProducts()
        {

            return db.Products.ToList();
        }
        // display by id
        public Product GetProductById(int Id)
        {
            var result = db.Products.Where(x => x.Id == Id).FirstOrDefault();
            return result;
        }
        public Product SearchProductByName(string product)
        {
            var result = db.Products.Where(x => x.Name == product).FirstOrDefault();
            return result;
        }


        // add record
        public int AddProduct(Product prod)
        {
            var result = 0;
            db.Products.Add(prod);
            result = db.SaveChanges();
            return result;
        }
        //update record
        public int UpdateProduct(Product prod)
        {
            int result = 0;
            var res = db.Products.Where(x => x.Id == prod.Id).FirstOrDefault();
            if (res != null)
            {
                res.Name = prod.Name;
                res.Category = prod.Category;
                res.Price = prod.Price;
                res.Company = prod.Company;
                res.Country = prod.Country;
                result = db.SaveChanges();
            }
            return result;
        }
        // delete record
        public int DeleteProduct(int Id)
        {
            int res = 0;
            var result = db.Products.Where(x => x.Id == Id).FirstOrDefault();
            if (result != null)
            {
                db.Products.Remove(result);
                res = db.SaveChanges();
            }
            return res;
        }
    }
}
