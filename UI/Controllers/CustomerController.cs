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
    public class CustomerController : Controller
    {
        ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public ActionResult Index()
        {
            var model = _customerService.GetAll().Data;
            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Customer model)
        {
            _customerService.Add(new Customer
            {
                CustomerId = model.CustomerId,
                CompanyName = model.CompanyName,                 
                City = model.City,                                 
            });

            return RedirectToAction("Index");
        }


    }
}