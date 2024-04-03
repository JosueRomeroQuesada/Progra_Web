using Domain.Clients;
using Domain.Ejercicios;
using Domain.Instructors;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ejercicios
{
    public interface IEjercicioService
    {
        Result<IList<Ejercicio>> List(bool includeMachines = false);

        Result<Ejercicio> Get(string idEjercicio, bool includeMachines = false);

        Result Create(CreateEjercicio createEjercicio);

        Result Update(UpdateEjercicio updateEjercicio);

        Result Delete(int idEjercicio);
    }
}
