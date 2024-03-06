using AutoMapper;
using Domain.Instructors;
using Shared;

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

        public Result<Instructor> Get(string batch)
        {
            var instructor = _repository.Get(s => s.Batch == batch);

            if (instructor == null)
            {
                return Result.Failure<Instructor>(InstructorErrors.NotFound(batch));
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

            var client = result.Value;
            _repository.Delete(client);
            _repository.Save();
            return Result.Success();
        }
    }
}
