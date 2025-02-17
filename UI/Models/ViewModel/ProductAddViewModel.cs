using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Concrete;

namespace UI.Models.ViewModel
{
    public class ProductAddViewModel
    {        
        public int CategoryId { get; set; }
        //public int OrderId { get; set; }
        //public DateTime OrderDate { get; set; }
        public string ProName { get; set; }
        public int ProStock { get; set; }
        public decimal ProPrice { get; set; }
    }
}