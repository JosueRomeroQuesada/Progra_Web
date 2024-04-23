using Application.Instructors;
using Domain.Instructors;
using Domain.Clients;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Repositories;
using System.Linq.Expressions;

namespace Persistence.Instructors
{
    public class InstructorRepository : RepositoryBase<Instructor>, IInstructorRepository
    {
        public InstructorRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public void SubscribeIntructor(Instructor instructor, Client client)
        {
            var clientInstrutor = new { client, instructor };
            _context.Add(clientInstrutor);
            _context.SaveChanges();
        }
    }
}
