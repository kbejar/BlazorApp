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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment _IDepartment;

        public DepartmentController(IDepartment iDepartment)
        {
            _IDepartment = iDepartment;
        }

        [HttpGet]
        public async Task<List<Department>> Get()
        {
            return await Task.FromResult(_IDepartment.GetDepartmentDetails());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Department department = _IDepartment.GetDepartmentData(id);
            if (department != null)
            {
                return Ok(department);
            }
            return NotFound();
        }

        [HttpPost]
        public void Post(Department department)
        {
            _IDepartment.AddDepartment(department);
        }

        [HttpPut]
        public void Put(Department department)
        {
            _IDepartment.UpdateDepartmentDetails(department);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _IDepartment.DeleteDepartment(id);
            return Ok();
        }
    }
}
