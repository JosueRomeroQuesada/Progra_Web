using Domain.Instructors;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Instructors
{
    public interface IInstructorService
    {
        Result<IList<Instructor>> List();

        Result<Instructor> Get(string batch);

        Result<Instructor> Get(int id);

        Result Create(CreateInstructor createClient);

        Result Update(UpdateInstructor updateClient);

        Result Delete(int id);
    }
}
