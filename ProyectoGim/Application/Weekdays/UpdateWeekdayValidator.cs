using Domain.Weekdays;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Weekdays
{
	public class UpdateWeekdayValidator : AbstractValidator<UpdateWeekday>
	{
		public UpdateWeekdayValidator()
		{
			RuleFor(o => o.Dia).Length(2, 40);
		}
	}
}
