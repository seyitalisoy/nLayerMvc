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
                             join o in context.Orders on p.OrderId equals o.Id 
                             join c in context.Categories on p.CategoryId equals c.Id 
                             select new ProductDetailDto
                             {
                                 Id = p.Id,
                                 Name = p.Name,
                                 CategoryName = c.Name, 
                                 Stock = p.Stock,
                                 Price = p.Price,
                                 OrderDate = o.OrderDate 
                             };
                return result.ToList();
            }
        }
    }
}
