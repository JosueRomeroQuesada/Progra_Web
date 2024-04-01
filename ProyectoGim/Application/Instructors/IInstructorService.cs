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

        Result<Instructor> Get(string idEntrenador);

        Result<Instructor> Get(int id);

        Result Create(CreateInstructor createInstructor);

        Result Update(UpdateInstructor updateInstructor);

        Result Delete(int id);
    }
}
