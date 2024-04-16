using BlazorApp.Server.Interfaces;
using BlazorApp.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Windows.Input;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompany _ICompany;

        public CompanyController(ICompany iCompany)
        {
            _ICompany = iCompany;
        }

        [HttpGet]
        public async Task<List<Company>> Get()
        {
            return await Task.FromResult(_ICompany.GetCompanyDetails());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Company company = _ICompany.GetCompanyData(id);
            if (company != null)
            {
                return Ok(company);
            }
            return NotFound();
        }

        [HttpPost]
        public void Post(Company company)
        {
            _ICompany.AddCompany(company);
        }

        [HttpPut]
        public void Put(Company company)
        {
            _ICompany.UpdateCompanyDetails(company);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _ICompany.DeleteCompany(id);
            return Ok();
        }
    }
}
