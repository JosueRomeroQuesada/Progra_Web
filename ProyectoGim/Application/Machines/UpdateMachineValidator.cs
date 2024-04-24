using Domain.Machines;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Machines
{
    public class UpdateMachineValidator : AbstractValidator<UpdateMachine>
    {
        public UpdateMachineValidator()
        {
            RuleFor(o => o.Nombre).Length(2, 40);
            RuleFor(o => o.Codigo).Length(2, 40);
            RuleFor(o => o.Descripcion).Length(2, 60);
        }
    }
}
