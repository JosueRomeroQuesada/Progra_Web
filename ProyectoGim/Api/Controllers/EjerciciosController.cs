using Application.Ejercicios;
using Domain.Ejercicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;


namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EjerciciosController : ControllerBase
    {
        private IEjercicioService _service;

        public EjerciciosController(IEjercicioService service)
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

        [HttpGet("withinstructors")]
        public IActionResult ListWithInstructors()
        {
            var result = _service.List(true);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, null);
        }

        [HttpGet]
        [Route("{idCliente}")]
        public IActionResult Get([FromRoute] string idEjercicio)
        {
            if (string.IsNullOrEmpty(idEjercicio))
            {
                return BadRequest();
            }
            var result = _service.Get(idEjercicio);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return StatusCode(StatusCodes.Status404NotFound, null);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateEjercicio ejercicio)
        {
            var result = _service.Create(ejercicio);

            if (result.IsSuccess)
            {
                //return Created();
                return StatusCode(StatusCodes.Status201Created);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateEjercicio ejercicio)
        {
            var result = _service.Update(ejercicio);
            if (result.IsSuccess)
            {
                return Accepted();
            }

            if (result.Error == EjercicioErrors.NotFound())
            {
                return NotFound();
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete]
        [DisableCors]
        public IActionResult Delete([FromQuery] int idEjercicio)
        {
            var result = _service.Delete(idEjercicio);
            if (result.IsSuccess)
            {
                return Accepted();
            }

            if (result.Error == EjercicioErrors.NotFound())
            {
                return NotFound();
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
