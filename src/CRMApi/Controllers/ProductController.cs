using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRMApi.ApplicationService;
using CRMApi.Domain;
using System.Linq.Expressions;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CRMApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        readonly IBaseApplicationService<Product> _productService;

        public ProductController(IBaseApplicationService<Product> productService)
        {
            _productService = productService;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetById(id);

            if (product == null)
                return NotFound();

            await _productService.Delete(product);

            return new NoContentResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Product o)
        {
            if (id == 0 || o == null)
                return BadRequest();

            var product = await _productService.GetById(id);

            if (product == null)
                return NotFound();

            await _productService.Update(o);

            return new NoContentResult();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            if (product == null)
                return BadRequest();

            var op = await _productService.Insert(product);

            if (op > 0)
                return CreatedAtRoute("GetProduct", new { id = product.Id }, product);

            return BadRequest();
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<IActionResult> GetproductById(int id)
        {
            if (id <= 0)
                return BadRequest();

            var product = await _productService.GetById(id);

            if (product == null)
                return NotFound();

            return new ObjectResult(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllproducts()
        {
            var products = await _productService.GetAll();

            if (products == null && !products.Any())
                return NotFound();

            return new ObjectResult(products);
        }
    }
}
