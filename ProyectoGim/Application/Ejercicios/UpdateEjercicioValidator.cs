using Domain.Clients;
using Domain.Ejercicios;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ejercicios
{
    public class UpdateEjercicioValidator : AbstractValidator<UpdateEjercicio>
    {
        public UpdateEjercicioValidator()
        {
            RuleFor(o => o.Nombre).Length(2, 40);
            RuleFor(o => o.Zona).Length(2, 40);
            RuleFor(o => o.Descripcion).Length(5, 50);
        }
    }
}
