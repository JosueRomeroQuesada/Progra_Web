using Domain.Clients;
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

namespace Application.Clients
{
    public sealed class ClientClient : IClientClient
    {
        private readonly List<EndpointConfiguration> _endpoints;
        private readonly HttpClient _client;
        private readonly IMapper _mapper;

        public ClientClient(IOptions<List<EndpointConfiguration>> options, HttpClient client, IMapper mapper) 
        {
            _endpoints = options.Value.Where
                (w => w.Name.Equals("DefaultApi", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Endpoints.ToList();
            _client = client;
            _mapper = mapper;
        }
        public async Task<List<ClientDTO>> List()
        {
            var content = await _client.GetStringAsync(_endpoints.Where(w => w.Name.Equals("Clients", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri);
            var clients = JsonSerializer.Deserialize<List<Client>>(content);

            return _mapper.Map<List<ClientDTO>>(clients);
        }

        public async Task<Result> Create(CreateClient createClient)
        {
            var content = new StringContent(JsonSerializer.Serialize(createClient), Encoding.UTF8, "application/json");
            var result = await _client.PostAsync
                (_endpoints.Where(w => w.Name.Equals("Clients", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri, content);

            return result.StatusCode == System.Net.HttpStatusCode.Created
                ? Result.Success()
                : Result.Failure(ClientErrors.NotCreated());
        }

        public async Task<Result> Update(UpdateClient updateClient)
        {
            var content = new StringContent(JsonSerializer.Serialize(updateClient), Encoding.UTF8, "application/json");
            var result = await _client.PutAsync
                (_endpoints.Where(w => w.Name.Equals("Clients", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri, content);

            return result.StatusCode == System.Net.HttpStatusCode.Accepted
                ? Result.Success()
                : Result.Failure(ClientErrors.NotUpdated());
        }

        public async Task<Result<Client>> Get(string idCliente)
        {
            var content = await _client.GetStringAsync
                (_endpoints.Where(w => w.Name.Equals("Clients", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri + "/" + idCliente);
            var client = JsonSerializer.Deserialize<Client>(content);

            return Result.Success(client);
        }

        public async Task<Result> Delete(int id)
        {
            var result = await _client.DeleteAsync
                (_endpoints.Where(w => w.Name.Equals("Clients", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri + "/" + id);

            return result.StatusCode == System.Net.HttpStatusCode.Accepted
               ? Result.Success()
               : Result.Failure(ClientErrors.NotFound());
        }
    }
}
