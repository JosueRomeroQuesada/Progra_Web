using Domain.Instructors;
using System.Linq.Expressions;

namespace Application.Instructors
{
    public interface IInstructorRepository
    {
        List<Instructor> GetAll();

        Instructor Get(Expression<Func<Instructor, bool>> predicate);

        void Insert(Instructor instructor);

        void Update(Instructor instructor);

        void Delete(Instructor instructor);

        void Save();
    }
}
