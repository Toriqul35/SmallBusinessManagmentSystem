using SBMS.DatabaseContext.DatabaseContext;
using SBMS.Models.Models;
using SBMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.Repository.Repository
{
    public class PurchaseRepository
    {
        SBMSDbContext db = new SBMSDbContext();
        public bool Entry(Purchase purchase)
        {
            int isExecuted = 0;

            db.Purchase.Add(purchase);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public ProductViewModel GetByPrevious(Product product)
        {
            ProductViewModel aProduct = new ProductViewModel();
            var products = db.PurchaseDetails.Where(c => c.ProductId == product.Id).ToList();
            if (products.Count > 0)
            {
                int count = 0;
                int latestList = products.Count;
                foreach (var pro in products)
                {
                    count++;
                    if (latestList == count)
                    {
                        aProduct.ProductId = pro.ProductId;
                        aProduct.PreviousCostPrice = pro.UnitPrice;
                        aProduct.PreviousMRP = pro.MRP;
                    }
                }
            }
            return aProduct;
        }

        public bool IsInvoiceNoExist(string invoiceNo)
        {
            var isExist = db.Purchase.FirstOrDefault(c => c.InvoiceNo == invoiceNo);
            return isExist != null;
        }
    }
}
