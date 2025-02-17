using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Abstract;
using Entities.Concrete;
using UI.Models.ViewModel;

namespace UI.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        IOrderService _orderService;
        ICategoryService _categoryService;

        public ProductController(IProductService productService, IOrderService orderService, ICategoryService categoryService)
        {
            _productService = productService;
            _orderService = orderService;
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var model = _productService.GetProductDetails().Data;            
            return View(model);
        }
        public ActionResult Add()
        {
            var categories = _categoryService.GetAll().Data;
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public ActionResult Add(ProductAddViewModel model)
        {
            _productService.Add(new Product
            {
                CategoryId = model.CategoryId,
                ProductName = model.ProName,
                UnitPrice = model.ProPrice,
                UnitsInStock = model.ProStock
            });
            // logicler gelicek , success result, error result

            return RedirectToAction("Index");
        }

    }
}