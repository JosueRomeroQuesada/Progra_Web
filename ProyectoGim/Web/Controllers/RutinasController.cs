using Application.Rutinas;
using AutoMapper;
using Domain.Rutinas;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Web.Extensions;

namespace Web.Controllers
{
    
    public class RutinasController : Controller
    {
        private readonly IValidator<CreateRutina> _createValidator;
        private readonly IValidator<UpdateRutina> _updateValidator;
        private readonly IRutinaClient _rutina;
        private readonly IMapper _mapper;

        public RutinasController
            (
            IValidator<CreateRutina> createValidator, 
            IValidator<UpdateRutina> updateValidator,
            IRutinaClient rutina,
            IMapper mapper
            ) 
        {
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _rutina = rutina;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var rutinas = await _rutina.List();
            return View(rutinas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateRutina());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRutina model)
        {
            var result = await _createValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
            }
            else
            {
                var res = await _rutina.Create(model);
                if (res.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, res.Error.description);
            }
           
            return View(model);
        }


        [HttpGet("/rutinas/update/{idRutina}")]
        public async Task<IActionResult> Update([FromRoute] string idRutina)
        {
            Result<Rutina> result = await _rutina.Get(idRutina);
            UpdateRutina updateRutina = _mapper.Map<UpdateRutina>(result.Value);
            return View(updateRutina);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateRutina model)
        {
            var result = await _updateValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
            }
            else
            {
                var res = await _rutina.Update(model);
                if (res.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, res.Error.description);
            }

            return View(model);
        }

        [HttpDelete]
        [Route("/rutinas/delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _rutina.Delete(id);

            if (result.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, result.Error.description);
            return View("Error"); 
        }


    }
}
