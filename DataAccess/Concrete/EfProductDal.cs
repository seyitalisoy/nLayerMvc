using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete
{
    public class EfProductDal : EfEntityRepositoryBase<Product,Context>,IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (Context context = new Context())
            {
                var result = from p in context.Products                             
                             join c in context.Categories on p.CategoryId equals c.CategoryId 
                             select new ProductDetailDto
                             {
                                 Id = p.ProductId,
                                 Name = p.ProductName,
                                 CategoryName = c.CategoryName, 
                                 Stock = p.UnitsInStock,
                                 Price = p.UnitPrice,                                 
                             };
                return result.ToList();
            }
        }
    }
}
