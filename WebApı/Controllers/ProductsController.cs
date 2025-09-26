using Business.Abstract;
using Business.Concrete;
using DataAccess.concrete.EntityFramawork;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // attrıbute
    public class ProductsController : ControllerBase
    {
        // loosely coupled
        IProductService _productService;
        
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> Get() 
        {
            // Dependency chain--
            
            var result =_productService.GettAll();
            return result.Data;
             
        }

    }
}
