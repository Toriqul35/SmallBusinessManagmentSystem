using SBMS.Models;
using SBMS.Models.Models;
using SBMS.Repository.Repository;
using System.Collections.Generic;

namespace SBMS.BLL.BLL
{
    public class ReportingManager
    {
        ReportingRepository _reportingRepository = new ReportingRepository();

        public List<SalesDetails> PeriodictIncomeReport(ProductVM productViewModel)
        {
            return _reportingRepository.PeriodictIncomeReport(productViewModel);
        }

        public List<PurchaseDetails> PeriodictIncomeReportOnPurchase(ProductVM productViewModel)
        {
            return _reportingRepository.PeriodictIncomeReportOnPurchase(productViewModel);
        }
    }
}
