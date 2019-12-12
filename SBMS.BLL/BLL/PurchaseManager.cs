using SBMS.Models;
using SBMS.Models.Models;
using SBMS.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.BLL.BLL
{
    public class PurchaseManager
    {
        PurchaseRepository _purchaseRepository = new PurchaseRepository();

        public bool Entry(Purchase purchase)
        {
            return _purchaseRepository.Entry(purchase);
        }

        public ProductViewModel GetByPrevious(Product product)
        {
            return _purchaseRepository.GetByPrevious(product);
        }

        public bool IsInvoiceNoExist(string invoiceNo)
        {
            return _purchaseRepository.IsInvoiceNoExist(invoiceNo);
        }
    }
}
