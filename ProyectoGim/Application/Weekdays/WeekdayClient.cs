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
using Domain.Weekdays;
using Application.Clients;
using Domain.Clients;

namespace Application.Weekdays
{
    public sealed class WeekdayWeekday : IWeekdayClient
    {
        private readonly List<EndpointConfiguration> _endpoints;
        private readonly HttpClient _weekday;
        private readonly IMapper _mapper;

        public WeekdayWeekday(IOptions<List<EndpointConfiguration>> options, HttpClient weekday, IMapper mapper)
        {
            _endpoints = options.Value.Where
                (w => w.Name.Equals("DefaultApi", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Endpoints.ToList();
            _weekday = weekday;
            _mapper = mapper;
        }
        public async Task<List<WeekdayDTO>> List()
        {
            var content = await _weekday.GetStringAsync(_endpoints.Where(w => w.Name.Equals("weekdays", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri);
            var weekdays = JsonSerializer.Deserialize<List<Weekday>>(content);

            return _mapper.Map<List<WeekdayDTO>>(weekdays);
        }

        public async Task<Result> Create(CreateWeekday createWeekday)
        {
            var content = new StringContent(JsonSerializer.Serialize(createWeekday), Encoding.UTF8, "application/json");
            var result = await _weekday.PostAsync
                (_endpoints.Where(w => w.Name.Equals("weekdays", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri, content);

            return result.StatusCode == System.Net.HttpStatusCode.Created
                ? Result.Success()
                : Result.Failure(WeekdayErrors.NotCreated());
        }

        public async Task<Result> Update(UpdateWeekday updateInstructor)
        {
            var content = new StringContent(JsonSerializer.Serialize(updateInstructor), Encoding.UTF8, "application/json");
            var result = await _weekday.PutAsync
                (_endpoints.Where(w => w.Name.Equals("weekdays", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri, content);

            return result.StatusCode == System.Net.HttpStatusCode.Accepted
                ? Result.Success()
                : Result.Failure(WeekdayErrors.NotUpdated());
        }

        public async Task<Result<Weekday>> Get(string idDiaSemana)
        {
            var content = await _weekday.GetStringAsync
                (_endpoints.Where(w => w.Name.Equals("weekdays", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri + "/" + idDiaSemana);
            var weekday = JsonSerializer.Deserialize<Weekday>(content);

            return Result.Success(weekday);
        }

        public async Task<Result> Delete(int id)
        {
            var result = await _weekday.DeleteAsync
                (_endpoints.Where(w => w.Name.Equals("Weekdays", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri + "/" + id);

            return result.StatusCode == System.Net.HttpStatusCode.Accepted
               ? Result.Success()
               : Result.Failure(ClientErrors.NotFound());
        }
    }
}
