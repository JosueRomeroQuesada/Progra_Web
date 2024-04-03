using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Domain.Clients;
using Domain.Ejercicios;
using Domain.Machines;
using Shared;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Application.Ejercicios
{
    public class EjercicioService : IEjercicioService
    {
        private readonly IEjercicioRepository _repository;
        private readonly IMapper _mapper;

        public EjercicioService(IEjercicioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Result<IList<Ejercicio>> List(bool includeMachines = false)
        {

            return
                includeMachines
                    ? Result.Success<IList<Ejercicio>>(_repository.GetAll(i => i.Machines))
                    : Result.Success<IList<Ejercicio>>(_repository.GetAll());
        }

        public Result<Ejercicio> Get(string nombre, bool includeMachines = false)
        {
            var ejercicio =
                includeMachines
                    ? _repository.Get(s => s.Nombre == nombre, i => i.Machines)
                    : _repository.Get(s => s.Nombre == nombre);




            if (ejercicio == null)
            {
                return Result.Failure<Ejercicio>(EjercicioErrors.NotFound(nombre));
            }
            return Result.Success(ejercicio);;
        }

        public Result<Ejercicio> Get(int idEjercicio, bool includeMachines = false)
        {
            var ejercicio =
                includeMachines
                    ? _repository.Get(s => s.IdEjercicio == idEjercicio, i => i.Machines)
                    : _repository.Get(s => s.IdEjercicio == idEjercicio);




            if (ejercicio is null)
            {
                return Result.Failure<Ejercicio>(EjercicioErrors.NotFound());
            }

            return Result.Success(ejercicio);
        }

        public Result Create(CreateEjercicio createEjercicio)
        {
            var ejercicio = _mapper.Map< CreateEjercicio, Ejercicio>(createEjercicio);
            _repository.Insert(Ejercicio.Create(0,ejercicio));
            _repository.Save();
            return Result.Success();
        }

        public Result Update(UpdateEjercicio updateEjercicio)
        {
            var result = Get(updateEjercicio.IdEjercicio);
            if (result.IsFailure)
            {
                return Result.Failure(result.Error);
            }

            var ejercicio = result.Value;
            _mapper.Map<UpdateEjercicio, Ejercicio>(updateEjercicio, ejercicio);
            _repository.Update(ejercicio);
            _repository.Save();
            return Result.Success();
        }

        public Result Delete(int idEjercicio)
        {
            var result = Get(idEjercicio);
            if (result.IsFailure)
            {
                return Result.Failure(result.Error);
            }

            var ejercicio = result.Value;
            _repository.Delete(ejercicio);
            _repository.Save();
            return Result.Success();
        }
    }
}
