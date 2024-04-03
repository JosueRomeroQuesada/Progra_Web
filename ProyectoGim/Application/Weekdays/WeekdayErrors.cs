using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Weekdays
{
	public static class WeekdayErrors
	{
		public static Error NotFound(string idDiaSemana) =>
			new Error("Instructors.NOT_FOUND", $"The day with IdDiaSemana {idDiaSemana} was not found.");

		public static Error NotFound() =>
			new Error("Instructors.NOT_FOUND", $"The day with IdDiaSemana was not found.");

		public static Error NotCreated() =>
			new Error("Instructors.NOT_CREATED", $"The day with IdDiaSemana was not created.");

		public static Error NotUpdated() =>
		   new Error("Instructors.NOT_UPDATED", $"The day with IdDiaSemana was not updated.");
	}
}
