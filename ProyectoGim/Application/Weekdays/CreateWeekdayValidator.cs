using Domain.Instructors;
using Domain.Weekdays;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Weekdays	
{
	public class CreateWeekdayValidator : AbstractValidator<CreateWeekday>
	{
		public CreateWeekdayValidator()
		{
			RuleFor(o => o.IdDiaSemana).Length(5, 10);
			RuleFor(o => o.Dia).Length(5, 9);
		}
	}
}
