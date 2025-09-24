using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.concrete.InMemory
{

    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; // _products = new List<Product> ile bellekte bir liste oluşturduk.
        public InMemoryProductDal()
        {
            _products = new List<Product>();
            // Oracle,Sql Server, Postgres, MongoDb den geliyormuş gibi simule ettik.
            new Product
            {
                ProductID = 1,
                CategoryID = 1,
                ProductName = "Bardak",
                UnitPrice = 15,
                UnitsInStock = 15
            };

            new Product
            {
                ProductID = 1,
                CategoryID = 1,
                ProductName = "Bardak",
                UnitPrice = 15,
                UnitsInStock = 15
            };

        }

        public void Add(Product product)
        {
            _products.Add(product);
        }
        public void Delete(Product product)
        {
            // LINQ - Language Integrated Query
            // Lambda
        
            Product ProducttoDelete = _products.SingleOrDefault(p=>p.ProductID==product.ProductID);
            _products.Remove(product);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryID == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetailDtos()
        {
            throw new NotImplementedException();
        }

        public List<Product> GettAll()
        {
           return _products;
        }

        public List<Product> GettAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
         {
            // Gönderdiğim ürün Id sine sahip olan listedeki ürünü bul.
            Product ProducttoUpdate = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            ProducttoUpdate.ProductName = product.ProductName;
            ProducttoUpdate.UnitPrice = product.UnitPrice;
            ProducttoUpdate.UnitsInStock = product.UnitsInStock;

        }

    }
}
