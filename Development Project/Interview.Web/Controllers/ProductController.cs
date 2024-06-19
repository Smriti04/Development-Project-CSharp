using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sparcpoint;
using Sparcpoint.Abstract;
using Sparcpoint.Data.Models;
using Sparcpoint.Models;

namespace Interview.Web.Controllers
{
    [Route("api/v1/products")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public Task<IActionResult> GetAllProducts()
        {
            return Task.FromResult((IActionResult)Ok(new object[] { }));
        }

        //To get the product given the productId
        [HttpGet("getproduct/{productId}")]
        public IActionResult GetProduct(int productId)
        {
            var result = _productService.GetProductById(productId);
            return Ok(result);
        }
        [HttpPost("search")]
        public IActionResult SeacrhProduct([FromBody]SearchCriteria searchcriteria)
        {
            var result = _productService.SeacrhProduct(searchcriteria);
            return Ok(result);
        }
        [HttpPost("add")]
        public IActionResult AddPrdouct([FromBody] Products products)
        {
            var result = _productService.AddPrdouct(products);
            return result !=""? Ok(result) : BadRequest();
        }
    }
}
