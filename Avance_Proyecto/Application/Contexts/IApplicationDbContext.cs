using Domain.Instructors;
using Domain.Clients;
using Microsoft.EntityFrameworkCore;

namespace Application.Contexts
{
    public interface IApplicationDbContext
    {
        DbSet<Client> Clients { get; set; }
        DbSet<Instructor> Instructors { get; set; } 

        void Save();
    }


}
