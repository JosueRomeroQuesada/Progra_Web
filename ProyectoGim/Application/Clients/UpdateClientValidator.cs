using Domain.Clients;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Clients
{
    public class UpdateClientValidator : AbstractValidator<UpdateClient>
    {
        public UpdateClientValidator()
        {
            RuleFor(o => o.Nombre).Length(2, 40);
            RuleFor(o => o.Apellido).Length(2, 40);
            RuleFor(o => o.Peso).Length(2, 5);
            RuleFor(o => o.Altura).Length(3, 5);
            RuleFor(o => o.Preferencias).Length(5, 50);
        }
    }
}
