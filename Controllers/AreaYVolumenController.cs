using Microsoft.AspNetCore.Mvc;
using AreaYVolumenApi.Models;
using AreaYVolumenApi.Services;
using AreaYVolumenApi.Data;
using Microsoft.EntityFrameworkCore;

namespace AreaYVolumenApi.Controllers
{
    [ApiController]
    [Route("api/areasyvolumen")]
    public class AreaYVolumenController : ControllerBase
    {
        private readonly AreaYVolumenService _service;
        private readonly MangaDbContext _context;

        public AreaYVolumenController(AreaYVolumenService service, MangaDbContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpGet("cilindro/area")]
        public ActionResult<double> CalcularAreaCilindro([FromQuery] double radio, [FromQuery] double altura)
        {
            var cilindro = new Cilindro { Radio = radio, Altura = altura };
            var area = _service.CalcularAreaCilindro(cilindro);
            return Ok(area);
        }

        [HttpGet("cilindro/volumen")]
        public ActionResult<double> CalcularVolumenCilindro([FromQuery] double radio, [FromQuery] double altura)
        {
            var cilindro = new Cilindro { Radio = radio, Altura = altura };
            var volumen = _service.CalcularVolumenCilindro(cilindro);
            return Ok(volumen);
        }

        [HttpGet("cubo/area")]
        public ActionResult<double> CalcularAreaCubo([FromQuery] double lado)
        {
            var cubo = new Cubo { Lado = lado };
            var area = _service.CalcularAreaCubo(cubo);
            return Ok(area);
        }

        [HttpGet("cubo/volumen")]
        public ActionResult<double> CalcularVolumenCubo([FromQuery] double lado)
        {
            var cubo = new Cubo { Lado = lado };
            var volumen = _service.CalcularVolumenCubo(cubo);
            return Ok(volumen);
        }

        // Endpoint POST para guardar cilindros calculados
        [HttpPost("cilindro/calcular")]
        public async Task<ActionResult> CalcularYGuardarCilindro([FromBody] Cilindro cilindro)
        {
            var area = _service.CalcularAreaCilindro(cilindro);
            var volumen = _service.CalcularVolumenCilindro(cilindro);

            cilindro.Area = area;
            cilindro.Volumen = volumen;

            _context.Cilindros.Add(cilindro);
            await _context.SaveChangesAsync();

            return Ok(cilindro);
        }

        // Endpoint POST para guardar cubos calculados
        [HttpPost("cubo/calcular")]
        public async Task<ActionResult> CalcularYGuardarCubo([FromBody] Cubo cubo)
        {
            var area = _service.CalcularAreaCubo(cubo);
            var volumen = _service.CalcularVolumenCubo(cubo);

            cubo.Area = area;
            cubo.Volumen = volumen;

            _context.Cubos.Add(cubo);
            await _context.SaveChangesAsync();

            return Ok(cubo);
        }

        // Endpoint para obtener cilindros con paginación
        [HttpGet("cilindros")]
        public async Task<ActionResult<List<Cilindro>>> ObtenerCilindros([FromQuery] int page = 1, [FromQuery] int pageSize = 50)
        {
            var cilindros = await _context.Cilindros
                                          .Skip((page - 1) * pageSize)
                                          .Take(pageSize)
                                          .ToListAsync();

            return Ok(cilindros);
        }

        // Endpoint para obtener cubos con paginación
        [HttpGet("cubos")]
        public async Task<ActionResult<List<Cubo>>> ObtenerCubos([FromQuery] int page = 1, [FromQuery] int pageSize = 50)
        {
            var cubos = await _context.Cubos
                                      .Skip((page - 1) * pageSize)
                                      .Take(pageSize)
                                      .ToListAsync();

            return Ok(cubos);
        }
    }
}