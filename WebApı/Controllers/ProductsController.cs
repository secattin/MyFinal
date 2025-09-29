using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
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

        [HttpGet("getall")]
        public IActionResult Getall() 
        {
            // Dependency chain--
            
            var result =_productService.GettAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

             
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id) {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);

            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }

    }
}
