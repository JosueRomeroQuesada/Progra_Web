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
    public interface IWeekdayClient
    {
        Task<List<WeekdayDTO>> List();

        Task<Result> Create(CreateWeekday createWeekday);

        Task<Result> Update(UpdateWeekday updateWeekday);

        Task<Result<Weekday>> Get(string idDiaSemana);

        Task<Result> Delete(int id);
    }
}
