using SBMS.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBMS.DatabaseContext.DatabaseContext;
using SBMS.Models.Models;

namespace SBMS.Repository.Repository
{
    public class ReportingRepository
    {
        SBMSDbContext db = new SBMSDbContext();

        public List<SalesDetails> PeriodictIncomeReport(ProductVM productViewModel)
        {
            List<SalesDetails> salesDetails = new List<SalesDetails>();
            var saleProducts = db.Sales.Where(c => c.Date >= productViewModel.StartDate && c.Date <= productViewModel.EndDate).ToList();
            foreach (var product in saleProducts)
            {
                var saleProduct = db.SalesDetails.Include(c => c.Product).Where(c => c.SalesId == product.Id).FirstOrDefault();
                salesDetails.Add(saleProduct);
            }
            return salesDetails;
        }

        public List<PurchaseDetails> PeriodictIncomeReportOnPurchase(ProductVM productViewModel)
        {
            List<PurchaseDetails> purchaseDetails = new List<PurchaseDetails>();
            var purchaseProducts = db.Purchase.Where(c => c.Date >= productViewModel.StartDate && c.Date <= productViewModel.EndDate).ToList();
            foreach (var product in purchaseProducts)
            {
                var purchaseProduct = db.PurchaseDetails.Include(c => c.Product).Where(c => c.PurchaseId == product.ID).FirstOrDefault();
                purchaseDetails.Add(purchaseProduct);
            }
            return purchaseDetails;
        }
    }
}
