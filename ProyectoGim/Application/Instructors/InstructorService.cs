using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Domain.Instructors;
using Shared;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Application.Instructors
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository _repository;
        private readonly IMapper _mapper;

        public InstructorService(IInstructorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Result<IList<Instructor>> List()
        {
            return Result.Success<IList<Instructor>>(_repository.GetAll());
        }

        public Result<Instructor> Get(string idEntrenador)
        {
            var instructor = _repository.Get(s=>s.IdEntrenador == idEntrenador);
            
            if (instructor == null)
            {
                return Result.Failure<Instructor>(InstructorErrors.NotFound(idEntrenador));
            }
                return Result.Success(instructor);
            }
        
        public Result<Instructor> Get(int id)
        {
            var instructor = _repository.Get(s => s.Id == id);
            
            if (instructor is null)
            {
                return Result.Failure<Instructor>(InstructorErrors.NotFound());
            }

                return Result.Success(instructor);
            }

        public Result Create(CreateInstructor createInstructor)
        {
            var instructor = _mapper.Map<CreateInstructor, Instructor>(createInstructor);
            _repository.Insert(Instructor.Create(0, instructor));
            _repository.Save();
            return Result.Success();
        }

        public Result Update(UpdateInstructor updateInstructor)
        {
            var result = Get(updateInstructor.Id);
            if (result.IsFailure)
            {
                return Result.Failure(result.Error);
            }

            var instructor = result.Value;
            _mapper.Map<UpdateInstructor, Instructor>(updateInstructor, instructor);
            _repository.Update(instructor);
            _repository.Save();
            return Result.Success();
        }

        public Result Delete(int id)
        {
            var result = Get(id);
            if (result.IsFailure)
            {
                return Result.Failure(result.Error);
            }

            var instructor = result.Value;
            _repository.Delete(instructor);
            _repository.Save();
            return Result.Success();
        }
    }
}

