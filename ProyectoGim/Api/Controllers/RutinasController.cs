using Application.Rutinas;
using Domain.Rutinas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;


namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RutinasController : ControllerBase
    {
        private IRutinaService _service;

        public RutinasController(IRutinaService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult List()
        {
            var result = _service.List();

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, null);
        }

        [HttpGet("withDiasEjercicios")]
        public IActionResult ListWithDiasEjercicios()
        {
            var result = _service.List(true);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, null);
        }

        [HttpGet]
        [Route("{idRutina}")]
        public IActionResult Get([FromRoute] string idRutina)
        {
            if (string.IsNullOrEmpty(idRutina))
            {
                return BadRequest();
            }
            var result = _service.Get(idRutina);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return StatusCode(StatusCodes.Status404NotFound, null);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateRutina rutina)
        {
            var result = _service.Create(rutina);

            if (result.IsSuccess)
            {
                //return Created();
                return StatusCode(StatusCodes.Status201Created);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateRutina rutina)
        {
            var result = _service.Update(rutina);
            if (result.IsSuccess)
            {
                return Accepted();
            }

            if (result.Error == RutinaErrors.NotFound())
            {
                return NotFound();
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete]
        [DisableCors]
        public IActionResult Delete([FromQuery] int id)
        {
            var result = _service.Delete(id);
            if (result.IsSuccess)
            {
                return Accepted();
            }

            if (result.Error == RutinaErrors.NotFound())
            {
                return NotFound();
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}