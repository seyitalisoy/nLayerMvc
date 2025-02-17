using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Concrete;

namespace UI.Models.ViewModel
{
    public class ProductListModel
    {
        public int Id { get; set; }
        public int CategoryName { get; set; }
        public DateTime OrderDate { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}