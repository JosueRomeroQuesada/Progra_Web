using Application.Contexts;
using Application.Instructors;
using Domain.Instructors;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Linq.Expressions;

namespace Persistence.Instructors
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly DbSet<Instructor> _instructors;

        public InstructorRepository(ApplicationDbContext context)
        {
            _context = context;
            _instructors = _context.Instructors;
        }

        public List<Instructor> GetAll()
        {
            return _instructors.ToList();
        }

        public Instructor Get(Expression<Func<Instructor, bool>> predicate)
        {
            IQueryable<Instructor> query = _instructors;
            query = query.Where(predicate);

            return query.FirstOrDefault();
        }

        public void Insert(Instructor instructor)
        {
            _instructors.Add(instructor);
        }

        public void Update(Instructor instructor)
        {
            _instructors.Update(instructor);
        }

        public void Delete(Instructor instructor)
        {
            _instructors.Remove(instructor);
        }

        public void Save()
        {
            _context.Save();
        }
    }
}