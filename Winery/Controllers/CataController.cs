using Microsoft.AspNetCore.Mvc;
using Winery.Dtos;
using Winery.Entities;
using Winery.Services;

namespace Winery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CataController : ControllerBase
    {
        private readonly ICataService _cataService;

        public CataController(ICataService cataService)
        {
            _cataService = cataService;
        }

        [HttpPost]
        public IActionResult CreateCata([FromBody] CreateCataDto cataDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Cata newCata = _cataService.CreateCata(cataDto);
            return CreatedAtAction(nameof(GetCataById), new { id = newCata.Id }, newCata);
        }

        [HttpGet("{id}")]
        public IActionResult GetCataById(int id)
        {
           var cataDto = _cataService.GetCataById(id);
            if (cataDto == null) return NotFound();
            return Ok(cataDto);
        }
    }
}
