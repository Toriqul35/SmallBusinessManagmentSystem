﻿using SBMS.DatabaseContext.DatabaseContext;
using SBMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.Repository.Repository
{
    public class CategoryRepository
    {
        SBMSDbContext db = new SBMSDbContext();

        public bool AddCategory(Category category)
        {
            int isExecuted = 0;

            db.Categories.Add(category);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool DeleteCategory(Category category)
        {
            int isExecuted = 0;

            Category aCategory = db.Categories.FirstOrDefault(c => c.Id == category.Id);

            db.Categories.Remove(aCategory);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool UpdateCategory(Category category)
        {
            int isExecuted = 0;

            db.Entry(category).State = EntityState.Modified;
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public Category GetByID(Category category)
        {
            Category aCategory = db.Categories.FirstOrDefault(c => c.Id == category.Id);

            return aCategory;
        }

        public bool IsCodeExist(string code)
        {
            var isExist = db.Categories.FirstOrDefault(c => c.Code == code);
            return isExist != null;
        }

        public bool IsNameExist(string name)
        {
            var isExist = db.Categories.FirstOrDefault(c => c.Name == name);
            return isExist != null;
        }
    }
}
