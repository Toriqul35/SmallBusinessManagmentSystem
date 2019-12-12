using SBMS.BLL.BLL;
using SBMS.Models;
using SBMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBMS.Controllers
{
    public class PurchaseController : Controller
    {
        PurchaseManager _purchaseManager = new PurchaseManager();
        private Purchase _purchase = new Purchase();
        SupplierManager _supplierManager = new SupplierManager();
        ProductManager _productManager = new ProductManager();

        // GET: Purchase
        [HttpGet]
        public ActionResult Entry()
        {
            
                PurchaseViewModel purchaseViewModel = new PurchaseViewModel();
                purchaseViewModel.SupplierSelectListItems = _supplierManager.GetAll().Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });

                purchaseViewModel.ProductSelectListItems = _productManager.GetAll().Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });

                return View(purchaseViewModel);
            
        }

        [HttpPost]
        public ActionResult Entry(PurchaseViewModel purchaseViewModel)
        {
            if (ModelState.IsValid)
            {
                // InvoiceNo is already Exist
                var isInvoiceNoExist = _purchaseManager.IsInvoiceNoExist(purchaseViewModel.InvoiceNo);
                if (isInvoiceNoExist)
                {
                    purchaseViewModel.SupplierSelectListItems = _supplierManager.GetAll().Select(c => new SelectListItem()
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    });

                    purchaseViewModel.ProductSelectListItems = _productManager.GetAll().Select(c => new SelectListItem()
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    });

                    ModelState.AddModelError("InvoiceNoExist", "Invoice No already exist");
                    return this.View("Entry", purchaseViewModel);
                }

                _purchase.InvoiceNo = purchaseViewModel.InvoiceNo;
                _purchase.Date = purchaseViewModel.Date;
                _purchase.SupplierId = purchaseViewModel.SupplierId;
                _purchase.PurchaseDetails = purchaseViewModel.PurchaseDetails;
                if (_purchaseManager.Entry(_purchase))
                {
                    ViewBag.Message = "Saved";

                    purchaseViewModel.SupplierSelectListItems = _supplierManager.GetAll().Select(c => new SelectListItem()
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    });

                    purchaseViewModel.ProductSelectListItems = _productManager.GetAll().Select(c => new SelectListItem()
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    });

                    return View(purchaseViewModel);
                }
            }
            return View(purchaseViewModel);
        }

        public JsonResult GetProductHistory(int productId)
        {
            ProductViewModel model = new ProductViewModel();
            Product product = new Product();
            product.Id = productId;
            var aProduct = _productManager.GetByID(product);
            string productCode = aProduct.Code;

            model = _purchaseManager.GetByPrevious(product);
            model.Code = productCode;
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}