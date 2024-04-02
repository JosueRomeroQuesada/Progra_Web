using Application.Machines;
using Domain.Machines;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;


namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class MachinesController : ControllerBase
    {
        private IMachineService _service;

        public MachinesController(IMachineService service)
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
        [Route("{idMachine}")]
        public IActionResult Get([FromRoute] string idMachine)
        {
            if (string.IsNullOrEmpty(idMachine))
            {
                return BadRequest();
            }
            var result = _service.Get(idMachine);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return StatusCode(StatusCodes.Status404NotFound, null);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateMachine machine)
        {
            var result = _service.Create(machine);
            
            if (result.IsSuccess)
            {
                //return Created();
                return StatusCode(StatusCodes.Status201Created);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateMachine machine)
        {
            var result = _service.Update(machine);
            if (result.IsSuccess)
            {
                return Accepted();
            }

            if (result.Error == MachineErrors.NotFound())
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

            if (result.Error == MachineErrors.NotFound())
            {
                return NotFound();
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
