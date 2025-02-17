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
        public string ProName { get; set; }
        public short ProStock { get; set; }
        public decimal ProPrice { get; set; }
    }
}