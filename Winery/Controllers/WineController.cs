using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Winery.Dtos;
using Winery.Services;
using System;

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

        [Authorize]
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
                return StatusCode(500, $"Error al obtener los vinos: {ex.Message}");
            }
        }

        [Authorize]
        [HttpGet("name/{name}")]
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

        [Authorize]
        [HttpGet("variety/{variety}")]
        public IActionResult GetWinesByVariety(string variety)
        {
            try
            {
                if (string.IsNullOrEmpty(variety))
                    return BadRequest("La variedad no puede estar vacía.");

                var wines = _wineService.GetWineByVariety(variety);

                if (wines == null)
                    return NotFound($"No se encontraron vinos de la variedad '{variety}'.");

                return Ok(wines);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al buscar vinos por variedad: {ex.Message}");
            }
        }

        [Authorize]
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

        [Authorize]
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
