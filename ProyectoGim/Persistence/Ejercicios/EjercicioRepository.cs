using Application.Ejercicios;
using Domain.Ejercicios;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Repositories;
using System.Linq.Expressions;

namespace Persistence.Ejercicios
{
    public class EjercicioRepository : RepositoryBase<Ejercicio>, IEjercicioRepository
    {
        public EjercicioRepository(ApplicationDbContext context)
            : base(context)
        {
            
        }
    }
}
