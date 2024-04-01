using Application.Clients;
using AutoMapper;
using Domain.Clients;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Web.Extensions;

namespace Web.Controllers
{
    
    public class ClientsController : Controller
    {
        private readonly IValidator<CreateClient> _createValidator;
        private readonly IValidator<UpdateClient> _updateValidator;
        private readonly IClientClient _client;
        private readonly IMapper _mapper;

        public ClientsController
            (
            IValidator<CreateClient> createValidator, 
            IValidator<UpdateClient> updateValidator,
            IClientClient client,
            IMapper mapper
            ) 
        {
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _client = client;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var clients = await _client.List();
            return View(clients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateClient());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClient model)
        {
            var result = await _createValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
            }
            else
            {
                var res = await _client.Create(model);
                if (res.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, res.Error.description);
            }
           
            return View(model);
        }


        [HttpGet("/clients/update/{idCliente}")]
        public async Task<IActionResult> Update([FromRoute] string idCliente)
        {
            Result<Client> result = await _client.Get(idCliente);
            UpdateClient updateClient = _mapper.Map<UpdateClient>(result.Value);
            return View(updateClient);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateClient model)
        {
            var result = await _updateValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
            }
            else
            {
                var res = await _client.Update(model);
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
