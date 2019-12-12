using AutoMapper;
using SBMS.Models;
using SBMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SBMS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ConfigureAutomapper();
        }
        public void ConfigureAutomapper()
        {
            Mapper.Initialize(conf =>
            {
                conf.CreateMap<CategoryViewModel, Category>();
                conf.CreateMap<Category, CategoryViewModel>();

                conf.CreateMap<ProductViewModel, Product>();
                conf.CreateMap<Product, ProductViewModel>();

                conf.CreateMap<CustomerViewModel, Customer>();
                conf.CreateMap<Customer, CustomerViewModel>();

                conf.CreateMap<SupplierViewModel, Supplier>();
                conf.CreateMap<Supplier, SupplierViewModel>();

                conf.CreateMap<ProductViewModel, ProductVM>();
                conf.CreateMap<ProductVM, ProductViewModel>();
            });
        }
    }
}
