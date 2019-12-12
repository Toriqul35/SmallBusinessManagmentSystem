using SBMS.Models.Models;
using SBMS.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.BLL.BLL
{
    public class SalesManager
    {
        SalesRepository _salesRepository = new SalesRepository();

        public bool Entry(Sales sales)
        {
            return _salesRepository.Entry(sales);
        }

        public int GetByPurchaseQuantity(Product product)
        {
            return _salesRepository.GetByPurchaseQuantity(product);
        }

        public int GetBySalesQuantity(Product product)
        {
            return _salesRepository.GetBySalesQuantity(product);
        }

        public PurchaseDetails GetMRP(Product product)
        {
            return _salesRepository.GetMRP(product);
        }
    }
}
