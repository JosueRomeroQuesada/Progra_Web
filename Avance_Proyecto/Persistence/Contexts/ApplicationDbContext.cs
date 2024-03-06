using Application.Contexts;
using Domain.Instructors;
using Domain.Clients;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        public void Save()
        {
            this.SaveChanges();
        }
    }
}
