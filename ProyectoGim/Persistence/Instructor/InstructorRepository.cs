using Application.Instructors;
using Domain.Instructors;
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
    }
}
