using Application.Instructors;
using Domain.Instructors;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet]
        [Route("{batch}")]
        public IActionResult Get([FromRoute] string batch)
        {
            if (string.IsNullOrEmpty(batch))
            {
                return BadRequest();
            }

            var result = _service.Get(batch);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateInstructor client)
        {
            var result = _service.Create(client);
            if (result.IsSuccess)
            {
                return Created();
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateInstructor client)
        {
            var result = _service.Update(client);
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
