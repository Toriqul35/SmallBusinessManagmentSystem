using SBMS.DatabaseContext.DatabaseContext;
using SBMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.Repository.Repository
{
    public class ProductRepository
    {
        SBMSDbContext db = new SBMSDbContext();
        public bool AddProduct(Product product)
        {
            int isExecuted = 0;

            db.Products.Add(product);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool DeleteProduct(Product product)
        {
            int isExecuted = 0;

            Product aProduct = db.Products.FirstOrDefault(c => c.Id == product.Id);

            db.Products.Remove(aProduct);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool UpdateProduct(Product product)
        {
            int isExecuted = 0;

            db.Entry(product).State = EntityState.Modified;
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public List<Product> GetAll()
        {
            return db.Products.Include(p => p.Category).ToList();
        }

        public Product GetByID(Product product)
        {
            Product aProduct = db.Products.FirstOrDefault(c => c.Id == product.Id);

            return aProduct;
        }

        public bool IsCodeExist(string code)
        {
            var isExist = db.Products.FirstOrDefault(c => c.Code == code);
            return isExist != null;
        }

        public bool IsNameExist(string name)
        {
            var isExist = db.Products.FirstOrDefault(c => c.Name == name);
            return isExist != null;
        }
    }
}
