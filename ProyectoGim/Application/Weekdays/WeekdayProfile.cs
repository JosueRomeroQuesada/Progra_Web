using AutoMapper;
using Domain.Instructors;
using Domain.Weekdays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Weekdays
{
	public class WeekdayProfile : Profile
	{
		public WeekdayProfile()
		{
			CreateMap<CreateWeekday, Weekday>();

			CreateMap<UpdateWeekday, Weekday>()
				   .ForMember(destination => destination.Id, source => source.Ignore());

			CreateMap<Weekday, UpdateWeekday>();

			CreateMap<Weekday, WeekdayDTO>()
				.ConstructUsing(source => new WeekdayDTO(source.Id, source.IdDiaSemana, string.Concat(source.Dia)));
		}
	}
}
