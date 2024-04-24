using Application.Machines;
using AutoMapper;
using Domain.Machines;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Web.Extensions;

namespace Web.Controllers
{
    
    public class MachinesController : Controller
    {
        private readonly IValidator<CreateMachine> _createValidator;
        private readonly IValidator<UpdateMachine> _updateValidator;
        private readonly IMachineClient _machine;
        private readonly IMapper _mapper;

        public MachinesController
            (
            IValidator<CreateMachine> createValidator, 
            IValidator<UpdateMachine> updateValidator,
            IMachineClient machine,
            IMapper mapper
            ) 
        {
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _machine = machine;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var machines = await _machine.List();
            return View(machines);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateMachine());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMachine model)
        {
            var result = await _createValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
            }
            else
            {
                var res = await _machine.Create(model);
                if (res.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, res.Error.description);
            }
           
            return View(model);
        }


        [HttpGet("/machines/update/{id}")]
        public async Task<IActionResult> Update([FromRoute] string id)
        {
            Result<Machine> result = await _machine.Get(id);
            UpdateMachine updateMachine = _mapper.Map<UpdateMachine>(result.Value);
            return View(updateMachine);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateMachine model)
        {
            var result = await _updateValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
            }
            else
            {
                var res = await _machine.Update(model);
                if (res.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, res.Error.description);
            }

            return View(model);
        }

        [HttpDelete]
        [Route("/machines/delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _machine.Delete(id);

            if (result.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, result.Error.description);
            return View("Error"); 
        }

    }
}
