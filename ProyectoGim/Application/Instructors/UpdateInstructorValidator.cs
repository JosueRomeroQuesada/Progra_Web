using Domain.Instructors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Instructors
{
    public class UpdateInstructorValidator : AbstractValidator<UpdateInstructor>
    {
        public UpdateInstructorValidator()
        {
            RuleFor(o => o.Nombre).Length(2, 40);
            RuleFor(o => o.Apellido).Length(2, 40);
        }
    }
}
