using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Domain.Machines;
using Shared;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Application.Machines
{
    public class MachineService : IMachineService
    {
        private readonly IMachineRepository _repository;
        private readonly IMapper _mapper;

        public MachineService(IMachineRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Result<IList<Machine>> List()
        {
            return Result.Success<IList<Machine>>(_repository.GetAll());
        }

        public Result<Machine> Get(string id)
        {
            var machine = _repository.Get(s => s.Codigo == id);


            if (machine == null)
            {
                return Result.Failure<Machine>(MachineErrors.NotFound(id));
            }
            return Result.Success(machine);
        }

        public Result<Machine> Get(int id)
        {
            var machine = _repository.Get(s => s.Id == id);

            if (machine is null)
            {
                return Result.Failure<Machine>(MachineErrors.NotFound());
            }

            return Result.Success(machine);
        }

        public Result Create(CreateMachine createMachine)
        {
            var machine = _mapper.Map<CreateMachine, Machine>(createMachine);
            _repository.Insert(Machine.Create(0, machine));
            _repository.Save();
            return Result.Success();
        }

        public Result Update(UpdateMachine updateMachine)
        {
            var result = Get(updateMachine.Id);
            if (result.IsFailure)
            {
                return Result.Failure(result.Error);
            }

            var machine = result.Value;
            _mapper.Map<UpdateMachine, Machine>(updateMachine, machine);
            _repository.Update(machine);
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

            var machine = result.Value;
            _repository.Delete(machine);
            _repository.Save();
            return Result.Success();
        }
    }
}
