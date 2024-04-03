using Application.Weekdays;
using Domain.Weekdays;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class WeekdaysController : ControllerBase
	{
		private IWeekdayService _service;

		public WeekdaysController(IWeekdayService service)
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
		[Route("{idDiaSemana}")]
		public IActionResult Get([FromRoute] string idDiaSemana)
		{
			if (string.IsNullOrEmpty(idDiaSemana))
			{
				return BadRequest();
			}
			var result = _service.Get(idDiaSemana);

			if (result.IsSuccess)
			{
				return Ok(result.Value);
			}

			return StatusCode(StatusCodes.Status404NotFound, null);
		}

		[HttpPost]
		public IActionResult Create([FromBody] CreateWeekday weekday)
		{
			var result = _service.Create(weekday);

			if (result.IsSuccess)
			{
				//return Created();
				return StatusCode(StatusCodes.Status201Created);
			}

			return StatusCode(StatusCodes.Status500InternalServerError);
		}

		[HttpPut]
		public IActionResult Update([FromBody] UpdateWeekday weekday)
		{
			var result = _service.Update(weekday);
			if (result.IsSuccess)
			{
				return Accepted();
			}

			if (result.Error == WeekdayErrors.NotFound())
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

			if (result.Error == WeekdayErrors.NotFound())
			{
				return NotFound();
			}

			return StatusCode(StatusCodes.Status500InternalServerError);
		}
	}
}

