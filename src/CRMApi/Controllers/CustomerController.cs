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
    public class CustomerController : Controller
    {
        readonly IBaseApplicationService<Customer> _customerService;
        public CustomerController(IBaseApplicationService<Customer> customerService)
        {
            _customerService = customerService;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _customerService.GetById(id);

            if (customer == null)
                return NotFound();

            await _customerService.Delete(customer);
            return new NoContentResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Customer c)
        {
            if (id == 0 || c == null)
                return BadRequest();

            var customer = await _customerService.GetById(id);

            if (customer == null)
                return NotFound();

            await _customerService.Update(c);

            return new NoContentResult();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Customer customer)
        {
            if (customer == null)
                return BadRequest();

            var op = await _customerService.Insert(customer);

            if (op > 0)
                return CreatedAtRoute("GetCustomer", new { id = customer.Id }, customer);

            return BadRequest();
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            if (id <= 0)
                return BadRequest();

            var customer = await _customerService.GetById(id);

            if (customer == null)
                return NotFound();

            return new ObjectResult(customer);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetAll();

            if (customers == null && !customers.Any())
                return NotFound();

            return new ObjectResult(customers);
        }

        [HttpGet("{GetCustomerFiltered}")]
        public async Task<IActionResult> GetCustomerByPredicate([FromBody] Expression<Func<Customer, bool>> predicate)
        {
            if (predicate == null)
                return BadRequest();

            var customer = await _customerService.GetByPredicate(predicate);

            if (customer == null)
                return NotFound();

            return new ObjectResult(customer);
        }

        [HttpGet("{GetAllCustomersFiltered}")]
        public async Task<IActionResult> GetAllCustomersByPredicate([FromBody] Expression<Func<Customer, bool>> predicate)
        {
            if (predicate == null)
                return BadRequest();

            var customers = await _customerService.GetAllWithPredicate(predicate);

            if (customers == null && !customers.Any())
                return NotFound();

            return new ObjectResult(customers);
        }
    }
}
