using Domain.Rutinas;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Rutinas
{
    public class UpdateRutinaValidator : AbstractValidator<UpdateRutina>
    {
        public UpdateRutinaValidator()
        {
            RuleFor(o => o.Descripcion).Length(3, 100);
            RuleFor(o => o.Series).Length(2, 40);
            RuleFor(o => o.Repeticiones).Length(2, 40);
            RuleFor(o => o.Peso).Length(2, 50);
        }
    }
}
