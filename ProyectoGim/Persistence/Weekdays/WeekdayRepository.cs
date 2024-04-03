using Application.Weekdays;
using Domain.Weekdays;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Repositories;
using System.Linq.Expressions;
namespace Persistence.Weekdays
{
	public class WeekdayRepository : RepositoryBase<Weekday>, IWeekdayRepository
	{
		public WeekdayRepository(ApplicationDbContext context)
			: base(context)
		{

		}
	}
}
