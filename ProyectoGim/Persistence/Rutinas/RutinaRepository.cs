using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Rutinas;
using Domain.Rutinas;
using Persistence.Repositories;

namespace Persistence.Rutinas
{
    internal class RutinaRepository : RepositoryBase<Rutina>, IRutinaRepository
    {
        public RutinaRepository(ApplicationDbContext context)
            : base(context)
        {

        }
    }
}
