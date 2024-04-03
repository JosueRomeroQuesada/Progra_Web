using Application.Repositories;
using Domain.Instructors;
using Domain.Weekdays;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Weekdays
{
	public interface IWeekdayService
	{
		Result<IList<Weekday>> List();

		Result<Weekday> Get(string idDiaSemana);

		Result<Weekday> Get(int id);

		Result Create(CreateWeekday createWeekday);

		Result Update(UpdateWeekday updateWeekday);

		Result Delete(int id);
	}
}
