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

        public Product getById(int productId)
        {
            return _productDal.Get(p => p.ProductID == productId);
        }

        public List<ProductDetailDto> GetProductDetailDtos()
        {
            return _productDal.GetProductDetailDtos();
        }

        public IDataResult<List<Product>> GettAll()
        {
            // iş kodları
            return new DataResult<List<Product>>(_productDal.GettAll(),true,"ürünler eklendi");
        }

        public List<Product> GettByCategoryId(int id)
        {
            return _productDal.GettAll(p=>p.CategoryID == id);
        }

        public List<Product> GettByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GettAll(p=>p.UnitPrice>=min && p.UnitPrice<=max);
        }

        IDataResult<Product> IProductService.getById(int productId)
        {
            throw new NotImplementedException();
        }

        IDataResult<List<ProductDetailDto>> IProductService.GetProductDetailDtos()
        {
            throw new NotImplementedException();
        }

        IDataResult<List<Product>> IProductService.GettAll()
        {
            return GettAll();
        }

        IDataResult<List<Product>> IProductService.GettByCategoryId(int id)
        {
            throw new NotImplementedException();
        }

        IDataResult<List<Product>> IProductService.GettByUnitPrice(decimal min, decimal max)
        {
            throw new NotImplementedException();
        }
    }
}
