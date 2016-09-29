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
    public class OrderController : Controller
    {
        readonly IBaseApplicationService<Order> _orderService;

        public OrderController(IBaseApplicationService<Order> orderService)
        {
            _orderService = orderService;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _orderService.GetById(id);

            if (order == null)
                return NotFound();

            await _orderService.Delete(order);

            return new NoContentResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Order o)
        {
            if (id == 0 || o == null)
                return BadRequest();

            var order = await _orderService.GetById(id);

            if (order == null)
                return NotFound();

            await _orderService.Update(o);

            return new NoContentResult();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Order order)
        {
            if (order == null)
                return BadRequest();

            var op = await _orderService.Insert(order);

            if (op > 0)
                return CreatedAtRoute("GetOrder", new { id = order.Id }, order);

            return BadRequest();
        }

        [HttpGet("{id}", Name = "GetOrder")]
        public async Task<IActionResult> GetorderById(int id)
        {
            if (id <= 0)
                return BadRequest();

            var order = await _orderService.GetById(id);

            if (order == null)
                return NotFound();

            return new ObjectResult(order);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllorders()
        {
            var orders = await _orderService.GetAll();

            if (orders == null && !orders.Any())
                return NotFound();

            return new ObjectResult(orders);
        }
    }
}
