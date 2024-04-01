using Application.Instructors;
using Domain.Instructors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;


namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class InstructorsController : ControllerBase
    {
        private IInstructorService _service;

        public InstructorsController(IInstructorService service)
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

        [HttpGet]
        [Route("{idEntrenador}")]
        public IActionResult Get([FromRoute] string idEntrenador)
        {
            if (string.IsNullOrEmpty(idEntrenador))
            {
                return BadRequest();
            }
            var result = _service.Get(idEntrenador);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return StatusCode(StatusCodes.Status404NotFound, null);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateInstructor instructor)
        {
            var result = _service.Create(instructor);
            
            if (result.IsSuccess)
            {
                //return Created();
                return StatusCode(StatusCodes.Status201Created);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateInstructor instructor)
        {
            var result = _service.Update(instructor);
            if (result.IsSuccess)
            {
                return Accepted();
            }

            if (result.Error == InstructorErrors.NotFound())
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

            if (result.Error == InstructorErrors.NotFound())
            {
                return NotFound();
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
