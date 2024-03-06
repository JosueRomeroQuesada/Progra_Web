
using Application.Clients;
using Domain.Clients;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    //ruta del controlador
    [Route("api/[controller]")] 
    [ApiController]

    public class ClientsController : ControllerBase
    {
        //
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
        public IActionResult Create([FromBody] CreateClient client)
        {
            var result = _service.Create(client);
            if (result.IsSuccess)
            {
                return Created();
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
