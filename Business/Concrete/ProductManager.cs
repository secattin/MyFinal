using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        
        ICategoryService _categoryservice;

        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            _productDal = productDal;
            
            _categoryservice = categoryService;

        }
        //[ValidationAspect(typeof(ProductValidator))]// attribute gibi davranır validation aspect çalışır


        public IResult Add(Product product)
        {
            
          IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryID),
                CheckIfProductCountOfNamacesCorrect(product.ProductName),CheckIfCategoryLimitExceded());
            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);


        }


        public IResult Update(Product product)
        {
            throw new NotImplementedException();
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
            if (DateTime.Now.Hour == 11)
            {
                return new ErorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            // iş kodları
            return new SuccesDataResult<List<Product>>(_productDal.GettAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GettByCategoryId(int id)
        {
            return new SuccesDataResult<List<Product>>(_productDal.GettAll(p => p.CategoryID == id));
        }

        public IDataResult<List<Product>> GettByUnitPrice(decimal min, decimal max)
        {
            return new SuccesDataResult<List<Product>>(_productDal.GettAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }
        // bir kategoride en fazla 10 ürün olabilir
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryıd)
        {
            var ProductCount = _productDal.GettAll(p => p.CategoryID == categoryıd).Count;
            if (ProductCount >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfEror);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductCountOfNamacesCorrect(string productName)
        {
            var result = _productDal.GettAll(p=>p.ProductName== productName).Count;
            if (result>15)
            {
                return new ErrorResult(Messages.ProductNameError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryservice.GetAll();
            if(result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }

      
    }




   
}
