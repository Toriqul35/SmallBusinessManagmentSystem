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
   public class SupplierRepository
    {
        SBMSDbContext db = new SBMSDbContext();
        public bool AddSupplier(Supplier supplier)
        {
            int isExecuted = 0;

            db.Suppliers.Add(supplier);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool DeleteSupplier(Supplier supplier)
        {
            int isExecuted = 0;

            Supplier aSupplier = db.Suppliers.FirstOrDefault(c => c.Id == supplier.Id);

            db.Suppliers.Remove(aSupplier);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool UpdateSupplier(Supplier supplier)
        {
            int isExecuted = 0;

            db.Entry(supplier).State = EntityState.Modified;
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public List<Supplier> GetAll()
        {
            return db.Suppliers.ToList();
        }

        public Supplier GetByID(Supplier supplier)
        {
            Supplier aSupplier = db.Suppliers.FirstOrDefault(c => c.Id == supplier.Id);

            return aSupplier;
        }

        public bool IsCodeExist(string code)
        {
            var isExist = db.Suppliers.FirstOrDefault(c => c.Code == code);
            return isExist != null;
        }
    }
}
