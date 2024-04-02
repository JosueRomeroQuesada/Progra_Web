using Domain.Instructors;
using Domain.Clients;
using Domain.Machines;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contexts
{
    public interface IApplicationDbContext
    {
        DbSet<Client> Clients { get; set; }

        DbSet<Instructor> Instructors { get; set; }

        DbSet<Machine> Machines { get; set; }

        void Save();
    }
}
