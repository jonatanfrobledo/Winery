using Microsoft.AspNetCore.Mvc;
using Winery.Dtos;
using Winery.Services;

namespace Winery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WineController : ControllerBase
    {
        private readonly IWineService _wineService;

        public WineController(IWineService wineService)
        {
            _wineService = wineService;
        }

        [HttpGet]
        public IActionResult GetWines()
        {
            try
            {
                var wines = _wineService.GetAllWines();
                return Ok(wines);
            }
            catch (Exception ex)
            {
                // Log exception (puedes implementar un servicio de logging)
                return StatusCode(500, $"Error al obtener los vinos: {ex.Message}");
            }
        }

        [HttpGet("{name}")]
        public IActionResult GetWineByName(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                    return BadRequest("El nombre no puede estar vacío.");

                var wine = _wineService.GetWineByName(name);

                if (wine == null)
                    return NotFound($"No se encontró el vino con el nombre '{name}'.");

                return Ok(wine);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al buscar el vino: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult RegisterWine([FromBody] WineDto wineDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _wineService.RegisterWine(wineDto);
                return Ok("Vino registrado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al registrar el vino: {ex.Message}");
            }
        }

        [HttpPut("addstock/{name}")]
        public IActionResult AddStock(string name, [FromBody] int quantity)
        {
            try
            {
                if (quantity < 0)
                    return BadRequest("La cantidad debe ser positiva.");

                _wineService.AddStock(name, quantity);
                return Ok($"Se ha agregado {quantity} unidades al stock del vino '{name}'.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el stock: {ex.Message}");
            }
        }
    }
}
