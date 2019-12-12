using AutoMapper;
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
    public class CategoryController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager();
        private Category _category = new Category();
        private CategoryViewModel _categoryViewModel = new CategoryViewModel();

        // GET: Category
        [HttpGet]
        public ActionResult Add()
        {
            
            return View();
            
        }

        [HttpPost]
        public ActionResult Add(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                // Code is already Exist
                var isCodeExist = _categoryManager.IsCodeExist(categoryViewModel.Code);
                if (isCodeExist)
                {
                    ModelState.AddModelError("CodeExist", "Code already exist");
                    return this.View("Add");
                }

                // Name is already Exist
                var isNameExist = _categoryManager.IsNameExist(categoryViewModel.Name);
                if (isNameExist)
                {
                    ModelState.AddModelError("NameExist", "Name already exist");
                    return this.View("Add");
                }

                Category category = new Category();
                category = Mapper.Map<Category>(categoryViewModel);

                if (_categoryManager.AddCategory(category))
                {
                    ViewBag.Message = "Saved";
                    return RedirectToAction("Show", "Category");
                }
                else
                {
                    ViewBag.Message = "Failed";
                }
            }
            else
            {
                ViewBag.Message = "Validation Error";
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            
                _category.Id = id;
                var category = _categoryManager.GetByID(_category);
                _categoryViewModel = Mapper.Map<CategoryViewModel>(category);

                return View(_categoryViewModel);
            
        }

        [HttpPost]
        public ActionResult Edit(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                // Code is already Exist
                var isCodeExist = _categoryManager.IsCodeExist(categoryViewModel.Code);
                if (isCodeExist)
                {
                    ModelState.AddModelError("CodeExist", "Code already exist");
                    return this.View("Edit");
                }

                // Name is already Exist
                var isNameExist = _categoryManager.IsNameExist(categoryViewModel.Name);
                if (isNameExist)
                {
                    ModelState.AddModelError("NameExist", "Name already exist");
                    return this.View("Edit");
                }

                Category category = new Category();
                category = Mapper.Map<Category>(categoryViewModel);

                if (_categoryManager.UpdateCategory(category))
                {
                    ViewBag.Message = "Updated";
                    return RedirectToAction("Show", "Category");
                }
                else
                {
                    ViewBag.Message = "Failed";
                }
            }
            else
            {
                ViewBag.Message = "Validation Error";
            }

            return View(categoryViewModel);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _category.Id = id;

                if (_categoryManager.DeleteCategory(_category))
                {
                    ViewBag.AlertMsg = "Delete Successfully";
                }
                return RedirectToAction("Show");
            }
            catch
            {
                return RedirectToAction("Show"); ;
            }
        }

        [HttpGet]
        public ActionResult Show()
        {
            
                _categoryViewModel.Categories = _categoryManager.GetAll();

                return View(_categoryViewModel);
            
        }

        [HttpPost]
        public ActionResult Show(CategoryViewModel categoryViewModel)
        {
            var categories = _categoryManager.GetAll();

            if (categoryViewModel.Name != null)
            {
                Category category = new Category();
                category = Mapper.Map<Category>(categoryViewModel);

                categories = categories.Where(c => c.Name.ToLower().Contains(category.Name.ToLower())).ToList();
            }

            categoryViewModel.Categories = categories;
            return View(categoryViewModel);
        }
    }
}