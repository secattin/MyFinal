using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.concrete.EntityFramawork
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindeContex>, IProductDal
    {
     
        public List<ProductDetailDto> GetProductDetailDtos()
        {
            using (NorthwindeContex context = new NorthwindeContex() )
            {
                var result = from p in context.products
                             join c in context.categories
                             on p.CategoryID equals c.CategoryID
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductID,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitsInStock = p.UnitsInStock,
                             };
                return result.ToList();

            }
        }
    }
}
