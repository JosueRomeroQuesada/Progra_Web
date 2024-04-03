using Application.Rutinas;
using AutoMapper;
using Domain.Rutinas;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Rutinas
{
    public class RutinaService : IRutinaService
    {
        private readonly IRutinaRepository _repository;
        private readonly IMapper _mapper;

        public RutinaService(IRutinaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public Result<IList<Rutina>> List(bool includeDia = false, bool includeEjercicio = false)
        {
            
            if (includeDia && includeEjercicio)
            {
                return Result.Success<IList<Rutina>>(_repository.GetAll(r => r.dias.Select(d => d.Ejercicios)));
            }
            else if (includeDia && !includeEjercicio)
            {
                return Result.Success<IList<Rutina>>(_repository.GetAll(r => r.dias));
            }
            else if (!includeDia && includeEjercicio)
            {
                return Result.Success<IList<Rutina>>(_repository.GetAll(d => d.Ejercicios));
            }
            else
            {
                return Result.Success<IList<Rutina>>(_repository.GetAll());
            }
        }


        public Result<Rutina> Get(string idRutina, bool includeDia = false, bool includeEjercicio = false)
        {
            if (includeDia || includeEjercicio)
            {
                var rutina = _repository.Get(r => r.IdRutina == idRutina, r => includeDia ? r.dias.Select(d => d.Ejercicios) : null);

                if (rutina == null)
                {
                    return Result.Failure<Rutina>(RutinaErrors.NotFound(idRutina));
                }
                
                return Result.Success(rutina);
            }
            else
            {
                var rutina = _repository.Get(r => r.IdRutina == idRutina);

                if (rutina == null)
                {
                    return Result.Failure<Rutina>(RutinaErrors.NotFound(idRutina));
                }

                return Result.Success(rutina);
            }
        }


        public Result<Rutina> Get(int id, bool includeDia = false, bool includeEjercicio = false)
        {
            if (includeDia || includeEjercicio)
            {
                var rutina = _repository.Get(r => r.Id == id, r => includeDia ? r.dias.Select(d => d.Ejercicios) : null);

                if (rutina == null)
                {
                    return Result.Failure<Rutina>(RutinaErrors.NotFound());
                }

                return Result.Success(rutina);
            }
            else
            {
                var rutina = _repository.Get(r => r.Id == id);

                if (rutina == null)
                {
                    return Result.Failure<Rutina>(RutinaErrors.NotFound());
                }

                return Result.Success(rutina);
            }
        }

        public Result Create(CreateRutina createRutina)
        {
            var rutina = _mapper.Map<CreateRutina, Rutina>(createRutina);
            _repository.Insert(Rutina.Create(0, rutina));
            _repository.Save();
            return Result.Success();
        }

        public Result Update(UpdateRutina updateRutina)
        {
            var result = Get(updateRutina.Id);
            if (result.IsFailure)
            {
                return Result.Failure(result.Error);
            }

            var rutina = result.Value;
            _mapper.Map<UpdateRutina, Rutina>(updateRutina, rutina);
            _repository.Update(rutina);
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

            var rutina = result.Value;
            _repository.Delete(rutina);
            _repository.Save();
            return Result.Success();
        }
    }
}
