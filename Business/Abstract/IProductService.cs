using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    
    public interface IProductService
    {
        IDataResult<List<Product>> GettAll();
        IDataResult<List<Product>> GettByCategoryId(int id);
        IDataResult<List<Product>> GettByUnitPrice(decimal min,decimal max);

        IDataResult<List<ProductDetailDto>> GetProductDetailDtos();

        //IDataResult<Product>
          //  getById(int productId);


        IResult Add(Product product);
       
    }
}
