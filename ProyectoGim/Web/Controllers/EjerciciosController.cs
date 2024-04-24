using Application.Ejercicios;
using AutoMapper;
using Domain.Ejercicios;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Web.Extensions;

namespace Web.Controllers
{
    
    public class EjerciciosController : Controller
    {
        private readonly IValidator<CreateEjercicio> _createValidator;
        private readonly IValidator<UpdateEjercicio> _updateValidator;
        private readonly IEjercicioEjercicio _ejercicio;
        private readonly IMapper _mapper;

        public EjerciciosController
            (
            IValidator<CreateEjercicio> createValidator, 
            IValidator<UpdateEjercicio> updateValidator,
            IEjercicioEjercicio ejercicio,
            IMapper mapper
            ) 
        {
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _ejercicio = ejercicio;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var ejercicios = await _ejercicio.List();
            return View(ejercicios);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateEjercicio());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEjercicio model)
        {
            var result = await _createValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
            }
            else
            {
                var res = await _ejercicio.Create(model);
                if (res.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, res.Error.description);
            }
           
            return View(model);
        }


        [HttpGet("/ejercicios/update/{idEjercicio}")]
        public async Task<IActionResult> Update([FromRoute] string idEjercicio)
        {
            Result<Ejercicio> result = await _ejercicio.Get(idEjercicio);
            UpdateEjercicio updateEjercicio = _mapper.Map<UpdateEjercicio>(result.Value);
            return View(updateEjercicio);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateEjercicio model)
        {
            var result = await _updateValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
            }
            else
            {
                var res = await _ejercicio.Update(model);
                if (res.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, res.Error.description);
            }

            return View(model);
        }

        [HttpDelete]
        [Route("/ejercicios/delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _ejercicio.Delete(id);

            if (result.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, result.Error.description);
            return View("Error"); 
        }

    }
}
