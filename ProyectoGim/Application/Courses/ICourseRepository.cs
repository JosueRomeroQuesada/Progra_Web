using Domain.Courses;
using Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Courses
{
    public interface ICourseRepository : IRepositoryBase<Course>
    {
    }
}
