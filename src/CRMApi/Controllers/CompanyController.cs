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
    public class CompanyController : Controller
    {
        readonly IBaseApplicationService<Company> _companyService;

        public CompanyController(IBaseApplicationService<Company> companyService)
        {
            _companyService = companyService;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var company = await _companyService.GetById(id);

            if (company == null)
                return NotFound();

            await _companyService.Delete(company);

            return new NoContentResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Company c)
        {
            if (id == 0 || c == null)
                return BadRequest();

            var company = await _companyService.GetById(id);

            if (company == null)
                return NotFound();

            await _companyService.Update(c);

            return new NoContentResult();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Company company)
        {
            if (company == null)
                return BadRequest();

            var op = await _companyService.Insert(company);

            if (op > 0)
                return CreatedAtRoute("GetCompany", new { id = company.Id }, company);

            return BadRequest();
        }

        [HttpGet("{id}", Name = "GetCompany")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            if (id <= 0)
                return BadRequest();

            var company = await _companyService.GetById(id);

            if (company == null)
                return NotFound();

            return new ObjectResult(company);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompanys()
        {
            var companys = await _companyService.GetAll();

            if (companys == null && !companys.Any())
                return NotFound();

            return new ObjectResult(companys);
        }
    }
}
