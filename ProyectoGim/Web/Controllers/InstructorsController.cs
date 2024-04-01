using Application.Instructors;
using AutoMapper;
using Domain.Instructors;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Web.Extensions;

namespace Web.Controllers
{
    
    public class InstructorsController : Controller
    {
        private readonly IValidator<CreateInstructor> _createValidator;
        private readonly IValidator<UpdateInstructor> _updateValidator;
        private readonly IInstructorInstructor _instructor;
        private readonly IMapper _mapper;

        public InstructorsController
            (
            IValidator<CreateInstructor> createValidator, 
            IValidator<UpdateInstructor> updateValidator,
            IInstructorInstructor instructor,
            IMapper mapper
            ) 
        {
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _instructor = instructor;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var instructors = await _instructor.List();
            return View(instructors);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateInstructor());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateInstructor model)
        {
            var result = await _createValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
            }
            else
            {
                var res = await _instructor.Create(model);
                if (res.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, res.Error.description);
            }
           
            return View(model);
        }


        [HttpGet("/instructors/update/{idEntrenador}")]
        public async Task<IActionResult> Update([FromRoute] string idEntrenador)
        {
            Result<Instructor> result = await _instructor.Get(idEntrenador);
            UpdateInstructor updateInstructor = _mapper.Map<UpdateInstructor>(result.Value);
            return View(updateInstructor);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateInstructor model)
        {
            var result = await _updateValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
            }
            else
            {
                var res = await _instructor.Update(model);
                if (res.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, res.Error.description);
            }

            return View(model);
        }
    }
}
