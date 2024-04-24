using Domain.Clients;
using Domain.Ejercicios;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ejercicios
{
    public interface IEjercicioEjercicio
    {
        Task<List<EjercicioDTO>> List();

        Task<Result> Create(CreateEjercicio createEjercicio);

        Task<Result> Update(UpdateEjercicio updateEjercicio);

        Task<Result<Ejercicio>> Get(string idEjercicio);

        Task<Result> Delete(int id);
    }
}