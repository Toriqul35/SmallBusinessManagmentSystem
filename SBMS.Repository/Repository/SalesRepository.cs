using SBMS.DatabaseContext.DatabaseContext;
using SBMS.Models;
using SBMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.Repository.Repository
{
    public class SalesRepository
    {
        SBMSDbContext db = new SBMSDbContext();
        public bool Entry(Sales salesCustomer)
        {
            int isExecuted = 0;

            db.Sales.Add(salesCustomer);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public int GetByPurchaseQuantity(Product product)
        {
            PurchaseViewModel aPurchase = new PurchaseViewModel();
            var purchase = db.PurchaseDetails.Where(c => c.ProductId == product.Id).ToList();
            if (purchase.Count > 0)
            {
                foreach (var pur in purchase)
                {
                    aPurchase.Quantity += pur.Quantity;
                }
            }
            return aPurchase.Quantity;
        }

        public int GetBySalesQuantity(Product product)
        {
            SalesViewModel aSales = new SalesViewModel();
            var sales = db.SalesDetails.Where(c => c.ProductId == product.Id).ToList();
            if (sales.Count > 0)
            {
                foreach (var sal in sales)
                {
                    aSales.Quantity += sal.Quantity;
                }
            }
            return aSales.Quantity;
        }

        public PurchaseDetails GetMRP(Product product)
        {
            PurchaseDetails aProduct = db.PurchaseDetails.FirstOrDefault(c => c.Id == product.Id);

            return aProduct;
        }

    }
}
