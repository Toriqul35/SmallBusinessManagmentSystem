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
   public  class CustomerRepository
    {
        SBMSDbContext db = new SBMSDbContext();
        public bool AddCustomer(Customer customer)
        {
            int isExecuted = 0;

            db.Customers.Add(customer);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool DeleteCustomer(Customer customer)
        {
            int isExecuted = 0;

            Customer aCustomer = db.Customers.FirstOrDefault(c => c.Id == customer.Id);

            db.Customers.Remove(aCustomer);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool UpdateCustomer(Customer customer)
        {
            int isExecuted = 0;

            db.Entry(customer).State = EntityState.Modified;
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public List<Customer> GetAll()
        {
            return db.Customers.ToList();
        }

        public Customer GetByID(Customer customer)
        {
            Customer aCustomer = db.Customers.FirstOrDefault(c => c.Id== customer.Id);

            return aCustomer;
        }

        public bool IsCodeExist(string code)
        {
            var isExist = db.Customers.FirstOrDefault(c => c.Code == code);
            return isExist != null;
        }
    }
}
