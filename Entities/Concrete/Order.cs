﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public int OrderID { get; set; }
        public string CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        
    }
}
