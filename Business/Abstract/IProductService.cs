﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();

        IDataResult<Product> GetById(int id);

        IResult Add(Product entity);

        IResult Delete(Product entity);

        IResult Update(Product entity);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
    }
}
