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
            var model = _productService.GetProductDetails();            
            return View(model);
        }
        public ActionResult Add()
        {
            var categories = _categoryService.GetAll();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Add(ProductAddViewModel model)
        {
            _orderService.Add(new Order { OrderDate = DateTime.Now });
            var order = _orderService.GetAll();
            var idNum = order.Count();
            _productService.Add(new Product
            {
                OrderId = idNum,
                CategoryId = model.CategoryId,
                Name = model.ProName,
                Price = model.ProPrice,
                Stock = model.ProStock
            });

            return RedirectToAction("Index");
        }

    }
}