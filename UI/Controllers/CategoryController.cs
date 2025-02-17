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
            var result = _categoryService.GetAll();
            return View(result);
        }

        [HttpPost]
        public ActionResult Add(Category category)
        {
           var model = new Category { Name = category.Name, Desciption = category.Desciption };
           _categoryService.Add(model);
            return RedirectToAction("Index");
        }
    }
}