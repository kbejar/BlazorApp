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
    public class PositionController : ControllerBase
    {
        private readonly IPosition _IPosition;

        public PositionController(IPosition iPosition)
        {
            _IPosition = iPosition;
        }

        [HttpGet]
        public async Task<List<Position>> Get()
        {
            return await Task.FromResult(_IPosition.GetPositionDetails());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Position position = _IPosition.GetPositionData(id);
            if (position != null)
            {
                return Ok(position);
            }
            return NotFound();
        }

        [HttpPost]
        public void Post(Position position)
        {
            _IPosition.AddPosition(position);
        }

        [HttpPut]
        public void Put(Position position)
        {
            _IPosition.UpdatePositionDetails(position);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _IPosition.DeletePosition(id);
            return Ok();
        }
    }
}
