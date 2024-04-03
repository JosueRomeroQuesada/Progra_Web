using Domain.Ejercicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text.Json;
using AutoMapper;
using Microsoft.Extensions.Options;
using Domain.Configuration;
using Shared;

namespace Application.Ejercicios

{
    public sealed class EjercicioEjercicio : IEjercicioEjercicio
    {
        private readonly List<EndpointConfiguration> _endpoints;
        private readonly HttpClient _ejercicio;
        private readonly IMapper _mapper;

        public EjercicioEjercicio(IOptions<List<EndpointConfiguration>> options, HttpClient client, IMapper mapper) 
        {
            _endpoints = options.Value.Where
                (w => w.Name.Equals("DefaultApi", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Endpoints.ToList();
            _ejercicio = client;
            _mapper = mapper;
        }
        public async Task<List<EjercicioDTO>> List()
        {
            var content = await _ejercicio.GetStringAsync(_endpoints.Where(w => w.Name.Equals("Ejercicios", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri);
            var ejercicios = JsonSerializer.Deserialize<List<Ejercicio>>(content);

            return _mapper.Map<List<EjercicioDTO>>(ejercicios);
        }

        public async Task<Result> Create(CreateEjercicio createEjercicio)
        {
            var content = new StringContent(JsonSerializer.Serialize(createEjercicio), Encoding.UTF8, "application/json");
            var result = await _ejercicio.PostAsync
                (_endpoints.Where(w => w.Name.Equals("Ejercicios", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri, content);

            return result.StatusCode == System.Net.HttpStatusCode.Created
                ? Result.Success()
                : Result.Failure(EjercicioErrors.NotCreated());
        }

        public async Task<Result> Update(UpdateEjercicio updateEjercicio)
        {
            var content = new StringContent(JsonSerializer.Serialize(updateEjercicio), Encoding.UTF8, "application/json");
            var result = await _ejercicio.PutAsync
                (_endpoints.Where(w => w.Name.Equals("Ejercicios", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri, content);

            return result.StatusCode == System.Net.HttpStatusCode.Accepted
                ? Result.Success()
                : Result.Failure(EjercicioErrors.NotUpdated());
        }

        public async Task<Result<Ejercicio>> Get(string idEjercicio)
        {
            var content = await _ejercicio.GetStringAsync
                (_endpoints.Where(w => w.Name.Equals("Ejercicios", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri + "/" + idEjercicio);
            var ejercicio = JsonSerializer.Deserialize<Ejercicio>(content);

            return Result.Success(ejercicio);
        }
    }
}
