using Application.Repositories;
using Domain.Clients;
using Domain.Ejercicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ejercicios
{
    public interface IEjercicioRepository : IRepositoryBase<Ejercicio>
    {
        
    }
}
