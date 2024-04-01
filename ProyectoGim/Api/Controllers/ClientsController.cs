using Application.Clients;
using Domain.Clients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;


namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ClientsController : ControllerBase
    {
        private IClientService _service;

        public ClientsController(IClientService service)
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
        [Route("{idCliente}")]
        public IActionResult Get([FromRoute] string idCliente)
        {
            if (string.IsNullOrEmpty(idCliente))
            {
                return BadRequest();
            }
            var result = _service.Get(idCliente);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return StatusCode(StatusCodes.Status404NotFound, null);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateClient client)
        {
            var result = _service.Create(client);
            
            if (result.IsSuccess)
            {
                //return Created();
                return StatusCode(StatusCodes.Status201Created);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateClient client)
        {
            var result = _service.Update(client);
            if (result.IsSuccess)
            {
                return Accepted();
            }

            if (result.Error == ClientErrors.NotFound())
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

            if (result.Error == ClientErrors.NotFound())
            {
                return NotFound();
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
