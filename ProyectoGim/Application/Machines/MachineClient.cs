using Domain.Machines;
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
using Application.Instructors;
using Domain.Instructors;
using Application.Clients;
using Domain.Clients;



namespace Application.Machines
{
    public sealed class MachineClient : IMachineClient
    {
        private readonly List<EndpointConfiguration> _endpoints;
        private readonly HttpClient _machine;
        private readonly IMapper _mapper;

        public MachineClient(IOptions<List<EndpointConfiguration>> options, HttpClient machine, IMapper mapper)
        {
            _endpoints = options.Value.Where
                (w => w.Name.Equals("DefaultApi", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Endpoints.ToList();
            _machine = machine;
            _mapper = mapper;
        }
        public async Task<List<MachineDTO>> List()
        {
            var content = await _machine.GetStringAsync(_endpoints.Where(w => w.Name.Equals("Machines", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri);
            var machines = JsonSerializer.Deserialize<List<Machine>>(content);

            return _mapper.Map<List<MachineDTO>>(machines);
        }

        public async Task<Result> Create(CreateMachine createMachine)
        {
            var content = new StringContent(JsonSerializer.Serialize(createMachine), Encoding.UTF8, "application/json");
            var result = await _machine.PostAsync
                (_endpoints.Where(w => w.Name.Equals("Machines", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri, content);

            return result.StatusCode == System.Net.HttpStatusCode.Created
                ? Result.Success()
                : Result.Failure(InstructorErrors.NotCreated());
        }

        public async Task<Result> Update(UpdateMachine updateMachine)
        {
            var content = new StringContent(JsonSerializer.Serialize(updateMachine), Encoding.UTF8, "application/json");
            var result = await _machine.PutAsync
                (_endpoints.Where(w => w.Name.Equals("Machines", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri, content);

            return result.StatusCode == System.Net.HttpStatusCode.Accepted
                ? Result.Success()
                : Result.Failure(MachineErrors.NotUpdated());
        }

        public async Task<Result<Machine>> Get(string id)
        {
            var content = await _machine.GetStringAsync
                (_endpoints.Where(w => w.Name.Equals("Machines", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri + "/" + id);
            var machine = JsonSerializer.Deserialize<Machine>(content);

            return Result.Success(machine);
        }

        public async Task<Result> Delete(int id)
        {
            var result = await _machine.DeleteAsync
                (_endpoints.Where(w => w.Name.Equals("Machines", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri + "/" + id);

            return result.StatusCode == System.Net.HttpStatusCode.Accepted
               ? Result.Success()
               : Result.Failure(ClientErrors.NotFound());
        }

    }
}
