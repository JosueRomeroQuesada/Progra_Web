using Domain.Weekdays;
using Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Weekdays
{
	public interface IWeekdayRepository : IRepositoryBase<Weekday>
	{
	}
}
