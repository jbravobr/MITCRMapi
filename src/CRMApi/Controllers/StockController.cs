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
    public class StockController : Controller
    {
        readonly IBaseApplicationService<Stock> _stockService;

        public StockController(IBaseApplicationService<Stock> stockService)
        {
            _stockService = stockService;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var stock = await _stockService.GetById(id);

            if (stock == null)
                return NotFound();

            await _stockService.Delete(stock);

            return new NoContentResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Stock o)
        {
            if (id == 0 || o == null)
                return BadRequest();

            var stock = await _stockService.GetById(id);

            if (stock == null)
                return NotFound();

            await _stockService.Update(o);

            return new NoContentResult();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Stock stock)
        {
            if (stock == null)
                return BadRequest();

            var op = await _stockService.Insert(stock);

            if (op > 0)
                return CreatedAtRoute("GetStock", new { id = stock.Id }, stock);

            return BadRequest();
        }

        [HttpGet("{id}", Name = "GetStock")]
        public async Task<IActionResult> GetstockById(int id)
        {
            if (id <= 0)
                return BadRequest();

            var stock = await _stockService.GetById(id);

            if (stock == null)
                return NotFound();

            return new ObjectResult(stock);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllstocks()
        {
            var stocks = await _stockService.GetAll();

            if (stocks == null && !stocks.Any())
                return NotFound();

            return new ObjectResult(stocks);
        }
    }
}
