
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
using Domain.Instructors;

namespace Application.Instructors
{
    public sealed class InstructorInstructor : IInstructorInstructor
    {
        private readonly List<EndpointConfiguration> _endpoints;
        private readonly HttpClient _instructor;
        private readonly IMapper _mapper;

        public InstructorInstructor(IOptions<List<EndpointConfiguration>> options, HttpClient instructor, IMapper mapper) 
        {
            _endpoints = options.Value.Where
                (w => w.Name.Equals("DefaultApi", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Endpoints.ToList();
            _instructor = instructor;
            _mapper = mapper;
        }
        public async Task<List<InstructorDTO>> List()
        {
            var content = await _instructor.GetStringAsync(_endpoints.Where(w => w.Name.Equals("Instructors", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri);
            var instructors = JsonSerializer.Deserialize<List<Instructor>>(content);

            return _mapper.Map<List<InstructorDTO>>(instructors);
        }

        public async Task<Result> Create(CreateInstructor createInstructor)
        {
            var content = new StringContent(JsonSerializer.Serialize(createInstructor), Encoding.UTF8, "application/json");
            var result = await _instructor.PostAsync
                (_endpoints.Where(w => w.Name.Equals("Instructors", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri, content);

            return result.StatusCode == System.Net.HttpStatusCode.Created
                ? Result.Success()
                : Result.Failure(InstructorErrors.NotCreated());
        }

        public async Task<Result> Update(UpdateInstructor updateInstructor)
        {
            var content = new StringContent(JsonSerializer.Serialize(updateInstructor), Encoding.UTF8, "application/json");
            var result = await _instructor.PutAsync
                (_endpoints.Where(w => w.Name.Equals("Instructors", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri, content);

            return result.StatusCode == System.Net.HttpStatusCode.Accepted
                ? Result.Success()
                : Result.Failure(InstructorErrors.NotUpdated());
        }

        public async Task<Result<Instructor>> Get(string idEntrenador)
        {
            var content = await _instructor.GetStringAsync
                (_endpoints.Where(w => w.Name.Equals("Instructors", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri + "/" + idEntrenador);
            var instructor = JsonSerializer.Deserialize<Instructor>(content);

            return Result.Success(instructor);
        }
    }
}
