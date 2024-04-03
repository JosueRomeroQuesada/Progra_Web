using Application.Rutinas;
using AutoMapper;
using Domain.Rutinas;
using Domain.Configuration;
using Microsoft.Extensions.Options;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Rutinas
{
    public sealed class RutinaClient : IRutinaClient
    {
        private readonly List<EndpointConfiguration> _endpoints;
        private readonly HttpClient _rutina;
        private readonly IMapper _mapper;

        public RutinaClient(IOptions<List<EndpointConfiguration>> options, HttpClient rutina, IMapper mapper)
        {
            _endpoints = options.Value.Where
                (w => w.Name.Equals("DefaultApi", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Endpoints.ToList();
            _rutina = rutina;
            _mapper = mapper;
        }
        public async Task<List<RutinaDTO>> List()
        {
            var content = await _rutina.GetStringAsync(_endpoints.Where(w => w.Name.Equals("Rutinas", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri);
            var rutinas = JsonSerializer.Deserialize<List<Rutina>>(content);

            return _mapper.Map<List<RutinaDTO>>(rutinas);
        }

        public async Task<Result> Create(CreateRutina createRutina)
        {
            var content = new StringContent(JsonSerializer.Serialize(createRutina), Encoding.UTF8, "application/json");
            var result = await _rutina.PostAsync
                (_endpoints.Where(w => w.Name.Equals("Rutinas", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri, content);

            return result.StatusCode == System.Net.HttpStatusCode.Created
                ? Result.Success()
                : Result.Failure(RutinaErrors.NotCreated());
        }

        public async Task<Result> Update(UpdateRutina updateRutina)
        {
            var content = new StringContent(JsonSerializer.Serialize(updateRutina), Encoding.UTF8, "application/json");
            var result = await _rutina.PutAsync
                (_endpoints.Where(w => w.Name.Equals("Rutinas", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri, content);

            return result.StatusCode == System.Net.HttpStatusCode.Accepted
                ? Result.Success()
                : Result.Failure(RutinaErrors.NotUpdated());
        }

        public async Task<Result<Rutina>> Get(string idRutina)
        {
            var content = await _rutina.GetStringAsync
                (_endpoints.Where(w => w.Name.Equals("Rutinas", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri + "/" + idRutina;
            var client = JsonSerializer.Deserialize<Rutina>(content);

            return Result.Success(client);
        }
    }
}
