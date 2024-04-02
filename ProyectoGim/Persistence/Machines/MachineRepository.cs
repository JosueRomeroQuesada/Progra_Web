using Application.Machines;
using Domain.Machines;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Repositories;
using System.Linq.Expressions;

namespace Persistence.Machines
{
    public class MachineRepository : RepositoryBase<Machine>, IMachineRepository
    {
        public MachineRepository(ApplicationDbContext context)
            : base(context)
        {
            
        }
    }
}
