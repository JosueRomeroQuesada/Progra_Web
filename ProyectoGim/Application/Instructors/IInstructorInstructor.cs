using Domain.Instructors;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Instructors
{
    public interface IInstructorInstructor
    {  
        Task<List<InstructorDTO>> List();

        Task<Result> Create(CreateInstructor createInstructor);

        Task<Result> Update(UpdateInstructor updateInstructor);

        Task<Result<Instructor>> Get(string idEntrenador); 
    }
}
