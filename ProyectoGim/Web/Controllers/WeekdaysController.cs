using Application.Weekdays;
using AutoMapper;
using Domain.Weekdays;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Web.Extensions;

namespace Web.Controllers
{
    
    public class WeekdaysController : Controller
    {
        private readonly IValidator<CreateWeekday> _createValidator;
        private readonly IValidator<UpdateWeekday> _updateValidator;
        private readonly IWeekdayClient _weekday;
        private readonly IMapper _mapper;

        public WeekdaysController
            (
            IValidator<CreateWeekday> createValidator, 
            IValidator<UpdateWeekday> updateValidator,
            IWeekdayClient weekday,
            IMapper mapper
            ) 
        {
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _weekday = weekday;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var weekdays = await _weekday.List();
            return View(weekdays);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateWeekday());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateWeekday model)
        {
            var result = await _createValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
            }
            else
            {
                var res = await _weekday.Create(model);
                if (res.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, res.Error.description);
            }
           
            return View(model);
        }


        [HttpGet("/weekdays/update/{idWeekday}")]
        public async Task<IActionResult> Update([FromRoute] string idWeekday)
        {
            Result<Weekday> result = await _weekday.Get(idWeekday);
            UpdateWeekday updateWeekday = _mapper.Map<UpdateWeekday>(result.Value);
            return View(updateWeekday);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateWeekday model)
        {
            var result = await _updateValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
            }
            else
            {
                var res = await _weekday.Update(model);
                if (res.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, res.Error.description);
            }

            return View(model);
        }

        [HttpDelete]
        [Route("/weeekdays/delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _weekday.Delete(id);

            if (result.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, result.Error.description);
            return View("Error"); 
        }

    }
}
