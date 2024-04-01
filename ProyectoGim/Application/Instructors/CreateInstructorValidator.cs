using Domain.Instructors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Instructors
{
    public class CreateInstructorValidator : AbstractValidator<CreateInstructor>
    {
        public CreateInstructorValidator()
        {
            RuleFor(o => o.IdEntrenador).Length(5, 10);
            RuleFor(o => o.Cedula).Length(5, 10);
            RuleFor(o => o.Nombre).Length(2, 40);
            RuleFor(o => o.Apellido).Length(2, 40);
        }
    }
}
