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
    public class SalesController : Controller
    {
       
        
            SalesManager _salesManager = new SalesManager();
            private Sales _salesCustomer = new Sales();
            CustomerManager _customerManager = new CustomerManager();
            ProductManager _productManager = new ProductManager();

            // GET: Sales
            [HttpGet]
            public ActionResult Entry()
            {
                
                    SalesViewModel salesViewModel = new SalesViewModel();
                    salesViewModel.CustomerSelectListItems = _customerManager.GetAll().Select(c => new SelectListItem()
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    });

                    salesViewModel.ProductSelectListItems = _productManager.GetAll().Select(c => new SelectListItem()
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    });

                    return View(salesViewModel);
                
            }

            [HttpPost]
            public ActionResult Entry(SalesViewModel salesViewModel)
            {
                if (ModelState.IsValid)
                {
                    _salesCustomer.CustomerId = salesViewModel.CustomerId;
                    _salesCustomer.Date = salesViewModel.Date;
                    _salesCustomer.LoyaltyPoint = salesViewModel.LoyaltyPoint;
                    _salesCustomer.PayableAmounth = salesViewModel.PayableAmounth;
                    _salesCustomer.SalesDetails = salesViewModel.SalesDetails;

                    Customer customer = new Customer();
                    customer.Id = salesViewModel.CustomerId;
                    customer.LoyaltyPoint = Convert.ToInt32(salesViewModel.LoyaltyPoint);

                    //if (_salesManager.Entry(_salesCustomer) && _customerManager.UpdateCustomer(customer))
                    if (_salesManager.Entry(_salesCustomer))
                    {
                        ViewBag.Message = "Saved";

                        salesViewModel.CustomerSelectListItems = _customerManager.GetAll().Select(c => new SelectListItem()
                        {
                            Value = c.Id.ToString(),
                            Text = c.Name
                        });

                        salesViewModel.ProductSelectListItems = _productManager.GetAll().Select(c => new SelectListItem()
                        {
                            Value = c.Id.ToString(),
                            Text = c.Name
                        });

                        return View(salesViewModel);
                    }
                }

                return View(salesViewModel);
            }

            public JsonResult GetLoyaltyPoint(int customerId)
            {
                Customer customer = new Customer();
                customer.Id = customerId;
                var aCustomer = _customerManager.GetByID(customer);
                customer.LoyaltyPoint = aCustomer.LoyaltyPoint;

                return Json(customer, JsonRequestBehavior.AllowGet);
            }

        public JsonResult GetAvailableQuantity(int productId)
        {
            PurchaseViewModel purchaseModel = new PurchaseViewModel();
            SalesViewModel salesModel = new SalesViewModel();
            Product product = new Product();
            product.Id = productId;
            purchaseModel.Quantity = Convert.ToInt32(_salesManager.GetByPurchaseQuantity(product));
            salesModel.Quantity = Convert.ToInt32(_salesManager.GetBySalesQuantity(product));

            salesModel.AvailableQuantity = purchaseModel.Quantity - salesModel.Quantity;

            return Json(salesModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMRP(int productId)
            {
                Product product = new Product();
                product.Id = productId;
                var aProduct = _salesManager.GetMRP(product);
                var MRP = aProduct.MRP;

                return Json(MRP, JsonRequestBehavior.AllowGet);
            }
        
    }
}