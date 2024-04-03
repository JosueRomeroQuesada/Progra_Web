using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Domain.Weekdays;
using Shared;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Application.Weekdays
{
	public class WeekdayService : IWeekdayService
	{
		private readonly IWeekdayRepository _repository;
		private readonly IMapper _mapper;

		public WeekdayService(IWeekdayRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public Result<IList<Weekday>> List()
		{
			return Result.Success<IList<Weekday>>(_repository.GetAll());
		}

		public Result<Weekday> Get(string idDiaSemana)
		{
			var weekday = _repository.Get(s => s.IdDiaSemana == idDiaSemana);

			if (weekday == null)
			{
				return Result.Failure<Weekday>(WeekdayErrors.NotFound(idDiaSemana));
			}
			return Result.Success(weekday);
		}

		public Result<Weekday> Get(int id)
		{
			var weekday = _repository.Get(s => s.Id == id);

			if (weekday is null)
			{
				return Result.Failure<Weekday>(WeekdayErrors.NotFound());
			}

			return Result.Success(weekday);
		}

		public Result Create(CreateWeekday createWeekday)
		{
			var weekday = _mapper.Map<CreateWeekday, Weekday>(createWeekday);
			_repository.Insert(Weekday.Create(0, weekday));
			_repository.Save();
			return Result.Success();
		}

		public Result Update(UpdateWeekday updateWeekday)
		{
			var result = Get(updateWeekday.Id);
			if (result.IsFailure)
			{
				return Result.Failure(result.Error);
			}

			var weekday = result.Value;
			_mapper.Map<UpdateWeekday, Weekday>(updateWeekday, weekday);
			_repository.Update(weekday);
			_repository.Save();
			return Result.Success();
		}

		public Result Delete(int id)
		{
			var result = Get(id);
			if (result.IsFailure)
			{
				return Result.Failure(result.Error);
			}

			var weekday = result.Value;
			_repository.Delete(weekday);
			_repository.Save();
			return Result.Success();
		}
	}
}