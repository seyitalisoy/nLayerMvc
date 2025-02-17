﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();

        Product GetById(int id);

        void Add(Product entity);

        void Delete(Product entity);

        void Update(Product entity);
        List<ProductDetailDto> GetProductDetails();
    }
}
