using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            // iş kodları yazılıyor
            // busines codes
            if(product.ProductName.Length < 2) 
            {
                // magic strings
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<Product> getById(int productId)
        {
            return new SuccesDataResult<Product>(_productDal.Get(p => p.ProductID == productId));
        }

        public IDataResult<List<Product>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetailDtos()
        {
            return new SuccesDataResult<List<ProductDetailDto>>(_productDal.GetProductDetailDtos());
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Product>> GettAll()
        {
            if(DateTime.Now.Hour == 11) 
            {
                return new ErorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            // iş kodları
            return new SuccesDataResult<List<Product>>(_productDal.GettAll(),Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GettByCategoryId(int id)
        {
            return new SuccesDataResult<List<Product>>(_productDal.GettAll(p=>p.CategoryID == id));
        }

        public IDataResult<List<Product>> GettByUnitPrice(decimal min, decimal max)
        {
            return new SuccesDataResult<List<Product>>(_productDal.GettAll(p=>p.UnitPrice>=min && p.UnitPrice<=max));
        }

        
    }
}
