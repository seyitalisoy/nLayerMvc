using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace UI.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var result = _categoryService.GetAll().Data;
            return View(result);
        }

        [HttpPost]
        public ActionResult Add(Category category)
        {
            var model = new Category { CategoryName = category.CategoryName, Description = category.Description };
            var result = _categoryService.Add(model);
            if (!result.Success)
            {                
                ViewBag.ErrorMessage = result.Message;                
                return View("Index", _categoryService.GetAll().Data);  
            }
            ViewBag.SuccessMessage = result.Message;
            return View("Index", _categoryService.GetAll().Data);
        }
    }
}